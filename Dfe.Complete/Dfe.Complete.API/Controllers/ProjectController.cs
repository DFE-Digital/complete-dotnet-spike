using Dfe.Complete.API.Contracts.Common;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.ResponseModels;
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
            Guid? userId,
            ProjectStatusQueryParameter? status,
            int? page = 1,
            int? count = 5)
        {
            var parameters = new GetProjectListServiceParameters()
            {
                Status = status,
                UserId = userId,
                Page = page.Value,
                Count = count.Value
            };

            var (projects, recordCount) = await _getProjectListService.Execute(parameters);

            PagingResponse pagingResponse = BuildPaginationResponse(recordCount, page, count);

            var response = new ApiListWrapper<ProjectListEntryResponse>(projects, pagingResponse);

            return response;
        }

        private PagingResponse BuildPaginationResponse(int recordCount, int? page, int? count)
        {
            PagingResponse result = PagingResponseFactory.Create(page.Value, count.Value, recordCount, Request);

            return result;
        }
    }
}
