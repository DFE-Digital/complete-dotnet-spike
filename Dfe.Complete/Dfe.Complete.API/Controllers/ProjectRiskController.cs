using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Risk;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/projects/{projectId}/risk")]
    [ApiController]
    public class ProjectRiskController : ControllerBase
    {
        private readonly ICreateProjectRiskService _createProjectRiskService;
        private readonly IGetProjectRiskService _getProjectRiskService;
        private readonly ILogger<ProjectRiskController> _logger;
        private readonly CreateProjectRiskRequestValidator _createProjectRiskRequestValidator;

        public ProjectRiskController(
            ICreateProjectRiskService createProjectRiskService,
            IGetProjectRiskService getProjectRiskService,
            CreateProjectRiskRequestValidator createProjectRiskRequestValidator,
            ILogger<ProjectRiskController> logger)
        {
            _createProjectRiskService = createProjectRiskService;
            _getProjectRiskService = getProjectRiskService;
            _createProjectRiskRequestValidator = createProjectRiskRequestValidator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiSingleResponseV2<GetProjectRiskResponse>>> GetProjectRisk(string projectId, int entry = 1)
        {
            _logger.LogMethodEntered();

            var response = await _getProjectRiskService.Execute(projectId, entry);

            if (response == null)
            {
                response = new GetProjectRiskResponse();
            }

            return new ObjectResult(new ApiSingleResponseV2<GetProjectRiskResponse>(response))
            { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPost]
        public async Task<ActionResult<ApiSingleResponseV2<CreateProjectRiskResponse>>> PostProjectRisk(string projectId, CreateProjectRiskRequest request)
        {
            _logger.LogMethodEntered();

            var validationResult = _createProjectRiskRequestValidator.Validate(request);

            if (validationResult.IsValid == false)
            {
                return new BadRequestObjectResult(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            var response = await _createProjectRiskService.Execute(projectId, request);

            return new ObjectResult(new ApiSingleResponseV2<CreateProjectRiskResponse>(response))
            { StatusCode = StatusCodes.Status201Created };
        }
    }
}
