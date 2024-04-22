using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.API.Middleware;
using Dfe.ManageFreeSchoolProjects.API.StartupConfiguration;
using Dfe.ManageFreeSchoolProjects.Middleware;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Dfe.ManageFreeSchoolProjects.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();

            services.AddMfspApiProject(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
	        app.UseManageFreeSchoolProjectsSwagger(provider);

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

            app.UseManageFreeSchoolProjectsEndpoints();
        }
    }
}
