using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandQuestionnaire;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandRegistry;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.StakeholderKickoff;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.SupplementalFundingAgreement;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public interface IGetConversionProjectByTaskService
    {
        public Task<GetConversionProjectByTaskResponse> Execute(Guid projectId, ConversionProjectTaskName taskName);
    }

    public class GetConversionProjectByTaskService : IGetConversionProjectByTaskService
    {
        private readonly CompleteContext _context;
        private readonly ISetProjectSchoolNameService _setProjectSchoolNameService;

        public GetConversionProjectByTaskService(
            CompleteContext context,
            ISetProjectSchoolNameService setProjectSchoolNameService)
        {
            _context = context;
            _setProjectSchoolNameService = setProjectSchoolNameService;
        }

        public async Task<GetConversionProjectByTaskResponse> Execute(Guid projectId, ConversionProjectTaskName taskName)
        {
            var queryResult = await _context.GetConversionProjectById(projectId);
            var project = queryResult.Project;
            var conversionTaskData = queryResult.TaskData;

            GetConversionProjectByTaskResponse response = new GetConversionProjectByTaskResponse()
            {
                Urn = project.Urn
            };

            await _setProjectSchoolNameService.Execute(response);

            switch (taskName)
            {
                case ConversionProjectTaskName.HandoverWithDeliveryOfficer:
                    response.HandoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(conversionTaskData);
                    break;

                case ConversionProjectTaskName.StakeholderKickoff:
                    response.StakeholderKickoff = ConversionStakeholderKickoffTaskBuilder.Execute(conversionTaskData, project);
                    break;

                case ConversionProjectTaskName.LandQuestionnaire:
                    response.LandQuestionnaire = ConversionLandQuestionnaireTaskBuilder.Execute(conversionTaskData);
                    break;

                case ConversionProjectTaskName.LandRegistry:
                    response.LandRegistry = ConversionLandRegistryTaskBuilder.Execute(conversionTaskData);
                    break;

                case ConversionProjectTaskName.SupplementalFundingAgreement:
                    response.SupplementalFundingAgreement = ConversionSupplementalFundingAgreementTaskBuilder.Execute(conversionTaskData);
                    break;

                default:
                    throw new ArgumentException($"Unknown project conversion task name {taskName}");
            }

            return response;
        }
    }
}
