using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
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
        private readonly IEnumerable<IUpdateTransferTaskService> _updateTaskServices;

        public UpdateTransferProjectByTaskService(
            CompleteContext context,
            IEnumerable<IUpdateTransferTaskService> updateTransferTaskServices)
        {
            _context = context;
            _updateTaskServices = updateTransferTaskServices;
        }

        public async Task Execute(Guid projectId, UpdateTransferProjectByTaskRequest request)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);

            var transferTaskData = await _context.TransferTasksData.FirstOrDefaultAsync(t => t.Id == project.TasksDataId);

            var updateTaskParameters = new UpdateTransferTaskServiceParameters
            {
                Request = request
            };

            foreach (var updateTaskService in _updateTaskServices)
            {
                updateTaskService.Execute(updateTaskParameters);
            }

            await _context.SaveChangesAsync();
        }
    }
}
