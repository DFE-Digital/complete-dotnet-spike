using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.DraftGovernancePlan
{
    public class EditDraftGovernancePlanModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditDraftGovernancePlanModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name = "plan-received-from-trust")]
        public bool? PlanReceivedFromTrust { get; set; }

        [BindProperty(Name = "date-plan-received", BinderType = typeof(DateInputModelBinder))]
        [DisplayName("Date received")]
        public DateTime? DatePlanReceived { get; set; }

        [BindProperty(Name = "plan-assessed-using-template")]
        public bool? PlanAssessedUsingTemplate { get; set; }

        [BindProperty(Name = "plan-and-assessment-shared-with-expert")]
        public bool? PlanAndAssessmentSharedWithExpert { get; set; }

        [BindProperty(Name = "plan-and-assessment-shared-with-esfa")]
        public bool? PlanAndAssessmentSharedWithEsfa { get; set; }

        [BindProperty(Name = "plan-fed-back-to-trust")]
        public bool? PlanFedBackToTrust { get; set; }

        [BindProperty(Name = "saved-documents-in-workplaces-folder")]
        public bool? SavedDocumentsInWorkplacesFolder { get; set; }

        [BindProperty(Name = "comments")]
        [DisplayName("Comments")]
        [ValidText(999)]
        public string Comments { get; set; }

        [BindProperty]
        public string SchoolName { get; set; }

        public EditDraftGovernancePlanModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditDraftGovernancePlanModel> logger,
            ErrorService errorService)
        {
            _getProjectService = getProjectService;
            _updateProjectTaskService = updateProjectTaskService;
            _logger = logger;
            _errorService = errorService;
        }

        public async Task<IActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await LoadProject();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (PlanReceivedFromTrust != true)
            {
                var errorKeys = ModelState.Keys.Where(k => k.StartsWith("date-plan-received")).ToList();

                errorKeys.ForEach(k => ModelState.Remove(k));

                DatePlanReceived = null;
            }

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            var updateTaskRequest = new UpdateProjectByTaskRequest()
            {
                DraftGovernancePlan = new()
                {
                    PlanReceivedFromTrust = PlanReceivedFromTrust,
                    DatePlanReceived = DatePlanReceived,
                    PlanAssessedUsingTemplate = PlanAssessedUsingTemplate,
                    PlanAndAssessmentSharedWithExpert = PlanAndAssessmentSharedWithExpert,
                    PlanAndAssessmentSharedWithEsfa = PlanAndAssessmentSharedWithEsfa,
                    PlanFedBackToTrust = PlanFedBackToTrust,
                    SavedDocumentsInWorkplacesFolder = SavedDocumentsInWorkplacesFolder,
                    Comments = Comments
                }
            };

            await _updateProjectTaskService.Execute(ProjectId, updateTaskRequest);

            return Redirect(string.Format(RouteConstants.ViewDraftGovernancePlanTask, ProjectId));
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.DraftGovernancePlan);

            PlanReceivedFromTrust = project.DraftGovernancePlan.PlanReceivedFromTrust;
            DatePlanReceived = project.DraftGovernancePlan.DatePlanReceived;
            PlanAssessedUsingTemplate = project.DraftGovernancePlan.PlanAssessedUsingTemplate;
            PlanAndAssessmentSharedWithExpert = project.DraftGovernancePlan.PlanAndAssessmentSharedWithExpert;
            PlanAndAssessmentSharedWithEsfa = project.DraftGovernancePlan.PlanAndAssessmentSharedWithEsfa;
            PlanFedBackToTrust = project.DraftGovernancePlan.PlanFedBackToTrust;
            SavedDocumentsInWorkplacesFolder = project.DraftGovernancePlan.SavedDocumentsInWorkplacesFolder;
            Comments = project.DraftGovernancePlan.Comments;

            SchoolName = project.SchoolName;
        }
    }
}
