using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.UseCases.Project.Conversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Dfe.Complete.Extensions;

namespace Dfe.Complete.Pages.Projects.Conversion
{
    public class CreateNewProjectModel : PageModel
    {
        private readonly ICreateConversionProjectService _createConversionProjectService;
        private readonly IGetConversionProjectService _getConversionProjectService;

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

        public CreateNewProjectModel(ICreateConversionProjectService createConversionProjectService, IGetConversionProjectService getConversionProjectService)
        {
            _createConversionProjectService = createConversionProjectService;
            _getConversionProjectService = getConversionProjectService;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            //Validate
            await ValidateAllFields();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var project = new CreateConversionProjectRequest();
            project.Urn = URN;
            project.Date = ProvisionalConversionDate;
            project.IsDateProvisional = true; // will be set to false in the stakeholder kick off task 
            project.SchoolSharePointLink = SchoolSharePointLink;
            project.IsDueTo2RI = IsDueTo2RI;
            project.AdvisoryBoardDetails = new AdvisoryBoardDetails() 
            {
                Date = AdvisoryBoardDate,
                Conditions = AdvisoryBoardConditions,
            };
            project.IncomingTrustDetails = new CreateTrustDetails() 
            {
                Ukprn = UKPRN,
                SharepointLink = IncomingTrustSharePointLink,
            };
            project.HasAcademyOrderBeenIssued = DirectiveAcademyOrder;

            var createResponse = await _createConversionProjectService.Execute(project);

            return Redirect($"/projects/conversion-projects/{createResponse.Id}/created");

            //return Page();
        }
    

        public async Task ValidateAllFields()
        {
            await ValidateUrn();
            ValidateUKPRN();
            ValidateAdvisoryBoardDate();
            ValidateProvisionalConversionDate();
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

            var existingProject = await _getConversionProjectService.GetConversionProjectByUrn(parsedUrn);

            if (existingProject != null)
            {
                ModelState.AddModelError($"{fieldName}", "project with this URN already exists");

                return;
            }
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
