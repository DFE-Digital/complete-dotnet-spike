using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Dfe.ManageFreeSchoolProjects.API.Extensions;

public static class ApplicationBuilderExtensions
{
	public static IApplicationBuilder UseManageFreeSchoolProjectsSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
	{
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			foreach (var desc in provider.ApiVersionDescriptions)
			{
				c.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.GroupName.ToUpperInvariant());
			}
                
			//c.SupportedSubmitMethods(SubmitMethod.Get);
		});

		return app;
	}
	    
	public static IApplicationBuilder UseManageFreeSchoolProjectsEndpoints(this IApplicationBuilder app)
	{
		app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

		return app;
	}
}