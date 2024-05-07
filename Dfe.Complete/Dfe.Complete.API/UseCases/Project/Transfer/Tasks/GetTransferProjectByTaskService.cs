using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Exceptions;
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
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId && p.Type == ProjectType.Transfer);

            if (project == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var transferTaskData = await _context.TransferTasksData.FirstOrDefaultAsync(t => t.Id == project.TasksDataId);

            if (transferTaskData == null)
            {
                transferTaskData = new Data.Entities.TransferTasksData();
            }

            GetTransferProjectByTaskResponse response = new GetTransferProjectByTaskResponse();

            switch (taskName)
            {
                case TransferProjectTaskName.HandoverWithDeliveryOfficer:
                    response.HandoverWithRegionalDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(transferTaskData);
                    break;

                default:
                    throw new ArgumentException($"Unknown project transfer task name {taskName}");
            }

            return response;
        }
    }
}
