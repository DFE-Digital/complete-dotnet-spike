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
        private readonly IGetProjectDetailsService _getProjectDetailsService;

        public GetTransferProjectByTaskSummaryService(
            CompleteContext context,
            IGetProjectDetailsService getProjectDetailsService)
        {
            _context = context;
            _getProjectDetailsService = getProjectDetailsService;
        }

        public async Task<GetTransferProjectByTaskSummaryResponse> Execute(Guid projectId)
        {
            var project = await _context.GetTransferProjects(projectId).FirstOrDefaultAsync();

            if (project == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var transferTasks = await _context.TransferTasksData
                .Where(t => t.Id == project.TasksDataId)
                .FirstOrDefaultAsync();

            if (transferTasks == null)
            {
                transferTasks = new TransferTasksData();
            }

            var handoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(transferTasks);
            var stakeholderKickoff = StakeholderKickoffTaskBuilder.Execute(transferTasks);
            var projectDetails = await _getProjectDetailsService.Execute(project);

            var result = new GetTransferProjectByTaskSummaryResponse
            {
                ProjectDetails = projectDetails,
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
