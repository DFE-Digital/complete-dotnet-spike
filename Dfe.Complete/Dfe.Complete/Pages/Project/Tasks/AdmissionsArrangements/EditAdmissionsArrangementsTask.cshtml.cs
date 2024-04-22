using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Models;


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.AdmissionsArrangements
{
    public class EditAdmissionsArrangementsTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditAdmissionsArrangementsTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
        
        [BindProperty(Name = "trust-confirmed-admissions-arrangements-template")]
        
        public bool? TrustConfirmedAdmissionsArrangementsTemplate{ get; set; }
        
        [BindProperty(Name = "trust-confirmed-admissions-arrangements-policies")]
        
        public bool? TrustConfirmedAdmissionsArrangementsPolicies { get; set; }
        
        [BindProperty(Name = "saved-to-workplaces")]
        
        public bool? SavedToWorkplaces { get; set; }
        
        [BindProperty(Name = "admissions-arrangements-confirmed-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Admissions arrangements confirmed date")]
        public DateTime? AdmissionsArrangementsConfirmedDate{ get; set; }
        public string SchoolName { get; set; }

        public EditAdmissionsArrangementsTaskModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditAdmissionsArrangementsTaskModel> logger,
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
            var project = await _getProjectService.Execute(ProjectId, TaskName.AdmissionsArrangements);
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
                    AdmissionsArrangements = new AdmissionsArrangementsTask()
                    {
                        TrustConfirmedAdmissionsArrangementsPolicies = TrustConfirmedAdmissionsArrangementsPolicies,
                        TrustConfirmedAdmissionsArrangementsTemplate = TrustConfirmedAdmissionsArrangementsTemplate,
                        SavedToWorkplaces = SavedToWorkplaces,
                        AdmissionsArrangementsConfirmedDate = AdmissionsArrangementsConfirmedDate
                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);
                return Redirect(string.Format(RouteConstants.ViewAdmissionsArrangementsTask, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.AdmissionsArrangements);

            TrustConfirmedAdmissionsArrangementsTemplate = project.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsTemplate;
            TrustConfirmedAdmissionsArrangementsPolicies = project.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsPolicies;
            SavedToWorkplaces = project.AdmissionsArrangements.SavedToWorkplaces;
            AdmissionsArrangementsConfirmedDate = project.AdmissionsArrangements.AdmissionsArrangementsConfirmedDate;
           
            SchoolName = project.SchoolName;
        }
    }
}