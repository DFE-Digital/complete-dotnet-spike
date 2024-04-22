
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Services.Trust;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.Trust
{
    public class EditTrustTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IGetTrustByRefService _getTrustByRefService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditTrustTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string CurrentFreeSchoolName { get; set; }

        [BindProperty(SupportsGet = true, Name = "trn")]
        [Display(Name = "TRN")]
        [Required]
        public string TRN { get; set; }

        [BindProperty(Name = "trust-name")]
        [Display(Name = "Trust Name")]
        public string TrustName { get; set; }

        [BindProperty(Name = "trust-type")]
        [Display(Name = "Trust Type")]
        public TrustType TrustType { get; set; }

        [BindProperty(Name = "confirm-trust")]
        [Display(Name = "confirm trust")]
        [Required(ErrorMessage = "Confirm that the trust displayed is correct.")]
        public string ConfirmTrust { get; set; }

        public EditTrustTaskModel(
            IGetProjectByTaskService getProjectService,
            IGetTrustByRefService getTrustByRefService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditTrustTaskModel> logger,
            ErrorService errorService)
        {
            _getProjectService = getProjectService;
            _getTrustByRefService = getTrustByRefService;
            _updateProjectTaskService = updateProjectTaskService;
            _logger = logger;
            _errorService = errorService;
        }

        public async Task<IActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            try
            {
                var project = await _getProjectService.Execute(ProjectId, TaskName.Trust);
                CurrentFreeSchoolName = project.SchoolName;

                var trust = await _getTrustByRefService.Execute(TRN);

                TRN = trust.Trust.TRN;
                TrustName = trust.Trust.TrustName;
                TrustType = trust.Trust.TrustType;

            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
            }

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);

                var project = await _getProjectService.Execute(ProjectId, TaskName.Trust);
                CurrentFreeSchoolName = project.SchoolName;

                var trust = await _getTrustByRefService.Execute(TRN);

                TRN = trust.Trust.TRN;
                TrustName = trust.Trust.TrustName;
                TrustType = trust.Trust.TrustType;

                return Page();
            }

            if (!bool.Parse(ConfirmTrust)) {
                return Redirect(string.Format(RouteConstants.SearchTrustTask, ProjectId));
            }

            try
            {
                var trust = await _getTrustByRefService.Execute(TRN);

                var request = new UpdateProjectByTaskRequest()
                {
                    Trust = new TrustTask()
                    {
                        TRN = trust.Trust.TRN,
                        TrustName = trust.Trust.TrustName,
                        TrustType = trust.Trust.TrustType

                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);

                return Redirect(string.Format(RouteConstants.ViewTrustTask, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }
    }
}
