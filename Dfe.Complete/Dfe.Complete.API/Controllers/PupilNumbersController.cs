using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers;
using Microsoft.AspNetCore.Mvc;
using Dfe.ManageFreeSchoolProjects.Logging;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/projects/{projectId}/pupil-numbers")]
    [ApiController]
    public class PupilNumbersController
    {
        private readonly IGetPupilNumbersService _getPupilNumbersService;
        private readonly IUpdatePupilNumbersService _updatePupilNumbersService;
        private readonly ILogger<PupilNumbersController> _logger;

        public PupilNumbersController(
            IGetPupilNumbersService getPupilNumbersService,
            IUpdatePupilNumbersService updatePupilNumbersService,
            ILogger<PupilNumbersController> logger)
        {
            _getPupilNumbersService = getPupilNumbersService;
            _updatePupilNumbersService = updatePupilNumbersService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiSingleResponseV2<GetPupilNumbersResponse>>> GetPupilNumbers(string projectId)
        {
            _logger.LogMethodEntered();

            var response = await _getPupilNumbersService.Execute(projectId);

            return new ObjectResult(new ApiSingleResponseV2<GetPupilNumbersResponse>(response))
            { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPatch]
        public async Task<ActionResult<ApiSingleResponseV2<object>>> PatchPupilNumbers(string projectId, UpdatePupilNumbersRequest request)
        {
            _logger.LogMethodEntered();

            await _updatePupilNumbersService.Execute(projectId, request);

            return new ObjectResult(new ApiSingleResponseV2<object>(new object()))
            { StatusCode = StatusCodes.Status200OK };
        }
    }
}
