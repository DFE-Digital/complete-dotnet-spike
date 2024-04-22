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


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.EqualitiesAssessment
{
    public class EditEqualitiesAssessmentTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditEqualitiesAssessmentTaskModel> _logger;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name = "completed-the-equalities-process-record")]
        public bool? CompletedEqualitiesProcessRecord { get; set; }

        [BindProperty(Name = "saved-epr-in-workplaces-folder")]
        public bool? SavedEPRInWorkplacesFolder { get; set; }

        public string SchoolName { get; set; }

        public EditEqualitiesAssessmentTaskModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditEqualitiesAssessmentTaskModel> logger)
        {
            _getProjectService = getProjectService;
            _updateProjectTaskService = updateProjectTaskService;
            _logger = logger;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await LoadProject();
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.StatutoryConsultation);
            SchoolName = project.SchoolName;

            var request = new UpdateProjectByTaskRequest()
            {
                EqualitiesAssessment = new EqualitiesAssessmentTask()
                {
                    CompletedEqualitiesProcessRecord = CompletedEqualitiesProcessRecord,
                    SavedEPRInWorkplacesFolder = SavedEPRInWorkplacesFolder,
                }
            };

            await _updateProjectTaskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.ViewEqualitiesAssessmentTask, ProjectId));
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.EqualitiesAssessment);

            CompletedEqualitiesProcessRecord = project.EqualitiesAssessment.CompletedEqualitiesProcessRecord;
            SavedEPRInWorkplacesFolder = project.EqualitiesAssessment.SavedEPRInWorkplacesFolder;

            SchoolName = project.SchoolName;
        }
    }
}
