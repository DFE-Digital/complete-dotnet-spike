using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandQuestionnaire;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.StakeholderKickoff;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.SupplementalFundingAgreement;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public interface IUpdateConversionProjectByTaskService
    {
        public Task Execute(Guid projectId, UpdateConversionProjectByTaskRequest request);
    }

    public class UpdateConversionProjectByTaskService : IUpdateConversionProjectByTaskService
    {
        private readonly CompleteContext _context;

        public UpdateConversionProjectByTaskService(
            CompleteContext context)
        {
            _context = context;
        }

        public async Task Execute(Guid projectId, UpdateConversionProjectByTaskRequest request)
        {
            var queryResult = await _context.GetConversionProjectById(projectId);
            var project = queryResult.Project;
            var conversionTaskData = queryResult.TaskData;

            if (request.HandoverWithDeliveryOfficer != null)
                UpdateHandoverWithDeliveryOfficerTaskBuilder.Execute(request.HandoverWithDeliveryOfficer, conversionTaskData);

            if (request.StakeholderKickoff != null)
                UpdateConversionStakeholderKickoffTaskBuilder.Execute(request.StakeholderKickoff, conversionTaskData);

            if (request.LandQuestionnaire != null)
                UpdateConversionLandQuestionnaireTaskBuilder.Execute(request.LandQuestionnaire, conversionTaskData);

            if (request.LandRegistry != null)
                UpdateConversionLandRegistryTaskBuilder.Execute(request.LandRegistry, conversionTaskData);

            if (request.SupplementalFundingAgreement != null)
                UpdateConversionSupplementalFundingAgreementTaskBuilder.Execute(request.SupplementalFundingAgreement, conversionTaskData);

            await _context.SaveChangesAsync();
        }
    }
}
