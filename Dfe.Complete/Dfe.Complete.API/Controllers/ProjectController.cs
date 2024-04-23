using Dfe.Complete.API.Contracts.Common;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.UseCases.Project;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.Complete.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IGetProjectListService _getProjectListService;

        public ProjectController(IGetProjectListService getProjectListService)
        {
            _getProjectListService = getProjectListService;
        }

        [Route("list")]
        [HttpGet]
        public async Task<ActionResult<ApiResponseV2<ProjectListEntryResponse>>> GetProjectList()
        {
            var projects = await _getProjectListService.Execute();

            var response = new ApiResponseV2<ProjectListEntryResponse>(projects, null);

            return response;
        }
    }
}
