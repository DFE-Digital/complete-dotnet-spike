using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Tasks;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks
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
            var queryResult = await _context.GetTransferProjects(projectId).FirstOrDefaultAsync();

            if (queryResult == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var transferTasks = await _context.TransferTasksData
                .Where(t => t.Id == queryResult.Project.TasksDataId)
                .FirstOrDefaultAsync();

            if (transferTasks == null)
            {
                transferTasks = new TransferTasksData();
            }

            var handoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(transferTasks);
            var stakeholderKickoff = StakeholderKickoffTaskBuilder.Execute(transferTasks);

            var result = new GetTransferProjectByTaskSummaryResponse
            {
                HandoverWithDeliveryOfficer = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(handoverWithDeliveryOfficer),
                },
                StakeholderKickoff = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(stakeholderKickoff),
                },
            };

            return result;
        }
    }
}
