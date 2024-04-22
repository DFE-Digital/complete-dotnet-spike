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
    public class EditStopPaymentModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditStopPaymentModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string CurrentFreeSchoolName { get; set; }

        [BindProperty(Name = "payment-stopped-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Date you want to stop the payments from")]
        [DateValidation(DateRangeValidationService.DateRange.PastOrFuture)]
        public DateTime? PaymentStoppedDate { get; set; }

        [BindProperty(Name = "payment-stopped")]
        [Display(Name = "Are you sure you want to stop payments?")]
        public string PaymentStopped { get; set; }

        public EditStopPaymentModel(IGetProjectByTaskService getProjectService, IUpdateProjectByTaskService updateProjectTaskService, ILogger<EditStopPaymentModel> logger,
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
            var project = await _getProjectService.Execute(ProjectId, TaskName.StopPayment);

            PaymentStoppedDate = project.StopPayment.PaymentStoppedDate;
            PaymentStopped = project.StopPayment.PaymentStopped;
            CurrentFreeSchoolName = project.SchoolName;
        }

        public async Task<ActionResult> OnPost()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.StopPayment);
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
                    StopPayment = new()
                    {
                        PaymentStoppedDate = PaymentStopped == "Yes" ? PaymentStoppedDate : null,
                        PaymentStopped = PaymentStopped,
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
