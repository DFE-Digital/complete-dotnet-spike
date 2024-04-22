using AngleSharp.Text;
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
    public class EditPre16PublishedAdmissionNumberModel : EditPupilNumbersBaseModel
    {
        [BindProperty(Name = "reception")]
        [ValidNumberForPupilNumbers]
        public string Reception { get; set; }

        [BindProperty(Name = "year7")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Year 7")]
        public string Year7 { get; set; }

        [BindProperty(Name = "year10")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Year 10")]
        public string Year10 { get; set; }

        [BindProperty(Name = "other-pre16")]
        [ValidNumberForPupilNumbers]
        [Display(Name = "Other pre-16")]
        public string OtherPre16 { get; set; }

        private readonly IGetPupilNumbersService _getPupilNumbersService;
        private readonly IUpdatePupilNumbersService _updatePupilNumbersService;
        private readonly ErrorService _errorService;

        public EditPre16PublishedAdmissionNumberModel(
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

            Reception = pupilNumbers.Pre16PublishedAdmissionNumber.Reception.ToString();
            Year7 = pupilNumbers.Pre16PublishedAdmissionNumber.Year7.ToString();
            Year10 = pupilNumbers.Pre16PublishedAdmissionNumber.Year10.ToString();
            OtherPre16 = pupilNumbers.Pre16PublishedAdmissionNumber.OtherPre16.ToString();
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
                Pre16PublishedAdmissionNumber = new Pre16PublishedAdmissionNumber()
                {
                    Reception = Reception.ToInt(),
                    Year7 = Year7.ToInt(),
                    Year10 = Year10.ToInt(),
                    OtherPre16 = OtherPre16.ToInt()
                }
            };

            await _updatePupilNumbersService.Execute(ProjectId, request);

            return GoToViewPage();
        }
    }
}
