using Dfe.Complete.API.Configuration;
using Dfe.Complete.API.Extensions;
using Dfe.Complete.API.Middleware;
using Dfe.Complete.API.StartupConfiguration;
using Dfe.Complete.Middleware;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Dfe.Complete.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
            services.AddApplicationInsightsTelemetry();

            services.AddCompleteApiProject(Configuration);

            services.AddHttpClient("AcademiesClient", (_, client) =>
            {
                AcademiesOptions academiesOptions = GetTypedConfigurationFor<AcademiesOptions>();
                client.BaseAddress = new Uri(academiesOptions.ApiEndpoint);
                client.DefaultRequestHeaders.Add("ApiKey", academiesOptions.ApiKey);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
	        app.UseCompleteSwagger(provider);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseMiddleware<UrlDecoderMiddleware>();
            app.UseMiddleware<CorrelationIdMiddleware>();
			app.UseMiddleware<UserContextReceiverMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCompleteEndpoints();
        }
    }
}
