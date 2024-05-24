using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dfe.Complete.StartupConfiguration
{
    public static class StartupConfigurationExtensions
    {
        public static IServiceCollection AddCompleteClientProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddClientDependencies();

            return services;
        }
    }
}
