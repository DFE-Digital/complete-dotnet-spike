using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [Route("api/v{version:apiVersion}/client/projects/{projectId}/tasks")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly IGetProjectByTaskService _getProjectByTaskService;
        private readonly IGetTasksService _getTasksService;
        private readonly ILogger<ProjectTaskController> _logger;

        public ProjectTaskController(
            IUpdateProjectByTaskService updateProjectTaskService,
            IGetProjectByTaskService getProjectByTaskService,
            IGetTasksService getTasksService,
            ILogger<ProjectTaskController> logger)
        {
            _updateProjectTaskService = updateProjectTaskService;
            _getProjectByTaskService = getProjectByTaskService;
            _getTasksService = getTasksService;
            _logger = logger;
        }

        [HttpPatch]
        public async Task<ActionResult> PatchTask(string projectId, UpdateProjectByTaskRequest request)
        {
            _logger.LogMethodEntered();

            await _updateProjectTaskService.Execute(projectId, request);

            return new OkResult();
        }

        [HttpGet]
        [Route("{taskName}")]
        public async Task<ActionResult<ApiSingleResponseV2<GetProjectByTaskResponse>>> GetProjectByTask(string projectId, TaskName taskName)
        {
            _logger.LogMethodEntered();

            var projectByTask = await _getProjectByTaskService.Execute(projectId, taskName);

            if (projectByTask == null)
            {
                _logger.LogInformation("No project could be found for the given project id {projectId}", projectId);
                return new NotFoundResult();
            }

            var result = new ApiSingleResponseV2<GetProjectByTaskResponse>(projectByTask);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet]
        [Route("summary")]
        public async Task<ActionResult<ApiSingleResponseV2<ProjectByTaskSummaryResponse>>> GetProjectTaskListSummary(
            string projectId)
        {
            _logger.LogMethodEntered();

            var summary = await _getTasksService.Execute(projectId);
           
            var response = new ApiSingleResponseV2<ProjectByTaskSummaryResponse>(summary);

            return new ObjectResult(response) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
