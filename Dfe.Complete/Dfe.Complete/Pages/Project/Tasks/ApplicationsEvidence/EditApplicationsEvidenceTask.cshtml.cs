using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Validators;


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.ApplicationsEvidence
{
    public class EditApplicationsEvidenceTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditApplicationsEvidenceTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
        
        [BindProperty(Name = "confirmed-pupil-numbers")]
        
        public bool? ConfirmedPupilNumbers{ get; set; }
        
        [BindProperty(Name = "comments")]
        [DisplayName("Comments")]
        [ValidText(999)]
        
        public string Comments { get; set; }
        
        [BindProperty(Name = "build-up-form-in-workplaces")]
        
        public bool? BuildUpFormInWorkplaces{ get; set; }
        
        [BindProperty(Name = "underwriting-agreement-in-workplaces")]
        
        public bool? UnderwritingAgreementInWorkplaces{ get; set; }
        public string SchoolName { get; set; }

        public EditApplicationsEvidenceTaskModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditApplicationsEvidenceTaskModel> logger,
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
            var project = await _getProjectService.Execute(ProjectId, TaskName.ApplicationsEvidence);
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
                    ApplicationsEvidence = new ApplicationsEvidenceTask()
                    {
                        ConfirmedPupilNumbers = ConfirmedPupilNumbers,
                        Comments = Comments,
                        BuildUpFormSavedToWorkplaces = BuildUpFormInWorkplaces,
                        UnderwritingAgreementSavedToWorkplaces = UnderwritingAgreementInWorkplaces
                        
                        
                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);
                return Redirect(string.Format(RouteConstants.ViewApplicationsEvidenceTask, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.ApplicationsEvidence);
            
            ConfirmedPupilNumbers = project.ApplicationsEvidence.ConfirmedPupilNumbers;
            Comments = project.ApplicationsEvidence.Comments;
            BuildUpFormInWorkplaces = project.ApplicationsEvidence.BuildUpFormSavedToWorkplaces;
            UnderwritingAgreementInWorkplaces = project.ApplicationsEvidence.UnderwritingAgreementSavedToWorkplaces;
            
            SchoolName = project.SchoolName;
        }
    }
}