using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.StakeholderKickoff;
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

            await _context.SaveChangesAsync();
        }
    }
}
