using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data;

public static class DbContextExtensions
{
	public static DbContextOptionsBuilder UseCompleteSqlServer(this DbContextOptionsBuilder optionsBuilder, string connectionString)
	{
		optionsBuilder.UseSqlServer(
			connectionString,
			opt => opt.MigrationsHistoryTable("__EfMigrationsHistory"));
		return optionsBuilder;
	}
}