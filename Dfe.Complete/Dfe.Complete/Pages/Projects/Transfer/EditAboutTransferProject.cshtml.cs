using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.Attributes;
using Dfe.Complete.Constants;
using Dfe.Complete.Models;
using Dfe.Complete.Services;
using Dfe.Complete.Services.Project.Transfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Transfer
{
    public class EditAboutTransferProjectModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name = "outgoing-trust-ukprn")]
        [Required(ErrorMessage="Enter a UKPRN")]
        public string OutgoingTrustUkprn { get;set; }

        [BindProperty(Name = "outgoing-trust-sharepoint-folder")]
        [Required(ErrorMessage = "Enter an outgoing trust SharePoint link")]
        [SharePointLink]
        [DisplayName("outgoing trust SharePoint link")]
        public string OutgoingTrustSharePointFolder { get; set; }

        [BindProperty(Name = "incoming-trust-ukprn")]
        [Required(ErrorMessage = "Enter a UKPRN")]
        public string IncomingTrustUkprn { get; set; }

        [BindProperty(Name = "incoming-trust-sharepoint-folder")]
        [Required(ErrorMessage = "Enter an outgoing trust SharePoint link")]
        [SharePointLink]
        [DisplayName("incoming trust SharePoint link")]
        public string IncomingTrustSharePointFolder { get; set; }

        [BindProperty(Name = "date-of-advisory-board", BinderType = typeof(DateInputModelBinder))]
        [Required]
        [DisplayName("date for the advisory board")]
        public DateTime? DateOfAdvisoryBoard { get; set; }

        [BindProperty(Name = "advisory-board-conditions")]
        public string AdvisoryBoardConditions { get; set; }

        [BindProperty(Name = "school-sharepoint-folder")]
        [Required(ErrorMessage = "Enter a school SharePoint link")]
        [SharePointLink]
        [DisplayName("school SharePoint link")]
        public string SchoolSharePointFolder { get; set; }

        [BindProperty(Name = "is-due-to-2ri")]
        [Required]
        public bool? IsDueTo2RI { get; set; }

        [BindProperty(Name = "is-due-to-ofsted-rating")]
        [Required]
        public bool? IsDueToOfstedRating { get; set; }

        [BindProperty(Name = "is-due-to-issues")]
        [Required]
        public bool? IsDueToIssues { get; set; }

        private readonly ErrorService _errorService;

        private IGetTransferProjectService _getTransferProjectService;
        private IUpdateTransferProjectService _updateTransferProjectService;

        public EditAboutTransferProjectModel(
            IGetTransferProjectService getTransferProjectService, 
            IUpdateTransferProjectService updateTransferProjectService,
            ErrorService errorService)
        {
            _getTransferProjectService = getTransferProjectService;
            _updateTransferProjectService = updateTransferProjectService;
            _errorService = errorService;
        }

        public async Task OnGet()
        {
            var project = await _getTransferProjectService.Execute(ProjectId);

            OutgoingTrustUkprn = project.OutgoingTrustDetails.UkPrn;
            OutgoingTrustSharePointFolder = project.OutgoingTrustDetails.SharePointLink;
            IncomingTrustUkprn = project.IncomingTrustDetails.UkPrn;
            IncomingTrustSharePointFolder = project.IncomingTrustDetails.SharePointLink;
            DateOfAdvisoryBoard = project.AdvisoryBoardDetails.Date;
            AdvisoryBoardConditions = project.AdvisoryBoardDetails.Conditions;
            SchoolSharePointFolder = project.SchoolDetails.SharePointLink;
            IsDueTo2RI = project.ReasonForTheTransfer.IsDueTo2RI;
            IsDueToOfstedRating = project.ReasonForTheTransfer.IsDueToOfstedRating;
            IsDueToIssues = project.ReasonForTheTransfer.IsDueToIssues;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            var request = new UpdateTransferProjectRequest()
            {
                AdvisoryBoardDetails = new()
                {
                    Date = DateOfAdvisoryBoard,
                    Conditions = AdvisoryBoardConditions
                },
                IncomingTrustDetails = new()
                {
                    Ukprn = IncomingTrustUkprn,
                    SharePointLink = IncomingTrustSharePointFolder
                },
                OutgoingTrustDetails = new()
                {
                    Ukprn = OutgoingTrustUkprn,
                    SharePointLink = OutgoingTrustSharePointFolder
                },
                ReasonForTheTransfer = new()
                {
                    IsDueTo2RI = IsDueTo2RI,
                    IsDueToOfstedRating = IsDueToOfstedRating,
                    IsDueToIssues = IsDueToIssues
                },
                SchoolSharePointLink = SchoolSharePointFolder
            };

            await _updateTransferProjectService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.AboutTransferProject, ProjectId));
        }
    }
}
