using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks;
using Dfe.Complete.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.StakeholderKickoff
{
    public class EditStakeholderKickoffTaskModel : PageModel
    {
        private readonly IGetConversionProjectByTaskService _getConversionProjectByTaskService;
        private readonly IUpdateConversionProjectByTaskService _updateConversionProjectByTaskService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public Guid ProjectId { get; set; }

        public string SchoolName { get; set; }

        [BindProperty(Name = "send-intro-emails")]
        public bool? SendIntroEmails { get; set; }

        [BindProperty(Name = "local-authority-proforma")]
        public bool? LocalAuthorityProforma { get; set; }

        [BindProperty(Name = "local-authority-able-to-convert")]
        public bool? LocalAuthorityAbleToConvert { get; set; }

        [BindProperty(Name = "send-invites")]
        public bool? SendInvites { get; set; }

        [BindProperty(Name = "host-meeting-or-call")]
        public bool? HostMeetingOrCall { get; set; }

        [BindProperty(Name = "conversion-date")]
        public DateTime? ConversionDate { get; set; }

        public EditStakeholderKickoffTaskModel(
            IGetConversionProjectByTaskService getConversionProjectByTaskService,
            IUpdateConversionProjectByTaskService updateConversionProjectByTaskService)
        {
            _getConversionProjectByTaskService = getConversionProjectByTaskService;
            _updateConversionProjectByTaskService = updateConversionProjectByTaskService;
        }

        public async Task OnGet()
        {
            var project = await _getConversionProjectByTaskService.Execute(ProjectId, ConversionProjectTaskName.StakeholderKickoff);

            SendIntroEmails = project.StakeholderKickoff.SendIntroEmails;
            LocalAuthorityProforma = project.StakeholderKickoff.LocalAuthorityProforma;
            LocalAuthorityAbleToConvert = project.StakeholderKickoff.LocalAuthorityAbleToConvert;
            SendInvites = project.StakeholderKickoff.SendInvites;
            HostMeetingOrCall = project.StakeholderKickoff.HostMeetingOrCall;
            ConversionDate = project.StakeholderKickoff.StakeholderKickOffConversionDate;

            SchoolName = project.SchoolName;
        }

        public async Task<IActionResult> OnPost()
        {
            var request = new UpdateConversionProjectByTaskRequest()
            {
                StakeholderKickoff = new()
                {
                    SendIntroEmails = SendIntroEmails,
                    LocalAuthorityProforma = LocalAuthorityProforma,
                    LocalAuthorityAbleToConvert = LocalAuthorityAbleToConvert,
                    SendInvites = SendInvites,
                    HostMeetingOrCall = HostMeetingOrCall,
                    StakeholderKickOffConversionDate = ConversionDate
                }
            };

            await _updateConversionProjectByTaskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.ConversionStakeholderKickoffTask, ProjectId));
        }
    }
}
