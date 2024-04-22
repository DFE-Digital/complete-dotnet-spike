using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

using System.Threading.Tasks;


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.EducationBrief
{
    public class EditEducationBriefTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditEducationBriefTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
        
        [BindProperty(Name = "education-plan-in-brief")]
        public bool? EducationPlanInBrief { get; set; }
        
        [BindProperty(Name = "education-policies-in-brief")]
        
        public bool? EducationPoliciesInBrief { get; set; }
        
        [BindProperty(Name = "pupil-assessment-and-tracking-history")]
        
        public bool? PupilAssessmentAndTrackingHistory { get; set; }
        
        [BindProperty(Name = "saved-in-workplaces")]
        
        public bool? SavedInWorkPlaces { get; set; }
        public string SchoolName { get; set; }

        public EditEducationBriefTaskModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditEducationBriefTaskModel> logger,
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
            var project = await _getProjectService.Execute(ProjectId, TaskName.EducationBrief);
            SchoolName = project.SchoolName;

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            try
            {
                var request = new UpdateProjectByTaskRequest()
                {
                    EducationBrief = new EducationBriefTask()
                    {
                        EducationPlanInEducationBrief = EducationPlanInBrief,
                        EducationPolicesInEducationBrief = EducationPoliciesInBrief,
                        PupilAssessmentAndTrackingHistoryInPlace = PupilAssessmentAndTrackingHistory,
                        EducationBriefSavedToWorkplaces = SavedInWorkPlaces
                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);
                return Redirect(string.Format(RouteConstants.ViewEducationBriefTask, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.EducationBrief);

            EducationPlanInBrief = project.EducationBrief.EducationPlanInEducationBrief;
            EducationPoliciesInBrief = project.EducationBrief.EducationPolicesInEducationBrief;
            PupilAssessmentAndTrackingHistory = project.EducationBrief.PupilAssessmentAndTrackingHistoryInPlace;
            SavedInWorkPlaces = project.EducationBrief.EducationBriefSavedToWorkplaces;
           
            SchoolName = project.SchoolName;
        }
    }
}
