using Azure;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.UseCases.Project.Transfer;
using Dfe.Complete.API.UseCases.Project.Transfer.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.Complete.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/transfer-projects/{projectId}")]
    [Tags("Transfer Project (Client only)")]
    [ApiController]
    public class ClientTransferProjectController : ControllerBase
    {
        private readonly IUpdateTransferProjectByTaskService _updateTransferProjectByTaskService;
        private readonly IGetTransferProjectByTaskService _getTransferProjectByTaskService;
        private readonly IGetTransferProjectByTaskSummaryService _getTransferProjectByTaskSummaryService;
        private readonly IGetTransferProjectService _getTransferProjectService;

        public ClientTransferProjectController(
            IUpdateTransferProjectByTaskService updateTransferProjectByTaskService,
            IGetTransferProjectByTaskService getTransferProjectByTaskService,
            IGetTransferProjectByTaskSummaryService getTransferProjectByTaskSummaryService,
            IGetTransferProjectService getTransferProjectService)
        {
            _updateTransferProjectByTaskService = updateTransferProjectByTaskService;
            _getTransferProjectByTaskService = getTransferProjectByTaskService;
            _getTransferProjectByTaskSummaryService = getTransferProjectByTaskSummaryService;
            _getTransferProjectService = getTransferProjectService;
        }

        public async Task<ActionResult<GetTransferProjectResponse>> GetTransferProject(Guid projectId)
        {
            var result = await _getTransferProjectService.Execute(projectId);

            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("tasks/summary")]
        public async Task<ActionResult<GetTransferProjectByTaskSummaryResponse>> GetTaskListSummary(Guid projectId)
        {
            var result = await _getTransferProjectByTaskSummaryService.Execute(projectId);

            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<ActionResult<GetTransferProjectByTaskResponse>> GetTask(Guid projectId, TransferProjectTaskName taskName)
        {
            var result = await _getTransferProjectByTaskService.Execute(projectId, taskName);

            return new OkObjectResult(result);
        }

        [HttpPatch]
        [Route("tasks")]
        public async Task<ActionResult<GetTransferProjectByTaskResponse>> UpdateTask(
            Guid projectId,
            UpdateTransferProjectByTaskRequest request)
        {
            await _updateTransferProjectByTaskService.Execute(projectId, request);

            return new OkResult();
        }
    }

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/transfer-projects")]
    [Tags("Transfer Project")]
    [ApiController]
    public class TransferProjectController
    {
        private readonly ICreateTransferProjectService _createTransferProjectService;

        public TransferProjectController(ICreateTransferProjectService createTransferProjectService)
        {
            _createTransferProjectService = createTransferProjectService;
        }

        [HttpPost]
        public async Task<ActionResult<GetTransferProjectByTaskSummaryResponse>> AddTransferProject(CreateTransferProjectRequest request)
        {
            var result = await _createTransferProjectService.Execute(request);

            return new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
