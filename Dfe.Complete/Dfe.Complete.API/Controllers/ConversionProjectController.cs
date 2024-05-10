using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Conversion;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.Complete.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/conversion-projects/{projectId}")]
    [Tags("Conversion Project (Client only)")]
    [ApiController]
    public class ClientConversionProjectController : ControllerBase
    {
        private readonly IUpdateConversionProjectByTaskService _updateConversionProjectByTaskService;
        private readonly IGetConversionProjectByTaskService _getConversionProjectByTaskService;
        private readonly IGetConversionProjectByTaskSummaryService _getConversionProjectByTaskSummaryService;

        public ClientConversionProjectController(
            IUpdateConversionProjectByTaskService updateConversionProjectByTaskService,
            IGetConversionProjectByTaskService getConversionProjectByTaskService,
            IGetConversionProjectByTaskSummaryService getConversionProjectByTaskSummaryService)
        {
            _updateConversionProjectByTaskService = updateConversionProjectByTaskService;
            _getConversionProjectByTaskService = getConversionProjectByTaskService;
            _getConversionProjectByTaskSummaryService = getConversionProjectByTaskSummaryService;
        }

        [HttpGet]
        [Route("tasks/summary")]
        public async Task<ActionResult<GetConversionProjectByTaskSummaryResponse>> GetTaskListSummary(Guid projectId)
        {
            var result = await _getConversionProjectByTaskSummaryService.Execute(projectId);

            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<ActionResult<GetConversionProjectByTaskResponse>> GetTask(Guid projectId, ConversionProjectTaskName taskName)
        {
            var result = await _getConversionProjectByTaskService.Execute(projectId, taskName);

            return new OkObjectResult(result);
        }

        [HttpPatch]
        [Route("tasks")]
        public async Task<ActionResult<GetConversionProjectByTaskResponse>> UpdateTask(
            Guid projectId,
            UpdateConversionProjectByTaskRequest request)
        {
            await _updateConversionProjectByTaskService.Execute(projectId, request);

            return new OkResult();
        }
    }

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/conversion-projects")]
    [Tags("Conversion Project")]
    [ApiController]
    public class ConversionProjectController
    {
        private readonly ICreateConversionProjectService _createConversionProjectService;

        public ConversionProjectController(ICreateConversionProjectService createConversionProjectService)
        {
            _createConversionProjectService = createConversionProjectService;
        }

        [HttpPost]
        public async Task<ActionResult<GetConversionProjectByTaskSummaryResponse>> AddTransferProject(CreateConversionProjectRequest request)
        {
            var result = await _createConversionProjectService.Execute(request);

            return new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
