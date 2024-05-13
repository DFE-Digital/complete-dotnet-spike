using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.Constants;
using Dfe.Complete.Services.Project.Transfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Transfer.Tasks.StakeholderKickoff
{
    public class EditStakeholderKickoffTaskModel : PageModel
    {
        private readonly IGetTransferProjectByTaskService _getTransferProjectByTaskService;
        private readonly IUpdateTransferProjectByTaskService _updateTransferProjectByTaskService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string SchoolName { get; set; }

        [BindProperty(Name = "send-intro-emails")]
        public bool? SendIntroEmails { get; set; }

        [BindProperty(Name = "send-invites")]
        public bool? SendInvites { get; set; }

        [BindProperty(Name = "host-meeting-or-call")]
        public bool? HostMeetingOrCall { get; set; }

        public EditStakeholderKickoffTaskModel(
            IGetTransferProjectByTaskService getTransferProjectByTaskService,
            IUpdateTransferProjectByTaskService updateTransferProjectByTaskService)
        {
            _getTransferProjectByTaskService = getTransferProjectByTaskService;
            _updateTransferProjectByTaskService = updateTransferProjectByTaskService;
        }

        public async Task OnGet()
        {
            var project = await _getTransferProjectByTaskService.Execute(ProjectId, TransferProjectTaskName.StakeholderKickoff);

            SendIntroEmails = project.StakeholderKickoff.SendIntroEmails;
            SendInvites = project.StakeholderKickoff.SendInvites;
            HostMeetingOrCall = project.StakeholderKickoff.HostMeetingOrCall;

            SchoolName = project.SchoolName;
        }

        public async Task<IActionResult> OnPost()
        {
            var request = new UpdateTransferProjectByTaskRequest()
            {
                StakeholderKickoff = new()
                {
                    SendIntroEmails = SendIntroEmails,
                    SendInvites = SendInvites,
                    HostMeetingOrCall = HostMeetingOrCall
                }
            };

            await _updateTransferProjectByTaskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.TransferViewStakeholderKickoffTask, ProjectId));
        }
    }
}
