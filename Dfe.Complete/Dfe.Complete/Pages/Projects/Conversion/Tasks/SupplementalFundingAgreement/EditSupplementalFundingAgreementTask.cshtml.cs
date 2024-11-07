using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks;
using Dfe.Complete.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.SupplementalFundingAgreement
{
    public class EditSupplementalFundingAgreementTaskModel : PageModel
    {
        private readonly IGetConversionProjectByTaskService _getConversionProjectByTaskService;
        private readonly IUpdateConversionProjectByTaskService _updateConversionProjectByTaskService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public Guid ProjectId { get; set; }

        public string SchoolName { get; set; }

        [BindProperty(Name = "cleared")]
        public bool? Cleared { get; set; }

        [BindProperty(Name = "received")]
        public bool? Received { get; set; }

        [BindProperty(Name = "saved")]
        public bool? Saved { get; set; }

        [BindProperty(Name = "signed")]
        public bool? Signed { get; set; }

        [BindProperty(Name = "sent")]
        public bool? Sent { get; set; }

        [BindProperty(Name = "signed-secretary-state")]
        public bool? SignedSecretaryState { get; set; }

        

        public EditSupplementalFundingAgreementTaskModel(
            IGetConversionProjectByTaskService getConversionProjectByTaskService,
            IUpdateConversionProjectByTaskService updateConversionProjectByTaskService)
        {
            _getConversionProjectByTaskService = getConversionProjectByTaskService;
            _updateConversionProjectByTaskService = updateConversionProjectByTaskService;
        }

        public async Task OnGet()
        {
            var project = await _getConversionProjectByTaskService.Execute(ProjectId, ConversionProjectTaskName.SupplementalFundingAgreement);

            Received = project.SupplementalFundingAgreement.Received;
            Cleared = project.SupplementalFundingAgreement.Cleared;
            Signed = project.SupplementalFundingAgreement.Signed;
            Saved = project.SupplementalFundingAgreement.Saved;
            Sent = project.SupplementalFundingAgreement.Sent;
            SignedSecretaryState = project.SupplementalFundingAgreement.SignedSecretaryState;

            SchoolName = project.SchoolName;
        }

        public async Task<IActionResult> OnPost()
        {
            var request = new UpdateConversionProjectByTaskRequest()
            {
                SupplementalFundingAgreement = new()
                {
                    Cleared = Cleared,
                    Received = Received,
                    Signed = Signed,
                    Saved = Saved,

                    Sent = Sent,
                    SignedSecretaryState = SignedSecretaryState
                }
            };

            await _updateConversionProjectByTaskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.ConversionSupplementalFundingAgreementTask, ProjectId));
        }
    }
}
