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
using Dfe.ManageFreeSchoolProjects.Validators;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.PDG
{
    public class EditWriteOffModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditWriteOffModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string CurrentFreeSchoolName { get; set; }

        [BindProperty(Name = "write-off-reason")]
        [Display(Name = "Write-off reason")]
        [ValidText(100)]
        public string WriteOffReason { get; set; }

        [BindProperty(Name = "write-off-amount", BinderType = typeof(DecimalInputModelBinder))]
        [Display(Name = "Write-off amount")]
        [ValidMoney(0, 999999)]
        public decimal? WriteOffAmount { get; set; }

        [BindProperty(Name = "write-off-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Write-off date")]
        [DateValidation(DateRangeValidationService.DateRange.PastOrFuture)]
        public DateTime? WriteOffDate { get; set; }

        [BindProperty(Name = "finance-partner")]
        [Display(Name = "Finance business partner approval received from")]
        [ValidText(100)]
        public string FinanceBusinessPartnerApprovalReceivedFrom { get; set; }

        [BindProperty(Name = "approval-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Approval date")]
        [DateValidation(DateRangeValidationService.DateRange.PastOrFuture)]
        public DateTime? ApprovalDate { get; set; }

        public EditWriteOffModel(IGetProjectByTaskService getProjectService, IUpdateProjectByTaskService updateProjectTaskService, ILogger<EditWriteOffModel> logger,
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
            var project = await _getProjectService.Execute(ProjectId, TaskName.WriteOff);

            WriteOffReason = project.WriteOff.WriteOffReason;
            WriteOffAmount = project.WriteOff.WriteOffAmount;
            WriteOffDate = project.WriteOff.WriteOffDate;
            FinanceBusinessPartnerApprovalReceivedFrom = project.WriteOff.FinanceBusinessPartnerApprovalReceivedFrom;
            ApprovalDate = project.WriteOff.ApprovalDate;

            CurrentFreeSchoolName = project.SchoolName;
        }

        public async Task<ActionResult> OnPost()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.WriteOff);
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
                    WriteOff = new()
                    {
                        WriteOffReason = WriteOffReason,
                        WriteOffAmount = WriteOffAmount,
                        WriteOffDate = WriteOffDate,
                        FinanceBusinessPartnerApprovalReceivedFrom = FinanceBusinessPartnerApprovalReceivedFrom,
                        ApprovalDate = ApprovalDate,
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
