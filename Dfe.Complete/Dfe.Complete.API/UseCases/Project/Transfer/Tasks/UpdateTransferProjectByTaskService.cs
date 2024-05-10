using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Transfer.Tasks.HandoverWithDeliveryOfficer;
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
            var queryResult = await _context.GetTransferProjects(projectId).FirstOrDefaultAsync();

            if (queryResult == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var transferTaskData = await _context.TransferTasksData.FirstOrDefaultAsync(t => t.Id == queryResult.Project.TasksDataId);

            if (transferTaskData == null)
            {
                throw new UnprocessableContentException($"Project with id {projectId} does not have any transfer tasks data");
            }

            var updateTaskParameters = new UpdateTransferTaskServiceParameters
            {
                Request = request,
                TransferTasksData = transferTaskData
            };

            UpdateHandoverWithDeliveryOfficerTaskBuilder.Execute(updateTaskParameters);

            await _context.SaveChangesAsync();
        }
    }
}
