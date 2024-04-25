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
        public async Task<ActionResult<ApiListWrapper<ProjectListEntryResponse>>> GetProjectList(
            ProjectStatusQueryParameter? status)
        {
            var parameters = new GetProjectListServiceParameters()
            {
                Status = status
            };

            var projects = await _getProjectListService.Execute(parameters);

            var response = new ApiListWrapper<ProjectListEntryResponse>(projects, null);

            return response;
        }
    }
}
