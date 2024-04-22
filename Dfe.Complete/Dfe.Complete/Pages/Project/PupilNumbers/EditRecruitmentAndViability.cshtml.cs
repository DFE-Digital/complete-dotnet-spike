using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Extensions;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    public class EditRecruitmentAndViabilityModel : EditPupilNumbersBaseModel
    {
        [BindProperty]
        public EditRecruitmentAndViabilityRowModel ReceptionToYear6 { get; set; }

        [BindProperty]
        public EditRecruitmentAndViabilityRowModel Year7ToYear11 { get; set; }

        [BindProperty]
        public EditRecruitmentAndViabilityRowModel Year12ToYear14 { get; set; }

        private readonly IGetPupilNumbersService _getPupilNumbersService;
        private readonly IUpdatePupilNumbersService _updatePupilNumbersService;
        private readonly ErrorService _errorService;

        public EditRecruitmentAndViabilityModel(
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

            ReceptionToYear6 = ToRowModel(pupilNumbers.RecruitmentAndViability.ReceptionToYear6);
            Year7ToYear11 = ToRowModel(pupilNumbers.RecruitmentAndViability.Year7ToYear11);
            Year12ToYear14 = ToRowModel(pupilNumbers.RecruitmentAndViability.Year12ToYear14);
            SchoolName = pupilNumbers.SchoolName;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                PrefixModelErrors();
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            var request = new UpdatePupilNumbersRequest()
            {
                RecruitmentAndViability = new RecruitmentAndViability()
                {
                    ReceptionToYear6 = ToRecruitmentAndViabilityEntry(ReceptionToYear6),
                    Year7ToYear11 = ToRecruitmentAndViabilityEntry(Year7ToYear11),
                    Year12ToYear14 = ToRecruitmentAndViabilityEntry(Year12ToYear14)
                }
            };

            await _updatePupilNumbersService.Execute(ProjectId, request);

            return GoToViewPage();
        }

        /// <summary>
        /// Because we use a nested structure if we don't prefix the same error will be repeated for every piece of data
        /// </summary>
        private void PrefixModelErrors()
        {
            foreach (var modelKey in ModelState.Keys)
            {
                var modelError = ModelState[modelKey];

                if (modelError.ValidationState != ModelValidationState.Invalid)
                {
                    continue;
                }

                var displayName = GetDisplayNamePrefix(modelKey.Split(".").First());

                var updatedErrors = modelError.Errors.Select(e =>
                {
                    return new ModelError($"{displayName} {e.ErrorMessage}");
                }).ToList();

                modelError.Errors.Clear();

                updatedErrors.ForEach(modelError.Errors.Add);
            }
        }

        /// <summary>
        /// This must map to the name of the property in the model
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetDisplayNamePrefix(string name)
        {
            switch (name)
            {
                case nameof(ReceptionToYear6):
                    return "Reception to year 6";
                case nameof(Year7ToYear11):
                    return "Year 7 to year 11";
                case nameof(Year12ToYear14):
                    return "Year 12 to year 14";
                default:
                    return "";
            }
        }

        private static EditRecruitmentAndViabilityRowModel ToRowModel(RecruitmentAndViabilityEntry entry)
        {
            return new EditRecruitmentAndViabilityRowModel()
            {
                MinimumViableNumber = entry.MinimumViableNumber.ToString(),
                ApplicationsReceived = entry.ApplicationsReceived.ToString()
            };
        }

        private static RecruitmentAndViabilityEntry ToRecruitmentAndViabilityEntry(EditRecruitmentAndViabilityRowModel rowModel)
        {
            return new RecruitmentAndViabilityEntry()
            {
                MinimumViableNumber = rowModel.MinimumViableNumber.ToInt(),
                ApplicationsReceived = rowModel.ApplicationsReceived.ToInt()
            };
        }
    }

    public class EditRecruitmentAndViabilityRowModel
    {
        [ValidNumberForPupilNumbers]
        [Display(Name = "minimum viable number")]
        public string MinimumViableNumber { get; set; }

        [ValidNumberForPupilNumbers]
        [Display(Name = "applications received")]
        public string ApplicationsReceived { get; set; }
    }
}
