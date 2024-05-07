using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Transfer.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Transfer
{
    public interface IGetTransferProjectByTaskSummaryService
    {
        Task<GetTransferProjectByTaskSummaryResponse> Execute(Guid projectId);
    }

    public class GetTransferProjectByTaskSummaryService : IGetTransferProjectByTaskSummaryService
    {
        private readonly CompleteContext _context;

        public GetTransferProjectByTaskSummaryService(CompleteContext context)
        {
            _context = context;
        }

        public async Task<GetTransferProjectByTaskSummaryResponse> Execute(Guid projectId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId && p.Type == ProjectType.Transfer);

            if (project == null)
            {
                throw new NotFoundException($"Project with project id {projectId} not found");
            }

            var transferTasks = await _context.TransferTasksData
                .Where(t => t.Id == project.TasksDataId)
                .FirstOrDefaultAsync();

            if (transferTasks == null)
            {
                transferTasks = new TransferTasksData();
            }

            var handoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(transferTasks);

            var result = new GetTransferProjectByTaskSummaryResponse
            {
                HandoverWithDeliveryOfficer = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(handoverWithDeliveryOfficer),
                }
            };

            return result;
        }
    }
}
