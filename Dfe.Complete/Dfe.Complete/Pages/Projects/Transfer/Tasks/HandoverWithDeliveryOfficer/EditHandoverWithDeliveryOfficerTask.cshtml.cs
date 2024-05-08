using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.Constants;
using Dfe.Complete.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Transfer.Tasks.HandoverWithDeliveryOfficer
{
    public class EditHandoverWithDeliveryOfficerTaskModel : PageModel
    {
        private readonly IGetTransferProjectByTaskService _getTransferProjectByTaskService;
        private readonly IUpdateTransferProjectByTaskService _updateTransferProjectByTaskService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string SchoolName { get; set; }

        [BindProperty(Name = "not-applicable")]
        public bool? NotApplicable { get; set; }

        [BindProperty(Name = "review-project-information")]
        public bool? ReviewProjectInformation { get; set; }

        [BindProperty(Name = "make-notes")]
        public bool? MakeNotes { get; set; }

        [BindProperty(Name = "attend-handover-meeting")]
        public bool? AttendHandoverMeeting { get; set; }

        public EditHandoverWithDeliveryOfficerTaskModel(
            IGetTransferProjectByTaskService getTransferProjectByTaskService,
            IUpdateTransferProjectByTaskService updateTransferProjectByTaskService)
        {
            _getTransferProjectByTaskService = getTransferProjectByTaskService;
            _updateTransferProjectByTaskService = updateTransferProjectByTaskService;
        }

        public async Task OnGet()
        {
            var project = await _getTransferProjectByTaskService.Execute(ProjectId, TransferProjectTaskName.HandoverWithDeliveryOfficer);

            NotApplicable = project.HandoverWithDeliveryOfficer.NotApplicable;
            ReviewProjectInformation = project.HandoverWithDeliveryOfficer.ReviewProjectInformation;
            MakeNotes = project.HandoverWithDeliveryOfficer.MakeNotes;
            AttendHandoverMeeting = project.HandoverWithDeliveryOfficer.AttendHandoverMeeting;
            SchoolName = project.SchoolName;
        }

        public async Task<IActionResult> OnPost()
        {
            var request = new UpdateTransferProjectByTaskRequest()
            {
                HandoverWithDeliveryOfficer = new HandoverWithDeliveryOfficerTask()
                {
                    NotApplicable = NotApplicable,
                    ReviewProjectInformation = ReviewProjectInformation,
                    MakeNotes = MakeNotes,
                    AttendHandoverMeeting = AttendHandoverMeeting
                }
            };

            await _updateTransferProjectByTaskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.ViewHandoverWithDeliveryOfficerTask, ProjectId));
        }
    }
}
