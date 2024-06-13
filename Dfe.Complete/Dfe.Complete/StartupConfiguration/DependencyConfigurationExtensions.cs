using Dfe.Complete.Services;
using Dfe.Complete.Services.Project;
using Dfe.Complete.Services.Project.Conversion;
using Dfe.Complete.Services.Project.Transfer;
using Microsoft.Extensions.DependencyInjection;

namespace Dfe.Complete.StartupConfiguration
{
    public static class DependencyConfigurationExtensions
    {
        public static IServiceCollection AddClientDependencies(this IServiceCollection services)
        {
            services.AddScoped<CompleteApiClient, CompleteApiClient>();
            services.AddScoped<IAnalyticsConsentService, AnalyticsConsentService>();
            services.AddScoped<IGetProjectListService, GetProjectListService>();
            services.AddScoped<IGetProjectNoteListService, GetProjectNoteListService>();
            services.AddScoped<ICreateProjectNoteService, CreateProjectNoteService>();
            services.AddScoped<IGetProjectNoteService, GetProjectNoteService>();
            services.AddScoped<IUpdateProjectNoteService, UpdateProjectNoteService>();

            // Transfers
            services.AddScoped<IGetTransferProjectByTaskService, GetTransferProjectByTaskService>();
            services.AddScoped<IUpdateTransferProjectByTaskService, UpdateTransferProjectByTaskService>();
            services.AddScoped<IGetTransferProjectByTaskSummaryService, GetTransferProjectByTaskSummaryService>();
            services.AddScoped<IGetTransferProjectService, GetTransferProjectService>();
            services.AddScoped<IUpdateTransferProjectService, UpdateTransferProjectService>();

            // Conversions
            services.AddScoped<IGetConversionProjectByTaskService, GetConversionProjectByTaskService>();
            services.AddScoped<IUpdateConversionProjectByTaskService, UpdateConversionProjectByTaskService>();
            services.AddScoped<IGetConversionProjectByTaskSummaryService, GetConversionProjectByTaskSummaryService>();
            services.AddScoped<IGetConversionProjectService, GetConversionProjectService>();

            return services;
        }
    }
}
