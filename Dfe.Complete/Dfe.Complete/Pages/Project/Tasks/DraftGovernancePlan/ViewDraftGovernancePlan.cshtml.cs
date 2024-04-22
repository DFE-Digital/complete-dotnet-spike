using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Services.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.DraftGovernancePlan
{
    public class ViewDraftGovernancePlanModel : ViewTaskBaseModel
    {
        private readonly ILogger<ViewDraftGovernancePlanModel> _logger;
        private readonly IGetProjectRiskService _getProjectRiskService;

        public GetProjectRiskResponse ProjectRisk { get; set; }

        public ViewDraftGovernancePlanModel(
            IGetProjectByTaskService getProjectService,
            ILogger<ViewDraftGovernancePlanModel> logger,
            IGetTaskStatusService getTaskStatusService, IUpdateTaskStatusService updateTaskStatusService,
            IGetProjectRiskService getProjectRiskService) : base(getProjectService, getTaskStatusService, updateTaskStatusService)
        {
            _logger = logger;
            _getProjectRiskService = getProjectRiskService;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await GetTask(TaskName.DraftGovernancePlan);

            ProjectRisk = await _getProjectRiskService.Execute(ProjectId, 1);

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            _logger.LogMethodEntered();

            await PostTask(TaskName.DraftGovernancePlan);

            return Redirect(string.Format(RouteConstants.TaskList, ProjectId));
        }
    }
}
