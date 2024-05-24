using Dfe.Complete.API.Configuration;

namespace Dfe.Complete.API.StartupConfiguration;

public static class StartupConfigurationExtensions
{
	public static IServiceCollection AddCompleteApiProject(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddApiDependencies();
		services.AddDatabase(configuration);
		services.AddApi(configuration);

        return services;
	}
}