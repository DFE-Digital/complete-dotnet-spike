using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Extensions;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    public class EditPre16CapacityBuildupModel : EditPupilNumbersBaseModel
    {
        [BindProperty(Name = "nursery", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Nursery")]
        public CapacityBuildupRowModel Nursery { get; set; }

        [BindProperty(Name = "reception", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Reception")]
        public CapacityBuildupRowModel Reception { get; set; }

        [BindProperty(Name = "year1", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 1")]
        public CapacityBuildupRowModel Year1 { get; set; }

        [BindProperty(Name = "year2", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 2")]
        public CapacityBuildupRowModel Year2 { get; set; }

        [BindProperty(Name = "year3", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 3")]
        public CapacityBuildupRowModel Year3 { get; set; }

        [BindProperty(Name = "year4", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 4")]
        public CapacityBuildupRowModel Year4 { get; set; }

        [BindProperty(Name = "year5", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 5")]
        public CapacityBuildupRowModel Year5 { get; set; }

        [BindProperty(Name = "year6", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 6")]
        public CapacityBuildupRowModel Year6 { get; set; }

        [BindProperty(Name = "year7", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 7")]
        public CapacityBuildupRowModel Year7 { get; set; }

        [BindProperty(Name = "year8", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 8")]
        public CapacityBuildupRowModel Year8 { get; set; }

        [BindProperty(Name = "year9", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 9")]
        public CapacityBuildupRowModel Year9 { get; set; }

        [BindProperty(Name = "year10", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 10")]
        public CapacityBuildupRowModel Year10 { get; set; }

        [BindProperty(Name = "year11", BinderType = typeof(CapacityBuildupRowModelBinder))]
        [Display(Name = "Year 11")]
        public CapacityBuildupRowModel Year11 { get; set; }

        private readonly IGetPupilNumbersService _getPupilNumbersService;
        private readonly IUpdatePupilNumbersService _updatePupilNumbersService;
        private readonly ErrorService _errorService;

        public EditPre16CapacityBuildupModel(
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

            Nursery = ToRow(pupilNumbers.Pre16CapacityBuildup.Nursery);
            Reception = ToRow(pupilNumbers.Pre16CapacityBuildup.Reception);
            Year1 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year1);
            Year2 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year2);
            Year3 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year3);
            Year4 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year4);
            Year5 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year5);
            Year6 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year6);
            Year7 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year7);
            Year8 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year8);
            Year9 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year9);
            Year10 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year10);
            Year11 = ToRow(pupilNumbers.Pre16CapacityBuildup.Year11);
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
                Pre16CapacityBuildup = new Pre16CapacityBuildup()
                {
                    Nursery = ToCapacityBuildupEntry(Nursery),
                    Reception = ToCapacityBuildupEntry(Reception),
                    Year1 = ToCapacityBuildupEntry(Year1),
                    Year2 = ToCapacityBuildupEntry(Year2),
                    Year3 = ToCapacityBuildupEntry(Year3),
                    Year4 = ToCapacityBuildupEntry(Year4),
                    Year5 = ToCapacityBuildupEntry(Year5),
                    Year6 = ToCapacityBuildupEntry(Year6),
                    Year7 = ToCapacityBuildupEntry(Year7),
                    Year8 = ToCapacityBuildupEntry(Year8),
                    Year9 = ToCapacityBuildupEntry(Year9),
                    Year10 = ToCapacityBuildupEntry(Year10),
                    Year11 = ToCapacityBuildupEntry(Year11)
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

    public class CapacityBuildupRowModel
    {
        public string CurrentCapacity { get; set; }
        public string FirstYear { get; set; }
        public string SecondYear { get; set; }
        public string ThirdYear { get; set; }
        public string FourthYear { get; set; }
        public string FifthYear { get; set; }
        public string SixthYear { get; set; }
        public string SeventhYear { get; set; }
    }
}
