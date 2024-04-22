namespace Dfe.ManageFreeSchoolProjects.API.StartupConfiguration;

public static class StartupConfigurationExtensions
{
	public static IServiceCollection AddMfspApiProject(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddApiDependencies();
		services.AddDatabase(configuration);
		services.AddApi(configuration);
		
		return services;
	}
}