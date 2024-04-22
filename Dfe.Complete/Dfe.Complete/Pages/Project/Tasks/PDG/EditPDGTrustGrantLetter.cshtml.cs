using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.PDG
{
    public class EditPDGTrustGrantLetterModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditPDGTrustGrantLetterModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string CurrentFreeSchoolName { get; set; }

        [BindProperty(Name = "trust-letter-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Date when DfE signed PDG letter sent from the trust")]
        [DateValidation(DateRangeValidationService.DateRange.PastOrFuture)]
        public DateTime? TrustSignedPDGLetterDate { get; set; }

        [BindProperty(Name = "saved-letter-in-workplaces-folder")]
        [Display(Name = "Saved the signed trust letter in Workplaces folder")]
        public bool? SavedLetterInWorkplacesFolder { get; set; }

        public EditPDGTrustGrantLetterModel(IGetProjectByTaskService getProjectService, IUpdateProjectByTaskService updateProjectTaskService, ILogger<EditPDGTrustGrantLetterModel> logger,
            ErrorService errorService)
        {
            _getProjectService = getProjectService;
            _logger = logger;
            _errorService = errorService;
            _updateProjectTaskService = updateProjectTaskService;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await LoadProject();
            return Page();
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.TrustPDGLetterSent);

            TrustSignedPDGLetterDate = project.TrustPDGLetterSent.TrustSignedPDGLetterDate;
            SavedLetterInWorkplacesFolder = project.TrustPDGLetterSent.PDGLetterSavedInWorkspaces;
            CurrentFreeSchoolName = project.SchoolName;
        }

        public async Task<ActionResult> OnPost()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.TrustPDGLetterSent);
            CurrentFreeSchoolName = project.SchoolName;

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            try
            {
                var request = new UpdateProjectByTaskRequest()
                {
                    TrustPDGLetterSent = new()
                    {
                        TrustSignedPDGLetterDate = TrustSignedPDGLetterDate,
                        PDGLetterSavedInWorkspaces = SavedLetterInWorkplacesFolder
                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);

                return Redirect(string.Format(RouteConstants.ViewPDG, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }
    }
}
