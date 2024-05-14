using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.StakeholderKickoff;
using Dfe.Complete.API.UseCases.Project.Tasks;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public interface IGetConversionProjectByTaskSummaryService
    {
        Task<GetConversionProjectByTaskSummaryResponse> Execute(Guid projectId);
    }

    public class GetConversionProjectByTaskSummaryService : IGetConversionProjectByTaskSummaryService
    {
        private readonly CompleteContext _context;
        private readonly IGetProjectDetailsService _getProjectDetailsService;


        public GetConversionProjectByTaskSummaryService(
            CompleteContext context,
            IGetProjectDetailsService getProjectDetailsService)
        {
            _context = context;
            _getProjectDetailsService = getProjectDetailsService;
        }

        public async Task<GetConversionProjectByTaskSummaryResponse> Execute(Guid projectId)
        {
            var project = await _context.GetConversionProjects(projectId).FirstOrDefaultAsync();

            if (project == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var conversionTasks = await _context.ConversionTasksData
                .Where(t => t.Id == project.TasksDataId)
                .FirstOrDefaultAsync();

            if (conversionTasks == null)
            {
                conversionTasks = new ConversionTasksData();
            }

            var handoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(conversionTasks);
            var stakeholderKickoff = ConversionStakeholderKickoffTaskBuilder.Execute(conversionTasks);
            var projectDetails = await _getProjectDetailsService.Execute(project);

            var result = new GetConversionProjectByTaskSummaryResponse
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
