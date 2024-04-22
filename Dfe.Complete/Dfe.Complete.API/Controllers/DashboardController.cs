using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Dashboard;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IGetDashboardService _getDashboard;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(
            IGetDashboardService getDashboardAll,
            ILogger<DashboardController> logger)
        {
            _getDashboard = getDashboardAll;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponseV2<GetDashboardResponse>>> GetAllProjects(
            string userId,
            string regions,
            string localAuthorities,
            string project,
            string projectManagedBy,
            int? page = 1,
            int? count = 5)
        {
            _logger.LogMethodEntered();

            var regionsToSearch = regions?.Split(',').ToList() ?? new List<string>();
            var localAuthoritiesToSearch = localAuthorities?.Split(',').ToList() ?? new List<string>();
            var projectManagedByToSearch = projectManagedBy?.Split(",").ToList() ?? new List<string>();

            var parameters = new GetDashboardParameters()
            {
                UserId = userId,
                Regions = regionsToSearch,
                Project = project,
                ProjectManagedBy = projectManagedByToSearch,
                LocalAuthority = localAuthoritiesToSearch,
                Page = page.Value,
                Count = count.Value
            };

            var (projects, recordCount) = await _getDashboard.Execute(parameters);

            PagingResponse pagingResponse = BuildPaginationResponse(recordCount, page, count);

            var response = new ApiResponseV2<GetDashboardResponse>(projects, pagingResponse);

            _logger.LogInformation("Found {ProjectCount} projects", projects.Count);

            return Ok(response);
        }

        private PagingResponse BuildPaginationResponse(int recordCount, int? page = null, int? count = null)
        {
            PagingResponse result = null;

            if (page.HasValue && count.HasValue)
                result = PagingResponseFactory.Create(page.Value, count.Value, recordCount, Request);

            return result;
        }
    }
}
