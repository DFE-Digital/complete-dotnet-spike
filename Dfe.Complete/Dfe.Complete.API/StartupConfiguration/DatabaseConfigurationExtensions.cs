using Dfe.ManageFreeSchoolProjects.Data;

namespace Dfe.ManageFreeSchoolProjects.API.StartupConfiguration;

public static class DatabaseConfigurationExtensions
{
	public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		services.AddDbContext<CompleteContext>(options =>
			options.UseCompleteSqlServer(connectionString)
		);

		return services;
	}
}