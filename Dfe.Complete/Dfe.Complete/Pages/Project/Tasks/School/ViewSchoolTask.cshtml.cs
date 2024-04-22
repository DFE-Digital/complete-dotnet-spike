using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Services.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.School
{
    public class ViewSchoolTask : ViewTaskBaseModel
    {
        private readonly ILogger<ViewSchoolTask> _logger;

        public ViewSchoolTask(
            IGetProjectByTaskService getProjectService,
            ILogger<ViewSchoolTask> logger,
            IGetTaskStatusService getTaskStatusService, 
            IUpdateTaskStatusService updateTaskStatusService) : base(getProjectService, getTaskStatusService, updateTaskStatusService)
        {
            _logger = logger;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await GetTask(TaskName.School);

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            _logger.LogMethodEntered();

            await PostTask(TaskName.School);

            return Redirect(string.Format(RouteConstants.TaskList, ProjectId));
        }
    }
}