using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks
{
    public interface IUpdateTransferProjectByTaskService
    {
        public Task Execute(Guid projectId, UpdateTransferProjectByTaskRequest request);
    }

    public class UpdateTransferProjectByTaskService : IUpdateTransferProjectByTaskService
    {
        private readonly CompleteContext _context;

        public UpdateTransferProjectByTaskService(
            CompleteContext context)
        {
            _context = context;
        }

        public async Task Execute(Guid projectId, UpdateTransferProjectByTaskRequest request)
        {
            var project = await _context.GetTransferProjects(projectId).FirstOrDefaultAsync();

            if (project == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var transferTaskData = await _context.TransferTasksData.FirstOrDefaultAsync(t => t.Id == project.TasksDataId);

            if (transferTaskData == null)
            {
                throw new UnprocessableContentException($"Project with id {projectId} does not have any transfer tasks data");
            }

            if (request.HandoverWithDeliveryOfficer != null)
                UpdateHandoverWithDeliveryOfficerTaskBuilder.Execute(request.HandoverWithDeliveryOfficer, transferTaskData);

            if (request.StakeholderKickoff != null)
                UpdateStakeholderKickoffTaskBuilder.Execute(request.StakeholderKickoff, transferTaskData);

            await _context.SaveChangesAsync();
        }
    }
}
