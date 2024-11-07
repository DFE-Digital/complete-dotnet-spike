using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandQuestionnaire;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandRegistry;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.StakeholderKickoff;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.SupplementalFundingAgreement;
using Dfe.Complete.API.UseCases.Project.Tasks;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public interface IGetConversionProjectByTaskSummaryService
    {
        Task<GetConversionProjectByTaskSummaryResponse> Execute(Guid projectId);
    }

    public class GetConversionProjectByTaskSummaryService : IGetConversionProjectByTaskSummaryService
    {
        private readonly CompleteContext _context;
        private readonly IGetProjectDetailsService _getProjectDetailsService;


        public GetConversionProjectByTaskSummaryService(
            CompleteContext context,
            IGetProjectDetailsService getProjectDetailsService)
        {
            _context = context;
            _getProjectDetailsService = getProjectDetailsService;
        }

        public async Task<GetConversionProjectByTaskSummaryResponse> Execute(Guid projectId)
        {
            var queryResult = await _context.GetConversionProjectById(projectId);
            var project = queryResult.Project;
            var conversionTasks = queryResult.TaskData;

            var handoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(conversionTasks);
            var stakeholderKickoff = ConversionStakeholderKickoffTaskBuilder.Execute(conversionTasks);
            var landQuestionnaire = ConversionLandQuestionnaireTaskBuilder.Execute(conversionTasks);
            var landRegistry = ConversionLandRegistryTaskBuilder.Execute(conversionTasks);
            var supplementalFundingAgreement = ConversionSupplementalFundingAgreementTaskBuilder.Execute(conversionTasks);
            var projectDetails = await _getProjectDetailsService.Execute(project);

            var result = new GetConversionProjectByTaskSummaryResponse
            {
                ProjectDetails = projectDetails,
                HandoverWithDeliveryOfficer = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(handoverWithDeliveryOfficer),
                },
                StakeholderKickoff = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(stakeholderKickoff),
                },
                LandQuestionnaire = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(landQuestionnaire)
                },
                LandRegistry = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(landRegistry)
                },
                SupplementalFundingAgreement = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(supplementalFundingAgreement)
                }
            };

            return result;
        }
    }
}
