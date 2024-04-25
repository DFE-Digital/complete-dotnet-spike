using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.UseCases.Project.Transfer.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks
{
    public interface IGetTransferProjectByTaskService
    {
        public Task<GetTransferProjectByTaskResponse> Execute(Guid projectId, TransferProjectTaskName taskName);
    }

    public class GetTransferProjectByTaskService : IGetTransferProjectByTaskService
    {
        private readonly CompleteContext _context;

        public GetTransferProjectByTaskService(CompleteContext context)
        {
            _context = context;
        }

        public async Task<GetTransferProjectByTaskResponse> Execute(Guid projectId, TransferProjectTaskName taskName)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);

            var transferTaskData = await _context.TransferTasksData.FirstOrDefaultAsync(t => t.Id == project.TasksDataId);

            var parameters = new GetTransferTaskServiceParameters
            {
                TransferTasksData = transferTaskData
            };

            GetTransferProjectByTaskResponse response = new GetTransferProjectByTaskResponse();

            switch (taskName)
            {
                case TransferProjectTaskName.HandoverWithDeliveryOfficer:
                    response.HandoverWithRegionalDeliveryOfficer = new GetHandoverWithDeliveryOfficerTaskService().Execute(parameters);
                    break;

                default:
                    throw new ArgumentException($"Unknown project transfer task name {taskName}");
            }

            return response;
        }
    }
}
