using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.ProjectOverview;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/projects/{projectId}/overview")]
    [ApiController]
    public class ProjectOverviewController : ControllerBase
    {
        private readonly IGetProjectOverviewService _getProjectOverviewService;
        private readonly ILogger<ProjectOverviewController> _logger;

        public ProjectOverviewController(
            IGetProjectOverviewService getProjectOverviewService,
            ILogger<ProjectOverviewController> logger)
        {
            _getProjectOverviewService = getProjectOverviewService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiSingleResponseV2<ProjectOverviewResponse>>> GetProjectOverview(string projectId)
        {
            _logger.LogMethodEntered();

            var overview = await _getProjectOverviewService.Execute(projectId);

            _logger.LogInformation("Returning overview for project {projectId}", projectId);

            var result = new ApiSingleResponseV2<ProjectOverviewResponse>(overview);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
