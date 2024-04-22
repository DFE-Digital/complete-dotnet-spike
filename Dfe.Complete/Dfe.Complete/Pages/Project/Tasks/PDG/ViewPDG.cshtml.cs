using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Services.Tasks;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.PDG
{
    public class ViewPDGModel : ViewTaskBaseModel
    {
        private readonly ILogger<ViewPDGModel> _logger;

        public ViewPDGModel(
            ILogger<ViewPDGModel> logger,
            IGetProjectByTaskService getProjectService, 
            IGetTaskStatusService getTaskStatusService, 
            IUpdateTaskStatusService updateTaskStatusService) : base(getProjectService, getTaskStatusService, updateTaskStatusService)
        {
            _logger = logger;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await GetTask(TaskName.PDG);

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            _logger.LogMethodEntered();

            await PostTask(TaskName.PDG);

            return Redirect(string.Format(RouteConstants.TaskList, ProjectId));
        }
    }
}
