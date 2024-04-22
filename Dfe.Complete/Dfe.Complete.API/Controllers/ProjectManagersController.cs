using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Dashboard;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/project-managers")]
    [ApiController]
    public class ProjectManagersController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IGetProjectManagersService _getProjectManagersService;

        public ProjectManagersController(
            IGetProjectManagersService getProjectManagersService,
            ILogger<ProjectController> logger)
        {
            _getProjectManagersService = getProjectManagersService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ApiSingleResponseV2<GetProjectManagersResponse>> Execute()
        {
            _logger.LogMethodEntered();

            var response = await _getProjectManagersService.Execute();

            _logger.LogInformation("Found {count} project managers", response.ProjectManagers.Count);

            var result = new ApiSingleResponseV2<GetProjectManagersResponse>(response);

            return result;
        }
    }
}
