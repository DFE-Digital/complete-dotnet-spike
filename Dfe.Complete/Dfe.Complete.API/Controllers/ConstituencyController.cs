using Dfe.ManageFreeSchoolProjects.API.Contracts.Constituency;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Constituency;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/constituency")]
    [ApiController]
    public class ConstituencyController : ControllerBase
    {
        private readonly ISearchConstituencyService _searchConstituencyService;
        private readonly ILogger<ConstituencyController> _logger;

        public ConstituencyController(
            ISearchConstituencyService searchConstituencyServicee,
            ILogger<ConstituencyController> logger)
        {
            _searchConstituencyService = searchConstituencyServicee;
            _logger = logger;
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<ApiSingleResponseV2<GetSearchConstituencyResponse>>> searchConstituency(string searchTerm)
        {
            _logger.LogMethodEntered();

            if(string.IsNullOrEmpty(searchTerm)) 
            {
                return BadRequest("SearchTerm is required.");
            }

            var constituencies  = await _searchConstituencyService.Execute(searchTerm);

            var result = new ApiSingleResponseV2<GetSearchConstituencyResponse>(constituencies);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
