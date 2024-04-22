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
    public class EditPost16CapacityBuildupModel : EditPupilNumbersBaseModel
    {
        [BindProperty(Name = "year12", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 12")]
        public CapacityBuildupRowModel Year12 { get; set; }

        [BindProperty(Name = "year13", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 13")]
        public CapacityBuildupRowModel Year13 { get; set; }

        [BindProperty(Name = "year14", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 14")]
        public CapacityBuildupRowModel Year14 { get; set; }

        private readonly IGetPupilNumbersService _getPupilNumbersService;
        private readonly IUpdatePupilNumbersService _updatePupilNumbersService;
        private readonly ErrorService _errorService;

        public EditPost16CapacityBuildupModel(
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

            Year12 = ToRow(pupilNumbers.Post16CapacityBuildup.Year12);
            Year13 = ToRow(pupilNumbers.Post16CapacityBuildup.Year13);
            Year14 = ToRow(pupilNumbers.Post16CapacityBuildup.Year14);
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
                Post16CapacityBuildup = new Post16CapacityBuildup()
                {
                    Year12 = ToCapacityBuildupEntry(Year12),
                    Year13 = ToCapacityBuildupEntry(Year13),
                    Year14 = ToCapacityBuildupEntry(Year14)
                }
            };

            await _updatePupilNumbersService.Execute(ProjectId, request);

            return GoToViewPage();
        }

        private static CapacityBuildupRowModel ToRow(CapacityBuildupEntry entry)
        {
            return new CapacityBuildupRowModel()
            {
                CurrentCapacity = entry.CurrentCapacity.ToString(),
                FirstYear = entry.FirstYear.ToString(),
                SecondYear = entry.SecondYear.ToString(),
                ThirdYear = entry.ThirdYear.ToString(),
                FourthYear = entry.FourthYear.ToString(),
                FifthYear = entry.FifthYear.ToString(),
                SixthYear = entry.SixthYear.ToString(),
                SeventhYear = entry.SeventhYear.ToString()
            };
        }

        private static CapacityBuildupEntry ToCapacityBuildupEntry(CapacityBuildupRowModel row)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = row.CurrentCapacity.ToInt(),
                FirstYear = row.FirstYear.ToInt(),
                SecondYear = row.SecondYear.ToInt(),
                ThirdYear = row.ThirdYear.ToInt(),
                FourthYear = row.FourthYear.ToInt(),
                FifthYear = row.FifthYear.ToInt(),
                SixthYear = row.SixthYear.ToInt(),
                SeventhYear = row.SeventhYear.ToInt()
            };
        }
    }
}
