using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Dashboard;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/local-authorities")]
    [ApiController]
    public class LocalAuthorityController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IGetLocalAuthoritiesService _getLocalAuthoritiesService;

        public LocalAuthorityController(
            IGetLocalAuthoritiesService getLocalAuthoritiesService,
            ILogger<ProjectController> logger) 
        {
            _getLocalAuthoritiesService = getLocalAuthoritiesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ApiSingleResponseV2<GetLocalAuthoritiesResponse>> Get([FromQuery(Name = "regions")]string regionQuery) 
        {
            _logger.LogMethodEntered();

            var regions = new List<string>();

            if (regionQuery != null)
            {
                regions = regionQuery.Split(",").ToList();
            }

            var response = await _getLocalAuthoritiesService.Execute(regions);

            var localAuthorityCount = response.Regions.Sum(regionResponse => regionResponse.LocalAuthorities.Count);

            _logger.LogInformation("Found {count} local authorities for region(s) {region}", localAuthorityCount, string.Join(",", regionQuery));

            var result = new ApiSingleResponseV2<GetLocalAuthoritiesResponse>(response);

            return result;
        }
    }
}
