using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Services.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Logging;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.ApplicationsEvidence
{
    public class ViewApplicationsEvidenceModel : ViewTaskBaseModel
    {
        private readonly ILogger<ViewApplicationsEvidenceModel> _logger;

        public ViewApplicationsEvidenceModel(
            IGetProjectByTaskService getProjectService,
            ILogger<ViewApplicationsEvidenceModel> logger,
            IGetTaskStatusService getTaskStatusService, IUpdateTaskStatusService updateTaskStatusService) : base(getProjectService, getTaskStatusService, updateTaskStatusService)
        {
            _logger = logger;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await GetTask(TaskName.ApplicationsEvidence);

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            _logger.LogMethodEntered();

            await PostTask(TaskName.ApplicationsEvidence);

            return Redirect(string.Format(RouteConstants.TaskList, ProjectId));
        }
    }
}
