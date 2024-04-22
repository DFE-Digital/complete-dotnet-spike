using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Extensions;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    public class EditPost16PublishedAdmissionNumberModel : EditPupilNumbersBaseModel
    {
        [BindProperty(Name = "year12")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Year 12")]
        public string Year12 {get;set;}

        [BindProperty(Name = "other-post16")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Other post-16")]
        public string OtherPost16 { get; set; }

        private readonly IGetPupilNumbersService _getPupilNumbersService;
        private readonly IUpdatePupilNumbersService _updatePupilNumbersService;
        private readonly ErrorService _errorService;

        public EditPost16PublishedAdmissionNumberModel(
            IGetPupilNumbersService getPupilNumbersService,
            IUpdatePupilNumbersService updatePupilNumbersService,
            ErrorService errorService)
        {
            _getPupilNumbersService = getPupilNumbersService;
            _updatePupilNumbersService = updatePupilNumbersService;
            _errorService = errorService;
        }

        public async Task<IActionResult> OnGet()
        {
            var pupilNumbers = await _getPupilNumbersService.Execute(ProjectId);

            Year12 = pupilNumbers.Post16PublishedAdmissionNumber.Year12.ToString();
            OtherPost16 = pupilNumbers.Post16PublishedAdmissionNumber.OtherPost16.ToString();
            SchoolName = pupilNumbers.SchoolName;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            var request = new UpdatePupilNumbersRequest()
            {
                Post16PublishedAdmissionNumber = new Post16PublishedAdmissionNumber()
                {
                    Year12 = Year12.ToInt(),
                    OtherPost16 = OtherPost16.ToInt()
                }
            };

            await _updatePupilNumbersService.Execute(ProjectId, request);

            return GoToViewPage();
        }
    }
}
