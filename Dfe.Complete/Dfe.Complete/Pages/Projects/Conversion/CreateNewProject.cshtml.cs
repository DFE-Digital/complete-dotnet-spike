using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Dfe.Complete.Extensions;
using Dfe.Complete.Client.Contracts;

namespace Dfe.Complete.Pages.Projects.Conversion
{
    public class CreateNewProjectModel(ICreateProjectClient projectsClient) : PageModel
    {
        [BindProperty]
        public string URN { get; set; } 

        [BindProperty]
        public string UKPRN { get; set; }

        [BindProperty]
        public string GroupReferenceNumber { get; set; }

        [BindProperty]
        public DateTime? AdvisoryBoardDate { get; set; } 

        [BindProperty]
        public string AdvisoryBoardConditions { get; set; } 

        [BindProperty]
        public DateTime? ProvisionalConversionDate { get; set; }

        [BindProperty]
        public string SchoolSharePointLink { get; set; } 

        [BindProperty]
        public string IncomingTrustSharePointLink { get; set; } 

        [BindProperty]
        public bool? IsHandingToRCS { get; set; }

        [BindProperty]
        public string HandoverComments { get; set; }

        [BindProperty]
        public bool? DirectiveAcademyOrder { get; set; } 

        [BindProperty]
        public bool? IsDueTo2RI { get; set; }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            //Validate
            //await ValidateAllFields();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var createProjectCommand = new CreateProjectCommand();
            //createProjectCommand.Urn = new Urn();
            //createProjectCommand.SignificantDate = ProvisionalConversionDate;
            //createProjectCommand.IsSignificantDateProvisional = true; // will be set to false in the stakeholder kick off task 
            //createProjectCommand.IncomingTrustSharepointLink = IncomingTrustSharePointLink;
            //createProjectCommand.EstablishmentSharepointLink = SchoolSharePointLink;
            //createProjectCommand.IsDueTo2RI = IsDueTo2RI;
            //createProjectCommand.AdvisoryBoardDate = AdvisoryBoardDate;
            //createProjectCommand.AdvisoryBoardConditions = AdvisoryBoardConditions;
            //createProjectCommand.IncomingTrustUkprn = new Ukprn();
            //createProjectCommand.HasAcademyOrderBeenIssued = DirectiveAcademyOrder;


            //Test Data
            var createProjectCommand = new CreateProjectCommand();
            createProjectCommand.Urn = new Urn() { Value = 2 };
            createProjectCommand.SignificantDate = DateTime.UtcNow;
            createProjectCommand.IsSignificantDateProvisional = true; // will be set to false in the stakeholder kick off task 
            createProjectCommand.IncomingTrustSharepointLink = "https://www.sharepointlink.com/test";
            createProjectCommand.EstablishmentSharepointLink = "https://www.sharepointlink.com/test";
            createProjectCommand.IsDueTo2RI = IsDueTo2RI;
            createProjectCommand.AdvisoryBoardDate = DateTime.UtcNow;
            createProjectCommand.AdvisoryBoardConditions = "test conditions";
            createProjectCommand.IncomingTrustUkprn = new Ukprn() { Value = 2 };
            createProjectCommand.HasAcademyOrderBeenIssued = true;

            var createResponse = await projectsClient.Projects_CreateProject_Async(createProjectCommand);

            var projectId = createResponse.Value;

            return Redirect($"/projects/conversion-projects/{projectId}/created");
        }

        public async Task ValidateAllFields()
        {
            await ValidateUrn();
            ValidateUKPRN();
            ValidateAdvisoryBoardDate();
            ValidateProvisionalConversionDate();
            //TODO:EA needs fixing
            //ValidateSharePointLink(nameof(SchoolSharePointLink));
            //ValidateSharePointLink(nameof(IncomingTrustSharePointLink));
            ValidateHandingToRCS();
            ValidateAcademyOrder();
            ValidateDueTo2RI();
        }
    
        private async Task ValidateUrn()
        {
            var fieldName = nameof(URN);
            var value = URN;

            if (string.IsNullOrEmpty(value))
            {
                ModelState.AddModelError($"{fieldName}", "Enter a school URN");
                return;
            }

            string pattern = "^[0-9]{6}$";

            var isAMatch = Regex.IsMatch(value, pattern);

            if (!isAMatch)
            {
                ModelState.AddModelError($"{fieldName}", "must be 6 digits");
                return;
            }

            var parsedUrn = value.ToInt();

            // var existingProject = await _getConversionProjectService.GetConversionProjectByUrn(parsedUrn);
            //
            // if (existingProject != null)
            // {
            //     ModelState.AddModelError($"{fieldName}", "project with this URN already exists");
            // }
        }

        private void ValidateUKPRN()
        {
            var fieldName = nameof(UKPRN);
            var value = UKPRN;

            if (string.IsNullOrEmpty(value))
            {
                ModelState.AddModelError($"{fieldName}", "Enter a UKPRN");
                return;
            }
        }

        private void ValidateAdvisoryBoardDate()
        {
            var fieldName = nameof(AdvisoryBoardDate);
            var value = AdvisoryBoardDate;

            if (value == null || value == DateTime.MinValue)
            {
                ModelState.AddModelError($"{fieldName}", "Enter a date for the advisory board, like 1 4 2023");
                return;
            }
        }

        private void ValidateProvisionalConversionDate()
        {
            var fieldName = nameof(ProvisionalConversionDate);
            var value = ProvisionalConversionDate;

            if (value == null || value == DateTime.MinValue)
            {
                ModelState.AddModelError($"{fieldName}", "Enter a month and year for the provisional conversion date, like 9 2023");
                return;
            }
        }

        private void ValidateSharePointLink(string fieldName)
        {
            var value = fieldName == nameof(SchoolSharePointLink) ? SchoolSharePointLink : IncomingTrustSharePointLink;

            if (string.IsNullOrEmpty(value))
            {
                ModelState.AddModelError($"{fieldName}", $"Enter a {fieldName} SharePoint link");
                return;
            }

            if (!value.Contains("https"))
            {
                ModelState.AddModelError($"{fieldName}", $"The SharePoint link must have the https scheme");
                return;
            }

            if (!value.Contains("https://educationgovuk.sharepoint.com") || !value.Contains("https://educationgovuk-my.sharepoint.com/"))
            {
                ModelState.AddModelError($"{fieldName}", $"Enter an incoming trust sharepoint link in the correct format. SharePoint links start with 'https://educationgovuk.sharepoint.com' or 'https://educationgovuk-my.sharepoint.com/'");
                return;
            }
        }

        private void ValidateHandingToRCS()
        {
            var fieldName = nameof(IsHandingToRCS);
            var value = IsHandingToRCS;

            if (value == null)
            {
                ModelState.AddModelError($"{fieldName}", "State if this project will be handed over to the Regional casework services team. Choose yes or no");
                return;
            }
        }

        private void ValidateAcademyOrder()
        {
            var fieldName = nameof(DirectiveAcademyOrder);
            var value = DirectiveAcademyOrder;

            if (value == null)
            {
                ModelState.AddModelError($"{fieldName}", "Select directive academy order or academy order, whichever has been used for this conversion");
                return;
            }
        }

        private void ValidateDueTo2RI()
        {
            var fieldName = nameof(IsDueTo2RI);
            var value = IsDueTo2RI;

            if (value == null)
            {
                ModelState.AddModelError($"{fieldName}", "State if the conversion is due to 2RI. Choose yes or no");
                return;
            }
        }
    }
}
