using Azure;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.UseCases.Project.Transfer.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.Complete.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/projects/{projectId}/transfer/tasks")]
    [ApiController]
    public class TransferProjectTaskController : ControllerBase
    {
        private readonly IUpdateTransferProjectByTaskService _updateTransferProjectByTaskService;
        private readonly IGetTransferProjectByTaskService _getTransferProjectByTaskService;

        public TransferProjectTaskController(
            IUpdateTransferProjectByTaskService updateTransferProjectByTaskService,
            IGetTransferProjectByTaskService getTransferProjectByTaskService)
        {
            _updateTransferProjectByTaskService = updateTransferProjectByTaskService;
            _getTransferProjectByTaskService = getTransferProjectByTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<GetTransferProjectByTaskResponse>> GetTransferTasks(Guid projectId, TransferProjectTaskName taskName)
        {
            var result = await _getTransferProjectByTaskService.Execute(projectId, taskName);

            return new OkObjectResult(result);
        }

        [HttpPatch]
        public async Task<ActionResult<GetTransferProjectByTaskResponse>> UpdateTransferTasks(
            Guid projectId,
            UpdateTransferProjectByTaskRequest request)
        {
            await _updateTransferProjectByTaskService.Execute(projectId, request);

            return new OkResult();
        }
    }
}
