using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [Route("api/v{version:apiVersion}/client/trust")]
    [ApiController]
    public class TrustTaskController : ControllerBase
    {
        private readonly IGetTrustByRefService _getTrustByRefService;
        private readonly ISearchTrustByRefService _searchTrustByRefService;
        private readonly ILogger<TrustTaskController> _logger;

        public TrustTaskController(
            IGetTrustByRefService getTrustByRefService,
            ISearchTrustByRefService searchTrustByRefService,
            ILogger<TrustTaskController> logger)
        {
            _getTrustByRefService = getTrustByRefService;
            _searchTrustByRefService = searchTrustByRefService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{trn}")]
        public async Task<ActionResult<ApiSingleResponseV2<GetTrustByRefResponse>>> getTrustByRef(string trn)
        {
            _logger.LogMethodEntered();

            var trustByRef = await _getTrustByRefService.Execute(trn);

            if (trustByRef == null) 
            {
                _logger.LogInformation("No trust could be found for the given trust ref {trn}", trn);
                return new NotFoundResult();
            }

            var result = new ApiSingleResponseV2<GetTrustByRefResponse>(trustByRef);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet]
        [Route("search/{searchTerm}")]
        public async Task<ActionResult<ApiResponseV2<SearchTrustByRefResponse>>> searchTrustByRef( string searchTerm)
        {
            _logger.LogMethodEntered();

            var (trusts, recordCount) = await _searchTrustByRefService.Execute(searchTerm);

            if (trusts == null)
            {
                _logger.LogInformation("No trust could be found for the given search term", searchTerm);
                return new NotFoundResult();
            }

            PagingResponse pagingResponse = BuildPaginationResponse(recordCount, 1, 10);

            var result = new ApiResponseV2<SearchTrustByRefResponse>(trusts, pagingResponse);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
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
