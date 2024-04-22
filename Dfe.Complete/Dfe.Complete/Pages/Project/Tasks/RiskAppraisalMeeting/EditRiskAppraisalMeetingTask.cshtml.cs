using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.RiskAppraisalMeeting
{
    public class EditRiskAppraisalMeetingModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditRiskAppraisalMeetingModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string CurrentFreeSchoolName { get; set; }

        [BindProperty(Name = "meeting-completed")]
        [Display(Name = "Initial risk appraisal meeting completed")]
        public bool? MeetingCompleted { get; set; }

        [BindProperty(Name = "forecast-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Forecast date")]
        public DateTime? ForecastDate { get; set; }

        [BindProperty(Name = "actual-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Actual date")]
        public DateTime? ActualDate { get; set; }

        [BindProperty(Name = "comments-on-decision")]
        [Display(Name = "Comments")]
        [ValidText(100)]
        public string CommentsOnDecision { get; set; }

        [BindProperty(Name = "reason-not-applicable")]
        [Display(Name = "Reason")]
        [ValidText(100)]
        public string ReasonNotApplicable { get; set; }

        public EditRiskAppraisalMeetingModel(
            IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditRiskAppraisalMeetingModel> logger,
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
                var project = await _getProjectService.Execute(ProjectId, TaskName.RiskAppraisalMeeting);
                CurrentFreeSchoolName = project.SchoolName;
                MeetingCompleted = project.RiskAppraisalMeeting.InitialRiskAppraisalMeetingCompleted;
                ForecastDate = project.RiskAppraisalMeeting.ForecastDate;
                ActualDate = project.RiskAppraisalMeeting.ActualDate;
                CommentsOnDecision = project.RiskAppraisalMeeting.CommentsOnDecisionToApprove;
                ReasonNotApplicable = project.RiskAppraisalMeeting.ReasonNotApplicable;

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
                var project = await _getProjectService.Execute(ProjectId, TaskName.RiskAppraisalMeeting);
                CurrentFreeSchoolName = project.SchoolName;
                
                return Page();
            }

            try
            {
                var request = new UpdateProjectByTaskRequest()
                {
                    RiskAppraisalMeeting = new RiskAppraisalMeetingTask()
                    {
                        InitialRiskAppraisalMeetingCompleted = MeetingCompleted,
                        ForecastDate = ForecastDate,
                        ActualDate = ActualDate,
                        CommentsOnDecisionToApprove = CommentsOnDecision,
                        ReasonNotApplicable = ReasonNotApplicable
                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);

                return Redirect(string.Format(RouteConstants.ViewRiskAppraisalMeetingTask, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }
    }
}
