using Dfe.Complete.API.UseCases;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.API.UseCases.Project;
using Dfe.Complete.API.UseCases.Project.Conversion;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Transfer;
using Dfe.Complete.API.UseCases.Project.Transfer.Tasks;
using Dfe.Complete.Logging;
using Dfe.Complete.UserContext;
using FluentValidation;
using System.Reflection;

namespace Dfe.Complete.API.StartupConfiguration
{
    public static class DependencyConfigurationExtensions
	{
		public static IServiceCollection AddApiDependencies(this IServiceCollection services)
		{
			services.AddScoped<IServerUserInfoService, ServerUserInfoService>();
			
			services.AddScoped<ICorrelationContext, CorrelationContext>();

			services.AddScoped<AcademiesApiClient, AcademiesApiClient>();

			services.AddScoped<IApiKeyValidationService, ApiKeyValidationService>();
			services.AddScoped<IConstructApiKeyValidationService, ConstructApiKeyValidationService>();
			services.AddScoped<ISfaApiKeyValidationService, SfaApiKeyValidationService>();
			services.AddScoped<IGetProjectListService, GetProjectListService>();
			services.AddScoped<IGetEstablishmentsBulkService, GetEstablishmentsBulkService>();
			services.AddScoped<IGetTrustsBulkService, GetTrustsBulkService>();
			services.AddScoped<IGetEstablishmentAndTrustService, GetEstablishmentAndTrustService>();
			services.AddScoped<ISetProjectSchoolNameService, SetProjectSchoolNameService>();
			services.AddScoped<IGetProjectDetailsService, GetProjectDetailsService>();

			// Conversion projects
			services.AddScoped<ICreateConversionProjectService, CreateConversionProjectService>();
			services.AddScoped<IGetConversionProjectService, GetConversionProjectService>();

			// Conversion tasks
			services.AddScoped<IGetConversionProjectByTaskService, GetConversionProjectByTaskService>();
			services.AddScoped<IUpdateConversionProjectByTaskService, UpdateConversionProjectByTaskService>();
			services.AddScoped<IGetConversionProjectByTaskSummaryService, GetConversionProjectByTaskSummaryService>();

			// Transfer projects
			services.AddScoped<ICreateTransferProjectService, CreateTransferProjectService>();
			services.AddScoped<IGetTransferProjectService, GetTransferProjectService>();

			// Transfer tasks
			services.AddScoped<IGetTransferProjectByTaskService, GetTransferProjectByTaskService>();
			services.AddScoped<IUpdateTransferProjectByTaskService, UpdateTransferProjectByTaskService>();
			services.AddScoped<IGetTransferProjectByTaskSummaryService, GetTransferProjectByTaskSummaryService>();

            services.AddValidatorsFromAssembly(Assembly.Load(Assembly.GetExecutingAssembly().FullName));

            return services;
		}
	}
}
