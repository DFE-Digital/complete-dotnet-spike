using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff;
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
        private readonly ISetProjectSchoolNameService _setProjectSchoolNameService;

        public GetTransferProjectByTaskService(
            CompleteContext context,
            ISetProjectSchoolNameService setProjectSchoolNameService)
        {
            _context = context;
            _setProjectSchoolNameService = setProjectSchoolNameService;
        }

        public async Task<GetTransferProjectByTaskResponse> Execute(Guid projectId, TransferProjectTaskName taskName)
        {
            var queryResult = await _context.GetTransferProjects(projectId).FirstOrDefaultAsync();

            if (queryResult == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var transferTaskData = await _context.TransferTasksData.FirstOrDefaultAsync(t => t.Id == queryResult.Project.TasksDataId);

            if (transferTaskData == null)
            {
                transferTaskData = new Data.Entities.TransferTasksData();
            }

            GetTransferProjectByTaskResponse response = new GetTransferProjectByTaskResponse()
            {
                Urn = queryResult.Project.Urn,
                SchoolName = queryResult.Establishment?.Name,
            };

            await _setProjectSchoolNameService.Execute(response);

            switch (taskName)
            {
                case TransferProjectTaskName.HandoverWithDeliveryOfficer:
                    response.HandoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(transferTaskData);
                    break;

                case TransferProjectTaskName.StakeholderKickoff:
                    response.StakeholderKickoff = StakeholderKickoffTaskBuilder.Execute(transferTaskData);
                    break;

                default:
                    throw new ArgumentException($"Unknown project transfer task name {taskName}");
            }

            return response;
        }
    }
}
