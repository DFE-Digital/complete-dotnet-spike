using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Extensions;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    public class EditCapacityWhenFullModel : EditPupilNumbersBaseModel
    {
        [BindProperty(Name = "nursery")]
        [ValidNumberForPupilNumbers]
        public string Nursery { get; set; }

        [BindProperty(Name = "reception-to-year6")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Reception to year 6")]
        public string ReceptionToYear6 { get; set; }

        [BindProperty(Name = "year7-to-year11")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Year 7 to year 11")]
        public string Year7ToYear11 { get; set; }

        [BindProperty(Name = "year12-to-year14")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Year 12 to year 14")]
        public string Year12ToYear14 { get; set; }

        [BindProperty(Name = "special-education-needs")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Special educational needs")]
        public string SpecialEducationNeeds { get; set; }

        [BindProperty(Name = "alternative-provision")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Alternative provision")]
        public string AlternativeProvision { get; set; }

        private readonly IGetPupilNumbersService _getPupilNumbersService;
        private readonly IUpdatePupilNumbersService _updatePupilNumbersService;
        private readonly ErrorService _errorService;

        public EditCapacityWhenFullModel(
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

            Nursery = pupilNumbers.CapacityWhenFull.Nursery.ToString();
            ReceptionToYear6 = pupilNumbers.CapacityWhenFull.ReceptionToYear6.ToString();
            Year7ToYear11 = pupilNumbers.CapacityWhenFull.Year7ToYear11.ToString();
            Year12ToYear14 = pupilNumbers.CapacityWhenFull.Year12ToYear14.ToString();
            SpecialEducationNeeds = pupilNumbers.CapacityWhenFull.SpecialEducationNeeds.ToString();
            AlternativeProvision = pupilNumbers.CapacityWhenFull.AlternativeProvision.ToString();
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
                CapacityWhenFull = new CapacityWhenFull()
                {
                    Nursery = Nursery.ToInt(),
                    ReceptionToYear6 = ReceptionToYear6.ToInt(),
                    Year7ToYear11 = Year7ToYear11.ToInt(),
                    Year12ToYear14 = Year12ToYear14.ToInt(),
                    SpecialEducationNeeds = SpecialEducationNeeds.ToInt(),
                    AlternativeProvision = AlternativeProvision.ToInt()
                }
            };

            await _updatePupilNumbersService.Execute(ProjectId, request);

            return GoToViewPage();
        }
    }
}
