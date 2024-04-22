using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Task;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Services.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Bson;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks
{
    public class ViewTaskBaseModel : PageModel
    {
        protected readonly IGetProjectByTaskService _getProjectService;
        protected readonly IGetTaskStatusService _getTaskStatusService;
        protected readonly IUpdateTaskStatusService _updateTaskStatusService;

        public ProjectTaskStatus ProjectTaskStatus { get; set; }

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name = "mark-as-completed")]
        public bool MarkAsCompleted { get; set; }

        public GetProjectByTaskResponse Project { get; set; }

        public ViewTaskBaseModel(
            IGetProjectByTaskService getProjectService,
            IGetTaskStatusService getTaskStatusService, 
            IUpdateTaskStatusService updateTaskStatusService)
        {
            _getTaskStatusService = getTaskStatusService;
            _updateTaskStatusService = updateTaskStatusService;
            _getProjectService = getProjectService;
        }

        protected async Task GetTask(TaskName taskName)
        {
            Project = await _getProjectService.Execute(ProjectId, taskName);

            var taskStatusResponse = await _getTaskStatusService.Execute(ProjectId, taskName.ToString());

            ProjectTaskStatus = taskStatusResponse.ProjectTaskStatus;
            MarkAsCompleted = ProjectTaskStatus == ProjectTaskStatus.Completed;
        }

        protected async Task PostTask(TaskName taskName)
        {
            ProjectTaskStatus = MarkAsCompleted ? ProjectTaskStatus.Completed : ProjectTaskStatus.InProgress;

            await _updateTaskStatusService.Execute(ProjectId, new UpdateTaskStatusRequest
            {
                TaskName = taskName.ToString(),
                ProjectTaskStatus = ProjectTaskStatus
            });
        }
    }
}
