
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.Dates
{
    public class EditDatesTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditDatesTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string CurrentFreeSchoolName { get; set; }

        [BindProperty(Name = "entry-into-pre-opening", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Entry into pre-opening")]
        [DateValidation(DateRangeValidationService.DateRange.Future)]
        public DateTime? EntryIntoPreOpening { get; set; }

        [BindProperty(Name = "provisional-opening-date-agreed-with-trust", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Provisional opening date agreed with trust")]
        [DateValidation(DateRangeValidationService.DateRange.Future)]
        public DateTime? ProvisionalOpeningDateAgreedWithTrust { get; set; }

        public EditDatesTaskModel(
            IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditDatesTaskModel> logger,
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

            try
            {
                var project = await _getProjectService.Execute(ProjectId, TaskName.Dates);
                CurrentFreeSchoolName = project.SchoolName;
                EntryIntoPreOpening = project.Dates.DateOfEntryIntoPreopening;
                ProvisionalOpeningDateAgreedWithTrust = project.Dates.ProvisionalOpeningDateAgreedWithTrust;
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
                var project = await _getProjectService.Execute(ProjectId, TaskName.Dates);
                CurrentFreeSchoolName = project.SchoolName;
                return Page();
            }

            try
            {
                var request = new UpdateProjectByTaskRequest()
                {
                    Dates = new DatesTask()
                    {
                        DateOfEntryIntoPreopening = EntryIntoPreOpening,
                        ProvisionalOpeningDateAgreedWithTrust = ProvisionalOpeningDateAgreedWithTrust
                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);

                return Redirect(string.Format(RouteConstants.ViewDatesTask, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }
    }
}
