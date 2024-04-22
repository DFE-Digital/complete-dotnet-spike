using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Validators;
using Dfe.ManageFreeSchoolProjects.Constants;
using System.ComponentModel;
using System.Linq;
using DocumentFormat.OpenXml.Vml.Spreadsheet;


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.FinalFinancePlan
{
    public class EditFinalFinancePlanTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditFinalFinancePlanTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }


        [BindProperty(Name = "confirmed-trust-has-provided-final-plan")]
        [DisplayName("Confirmed that the trust has provided the final finance plan")]
        public bool? ConfirmedTrustHasProvidedFinalPlan { get; set; }

        [BindProperty(Name = "grade-6-signed-off-final-plan-date", BinderType = typeof(DateInputModelBinder))]
        [DisplayName("Date that the Grade 6 signed-off the final plan")]
        public DateTime? Grade6SignedOffFinalPlanDate { get; set; }

        [BindProperty(Name = "sent-final-plan-to-revenue-funding-mailbox")]
        [DisplayName("Sent the final plan to the Revenue Funding mailbox")]
        public bool? SentFinalPlanToRevenueFundingMailbox { get; set; }

        [BindProperty(Name = "saved-final-plan-in-workplaces-folder")]
        [DisplayName("Saved final plan in Workplaces folder")]
        public bool? SavedFinalPlanInWorkplacesFolder { get; set; }

        [BindProperty]
        public string SchoolName { get; set; }

        public EditFinalFinancePlanTaskModel(
            IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditFinalFinancePlanTaskModel> logger,
            ErrorService errorService)
        {
            _getProjectService = getProjectService;
            _updateProjectTaskService = updateProjectTaskService;
            _logger = logger;
            _errorService = errorService;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await LoadProject();
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            var updateTaskRequest = new UpdateProjectByTaskRequest()
            {
                FinalFinancePlan = new()
                {
                    ConfirmedTrustHasProvidedFinalPlan = ConfirmedTrustHasProvidedFinalPlan,
                    Grade6SignedOffFinalPlanDate = Grade6SignedOffFinalPlanDate,
                    SentFinalPlanToRevenueFundingMailbox = SentFinalPlanToRevenueFundingMailbox,
                    SavedFinalPlanInWorkplacesFolder = SavedFinalPlanInWorkplacesFolder
                }
            };

            await _updateProjectTaskService.Execute(ProjectId, updateTaskRequest);

            return Redirect(string.Format(RouteConstants.ViewFinalFinancePlanTask, ProjectId));
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.FinalFinancePlan);

            ConfirmedTrustHasProvidedFinalPlan = project.FinalFinancePlan.ConfirmedTrustHasProvidedFinalPlan;
            Grade6SignedOffFinalPlanDate = project.FinalFinancePlan.Grade6SignedOffFinalPlanDate;
            SentFinalPlanToRevenueFundingMailbox = project.FinalFinancePlan.SentFinalPlanToRevenueFundingMailbox;
            SavedFinalPlanInWorkplacesFolder = project.FinalFinancePlan.SavedFinalPlanInWorkplacesFolder;


            SchoolName = project.SchoolName;
        }

    }
}
