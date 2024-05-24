using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.Constants;
using Dfe.Complete.Models;
using Dfe.Complete.Services;
using Dfe.Complete.Services.Project.Transfer;
using Dfe.Complete.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Dfe.Complete.Services.DateRangeValidationService;

namespace Dfe.Complete.Pages.Projects.Transfer
{
    public class EditAboutTransferProjectModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name = "outgoing-trust-ukprn")]
        [GovukRequired]
        [Ukprn]
        [DisplayName("outgoing trust UKPRN")]
        public string OutgoingTrustUkprn { get;set; }

        [BindProperty(Name = "outgoing-trust-sharepoint-folder")]
        [GovukRequired]
        [SharePointLink]
        [DisplayName("outgoing trust SharePoint link")]
        public string OutgoingTrustSharePointFolder { get; set; }

        [BindProperty(Name = "incoming-trust-ukprn")]
        [GovukRequired]
        [Ukprn]
        [DisplayName("incoming trust UKPRN")]
        public string IncomingTrustUkprn { get; set; }

        [BindProperty(Name = "incoming-trust-sharepoint-folder")]
        [GovukRequired]
        [SharePointLink]
        [DisplayName("incoming trust SharePoint link")]
        public string IncomingTrustSharePointFolder { get; set; }

        [BindProperty(Name = "date-of-advisory-board", BinderType = typeof(DateInputModelBinder))]
        [Required]
        [DisplayName("date for the advisory board")]
        [DateValidation(DateRange.PastOrToday)]
        public DateTime? DateOfAdvisoryBoard { get; set; }

        [BindProperty(Name = "advisory-board-conditions")]
        public string AdvisoryBoardConditions { get; set; }

        [BindProperty(Name = "school-sharepoint-folder")]
        [GovukRequired]
        [SharePointLink]
        [DisplayName("school SharePoint link")]
        public string SchoolSharePointFolder { get; set; }

        [BindProperty(Name = "is-due-to-2ri")]
        [GovukRequired]
        [DisplayName("is due to 2RI")]
        public bool? IsDueTo2RI { get; set; }

        [BindProperty(Name = "is-due-to-ofsted-rating")]
        [GovukRequired]
        [DisplayName("is due to ofsted rating")]
        public bool? IsDueToOfstedRating { get; set; }

        [BindProperty(Name = "is-due-to-issues")]
        [GovukRequired]
        [DisplayName("is due to issues")]
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
