using Azure.Storage.Blobs;
using Dfe.Complete.Authorization;
using Dfe.Complete.Configuration;
using Dfe.Complete.Security;
using Dfe.Complete.Services;
using Dfe.Complete.Services.Project;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System;
using System.Security.Claims;

namespace Dfe.Complete;

public class Startup
{
    private readonly TimeSpan _authenticationExpiration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

        _authenticationExpiration = TimeSpan.FromMinutes(int.Parse(Configuration["AuthenticationExpirationInMinutes"] ?? "60"));
    }

    private IConfiguration Configuration { get; }

    private IConfigurationSection GetConfigurationSectionFor<T>()
    {
        string sectionName = typeof(T).Name.Replace("Options", string.Empty);
        return Configuration.GetRequiredSection(sectionName);
    }

    private T GetTypedConfigurationFor<T>()
    {
        return GetConfigurationSectionFor<T>().Get<T>();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddFeatureManagement();
        services.AddHealthChecks();
        services
           .AddRazorPages(options =>
           {
               options.Conventions.AuthorizeFolder("/");
           })
           .AddViewOptions(options =>
           {
               options.HtmlHelperOptions.ClientValidationEnabled = false;
           });

        services.AddControllersWithViews()
           .AddMicrosoftIdentityUI();
        SetupDataprotection(services);

        services.AddScoped<CompleteApiClient, CompleteApiClient>();
        services.AddScoped<IAnalyticsConsentService, AnalyticsConsentService>();
        services.AddScoped<IGetProjectListService, GetProjectListService>();

        services.AddScoped(sp => sp.GetService<IHttpContextAccessor>()?.HttpContext?.Session);
        services.AddSession(options =>
        {
            options.IdleTimeout = _authenticationExpiration;
            options.Cookie.Name = ".ManageFreeSchoolProjects.Session";
            options.Cookie.IsEssential = true;
        });
        services.AddHttpContextAccessor();

        services.AddAuthorization(options => { options.DefaultPolicy = SetupAuthorizationPolicyBuilder().Build(); });

        services.AddMicrosoftIdentityWebAppAuthentication(Configuration);
        services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme,
           options =>
           {
               options.AccessDeniedPath = "/access-denied";
               options.Cookie.Name = ".ManageFreeSchoolProjects.Login";
               options.Cookie.HttpOnly = true;
               options.Cookie.IsEssential = true;
               options.ExpireTimeSpan = _authenticationExpiration;
               options.SlidingExpiration = true;
               if (string.IsNullOrEmpty(Configuration["CI"]))
               {
                   options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
               }
           });

        services.AddApplicationInsightsTelemetry();

        services.AddHttpClient("CompleteClient", (_, client) =>
        {
            CompleteOptions mfspOptions = GetTypedConfigurationFor<CompleteOptions>();
            client.BaseAddress = new Uri(mfspOptions.ApiEndpoint);
            client.DefaultRequestHeaders.Add("ApiKey", mfspOptions.ApiKey);
        });

        services.AddScoped<ErrorService>();
        services.AddSingleton<IAuthorizationHandler, HeaderRequirementHandler>();
        services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
 
    }

    private void SetupDataprotection(IServiceCollection services)
    {
        if (!string.IsNullOrEmpty(Configuration["ConnectionStrings:BlobStorage"]))
        {
            string blobName = "keys.xml";
            BlobContainerClient container = new BlobContainerClient(new Uri(Configuration["ConnectionStrings:BlobStorage"]));

            BlobClient blobClient = container.GetBlobClient(blobName);

            services.AddDataProtection()
                .PersistKeysToAzureBlobStorage(blobClient);
        }
        else
        {
            services.AddDataProtection();
        }
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        logger.LogInformation("Feature Flag - Use Academisation API: {usingAcademisationApi}", IsFeatureEnabled("hi"));

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Errors");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSecurityHeaders(
           SecurityHeadersDefinitions.GetHeaderPolicyCollection(env.IsDevelopment())
              .AddXssProtectionDisabled()
        );

        app.UseStatusCodePagesWithReExecute("/Errors", "?statusCode={0}");

        app.UseHttpsRedirection();
        app.UseHealthChecks("/health");

        //For Azure AD redirect uri to remain https
        ForwardedHeadersOptions forwardOptions = new() { ForwardedHeaders = ForwardedHeaders.All, RequireHeaderSymmetry = false };
        forwardOptions.KnownNetworks.Clear();
        forwardOptions.KnownProxies.Clear();
        app.UseForwardedHeaders(forwardOptions);

        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            //endpoints.MapGet("/", context =>
            //{
            //   context.Response.Redirect("project-type", false);
            //   return Task.CompletedTask;
            //});
            endpoints.MapRazorPages();
            endpoints.MapControllerRoute("default", "{controller}/{action}/");
        });

        bool IsFeatureEnabled(string flag)
        {
            return (app.ApplicationServices.GetService(typeof(IFeatureManager)) as IFeatureManager)?.IsEnabledAsync(flag).Result ?? false;
        }
    }

    /// <summary>
    ///    Builds Authorization policy
    ///    Ensure authenticated user and restrict roles if they are provided in configuration
    /// </summary>
    /// <returns>AuthorizationPolicyBuilder</returns>
    private AuthorizationPolicyBuilder SetupAuthorizationPolicyBuilder()
    {
        AuthorizationPolicyBuilder policyBuilder = new();
        policyBuilder.RequireAuthenticatedUser();

        string allowedRoles = Configuration.GetSection("AzureAd")["AllowedRoles"];
        if (string.IsNullOrWhiteSpace(allowedRoles) is false)
        {
            policyBuilder.RequireClaim(ClaimTypes.Role, allowedRoles.Split(','));
        }

        return policyBuilder;
    }
}
