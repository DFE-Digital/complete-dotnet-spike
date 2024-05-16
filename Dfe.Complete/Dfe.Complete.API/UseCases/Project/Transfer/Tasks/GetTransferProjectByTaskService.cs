using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff;
using Dfe.Complete.Data;

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
            var queryResult = await _context.GetTransferProjectById(projectId);
            var project = queryResult.Project;
            var transferTaskData = queryResult.TaskData;

            GetTransferProjectByTaskResponse response = new GetTransferProjectByTaskResponse()
            {
                Urn = project.Urn,
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
