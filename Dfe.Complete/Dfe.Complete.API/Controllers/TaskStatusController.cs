using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Task;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers;

[Route("api/v{version:apiVersion}/{projectId}/task/status")]
[ApiController]
public class TaskStatusController : ControllerBase
{
    private readonly IUpdateTaskStatusService _updateTaskStatusService;
    private readonly IGetTaskStatusService _getTaskStatusService;
    private readonly ILogger<TaskStatusController> _logger;
    private readonly ICreateTasksService _createTasksService;

    public TaskStatusController(IUpdateTaskStatusService updateTaskStatusService, ILogger<TaskStatusController> logger,
        IGetTaskStatusService getTaskStatusService, ICreateTasksService createTasksService)
    {
        _updateTaskStatusService = updateTaskStatusService;
        _getTaskStatusService = getTaskStatusService;
        _createTasksService = createTasksService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ApiSingleResponseV2<TaskStatusResponse>>> GetTaskStatus([FromRoute] string projectId,
        string taskName)
    {
        _logger.LogMethodEntered();

        try
        {
            if (string.IsNullOrEmpty(taskName))
                return BadRequest("Task name required.");

            var existingStatus = await _getTaskStatusService.Execute(projectId, taskName);

            var response = new TaskStatusResponse { ProjectTaskStatus = existingStatus };

            return new ObjectResult(new ApiSingleResponseV2<TaskStatusResponse>(response))
                { StatusCode = StatusCodes.Status200OK };
        }
        catch (InvalidOperationException ex) when (ex.InnerException is NullReferenceException)
        {
            _logger.LogErrorMsg(ex);

            return new ObjectResult(new ApiSingleResponseV2<TaskStatusResponse>(null))
                { StatusCode = StatusCodes.Status404NotFound };
        }
        catch (Exception e)
        {
            _logger.LogErrorMsg(e);

            return new ObjectResult(new ApiSingleResponseV2<TaskStatusResponse>(null))
                { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateTaskStatus(string projectId, [FromBody] UpdateTaskStatusRequest request)
    {
        _logger.LogMethodEntered();

        try
        {
            await _updateTaskStatusService.Execute(projectId, request.TaskName, request.ProjectTaskStatus);
        }
        catch (Exception e)
        {
            _logger.LogErrorMsg(e);
            return StatusCode(500);
        }

        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> CreateTasks([FromRoute] string projectId)
    {
        _logger.LogMethodEntered();

        await _createTasksService.Execute(projectId);

        return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };
    }
}