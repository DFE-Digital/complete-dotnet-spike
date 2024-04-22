using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Services.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Logging;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.OfstedPreRegistration
{
    public class ViewOfstedPreRegistrationModel : ViewTaskBaseModel
    {
        private readonly ILogger<ViewOfstedPreRegistrationModel> _logger;

        public ViewOfstedPreRegistrationModel(
            IGetProjectByTaskService getProjectService,
            ILogger<ViewOfstedPreRegistrationModel> logger,
            IGetTaskStatusService getTaskStatusService, IUpdateTaskStatusService updateTaskStatusService) : base(getProjectService, getTaskStatusService, updateTaskStatusService)
        {
            _logger = logger;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await GetTask(TaskName.OfstedInspection);

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            _logger.LogMethodEntered();

            await PostTask(TaskName.OfstedInspection);

            return Redirect(string.Format(RouteConstants.TaskList, ProjectId));
        }
    }
}
