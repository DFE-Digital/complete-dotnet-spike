using Dfe.ManageFreeSchoolProjects.API.Contracts.Construct;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Construct;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/construct")]
    [ApiController]
    public class ConstructController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IGetConstructProjectListService _getProjectConstructService;

        public ConstructController(
            ILogger<ContactsController> logger,
            IGetConstructProjectListService getConstructProjectService)
        {
            _logger = logger;
            _getProjectConstructService = getConstructProjectService;
        }

        [HttpGet("projects")]
        public async Task<ActionResult<ApiResponseV2<ConstructProjectResponse>>> GetConstruct()
        {
            _logger.LogMethodEntered();

            var projects = await _getProjectConstructService.Execute();

            return new ObjectResult(new ApiResponseV2<ConstructProjectResponse>(projects, null))
            { 
                StatusCode = StatusCodes.Status200OK 
            };
        }
    }
}
