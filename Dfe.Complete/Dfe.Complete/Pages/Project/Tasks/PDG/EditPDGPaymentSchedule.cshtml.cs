using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.Extensions.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Logging;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.Validators;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.PDG
{
    public class EditPDGPaymentScheduleModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditPDGPaymentScheduleModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string CurrentFreeSchoolName { get; set; }
        [BindProperty(Name = "payment-due-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "When is the payment due?")]
        [DateValidation(DateRangeValidationService.DateRange.PastOrFuture)]
        public DateTime? PaymentScheduleDate { get; set; }

        [BindProperty(Name = "payment-due-amount", BinderType = typeof(DecimalInputModelBinder))]
        [Display(Name = "Amount of 1st payment due")]
        [ValidMoney(0, 25000)]
        public decimal? PaymentScheduleAmount { get; set; }

        [BindProperty(Name = "actual-payment-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Actual payment date")]
        [DateValidation(DateRangeValidationService.DateRange.PastOrFuture)]
        public DateTime? PaymentActualDate { get; set; }

        [BindProperty(Name = "payment-actual-amount", BinderType = typeof(DecimalInputModelBinder))]
        [Display(Name = "What is the payment amount?")]
        [ValidMoney(0, 25000)]
        public decimal? PaymentActualAmount { get; set; }

        public EditPDGPaymentScheduleModel(IGetProjectByTaskService getProjectService, IUpdateProjectByTaskService updateProjectTaskService, ILogger<EditPDGPaymentScheduleModel> logger,
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

        public async Task<ActionResult> OnPost()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.PaymentSchedule);
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
                    PaymentSchedule = new PaymentScheduleTask()
                    {
                        PaymentScheduleDate = PaymentScheduleDate,
                        PaymentScheduleAmount = PaymentScheduleAmount,
                        PaymentActualDate = PaymentActualDate,
                        PaymentActualAmount = PaymentActualAmount,
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

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.PaymentSchedule);

            PaymentScheduleDate = project.PaymentSchedule.PaymentScheduleDate;
            PaymentScheduleAmount = project.PaymentSchedule.PaymentScheduleAmount;
            PaymentActualDate = project.PaymentSchedule.PaymentActualDate;
            PaymentActualAmount = project.PaymentSchedule.PaymentActualAmount;
            CurrentFreeSchoolName = project.SchoolName;
        }
    }
}
