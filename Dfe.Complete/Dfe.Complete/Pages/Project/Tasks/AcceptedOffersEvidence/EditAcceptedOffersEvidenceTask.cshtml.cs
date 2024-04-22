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


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.AcceptedOffersEvidence
{
    public class EditAcceptedOffersEvidenceTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditAcceptedOffersEvidenceTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
        
        [BindProperty(Name = "seen-accepted-offers-evidence")]
        
        public bool? SeenAcceptedOffersEvidence{ get; set; }
        
        [BindProperty(Name = "comments")]
        [DisplayName("Comments")]
        [ValidText(999)]
        
        public string Comments { get; set; }
        
        [BindProperty(Name = "saved-to-workplaces")]
        
        public bool? SavedToWorkplaces { get; set; }
        
        public string SchoolName { get; set; }

        public EditAcceptedOffersEvidenceTaskModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditAcceptedOffersEvidenceTaskModel> logger,
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
            var project = await _getProjectService.Execute(ProjectId, TaskName.EvidenceOfAcceptedOffers);
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
                    EvidenceOfAcceptedOffers = new EvidenceOfAcceptedOffersTask()
                    {
                        EvidenceOfAcceptedOffers = SeenAcceptedOffersEvidence,
                        Comments = Comments,
                        SavedToWorkplaces = SavedToWorkplaces
                        
                        
                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);
                return Redirect(string.Format(RouteConstants.ViewAcceptedOffersEvidenceTask, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.EvidenceOfAcceptedOffers);
            
            SeenAcceptedOffersEvidence = project.EvidenceOfAcceptedOffers.EvidenceOfAcceptedOffers;
            Comments = project.EvidenceOfAcceptedOffers.Comments;
            SavedToWorkplaces = project.EvidenceOfAcceptedOffers.SavedToWorkplaces;
            SchoolName = project.SchoolName;
        }
    }
}