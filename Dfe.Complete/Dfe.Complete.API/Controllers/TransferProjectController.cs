using Azure;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.UseCases.Project.Transfer;
using Dfe.Complete.API.UseCases.Project.Transfer.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.Complete.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/projects/{projectId}/transfer")]
    [ApiController]
    public class TransferProjectController : ControllerBase
    {
        private readonly IUpdateTransferProjectByTaskService _updateTransferProjectByTaskService;
        private readonly IGetTransferProjectByTaskService _getTransferProjectByTaskService;
        private readonly IGetTransferProjectByTaskSummaryService _getTransferProjectByTaskSummaryService;

        public TransferProjectController(
            IUpdateTransferProjectByTaskService updateTransferProjectByTaskService,
            IGetTransferProjectByTaskService getTransferProjectByTaskService,
            IGetTransferProjectByTaskSummaryService getTransferProjectByTaskSummaryService)
        {
            _updateTransferProjectByTaskService = updateTransferProjectByTaskService;
            _getTransferProjectByTaskService = getTransferProjectByTaskService;
            _getTransferProjectByTaskSummaryService = getTransferProjectByTaskSummaryService;
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
}
