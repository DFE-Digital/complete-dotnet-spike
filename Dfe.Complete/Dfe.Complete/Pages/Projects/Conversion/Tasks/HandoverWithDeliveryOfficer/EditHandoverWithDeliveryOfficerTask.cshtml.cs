using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.Constants;
using Dfe.Complete.Services.Project.Conversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.HandoverWithDeliveryOfficer
{
    public class EditHandoverWithDeliveryOfficerTaskModel : PageModel
    {
        private readonly IGetConversionProjectByTaskService _getConversionProjectByTaskService;
        private readonly IUpdateConversionProjectByTaskService _updateConversionProjectByTaskService;

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
            IGetConversionProjectByTaskService getConversionProjectByTaskService,
            IUpdateConversionProjectByTaskService updateConversionProjectByTaskService)
        {
            _getConversionProjectByTaskService = getConversionProjectByTaskService;
            _updateConversionProjectByTaskService = updateConversionProjectByTaskService;
        }

        public async Task OnGet()
        {
            var project = await _getConversionProjectByTaskService.Execute(ProjectId, ConversionProjectTaskName.HandoverWithDeliveryOfficer);

            NotApplicable = project.HandoverWithDeliveryOfficer.NotApplicable;
            ReviewProjectInformation = project.HandoverWithDeliveryOfficer.ReviewProjectInformation;
            MakeNotes = project.HandoverWithDeliveryOfficer.MakeNotes;
            AttendHandoverMeeting = project.HandoverWithDeliveryOfficer.AttendHandoverMeeting;
            SchoolName = project.SchoolName;
        }

        public async Task<IActionResult> OnPost()
        {
            var request = new UpdateConversionProjectByTaskRequest()
            {
                HandoverWithDeliveryOfficer = new HandoverWithDeliveryOfficerTask()
                {
                    NotApplicable = NotApplicable,
                    ReviewProjectInformation = ReviewProjectInformation,
                    MakeNotes = MakeNotes,
                    AttendHandoverMeeting = AttendHandoverMeeting
                }
            };

            await _updateConversionProjectByTaskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.ConversionViewHandoverWithDeliveryOfficerTask, ProjectId));
        }
    }
}
