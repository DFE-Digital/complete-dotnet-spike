using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual;
using Dfe.ManageFreeSchoolProjects.Utils;
using static Dfe.ManageFreeSchoolProjects.API.Contracts.Project.ClassType;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create
{
    public class CapacityModel : CreateProjectBaseModel
    {

        [BindProperty(Name = "nursery-capacity")]
        [Display(Name = "Nursery capacity")]
        [ValidNumber(0, 9999)]
        public string NurseryCapacity { get; set; }

        [BindProperty(Name = "yr-y6-capacity")]
        [Display(Name = "Reception to year 6 capacity")]
        [Required(ErrorMessage = "Enter the Reception - Year 6 Capacity")]
        [ValidNumber(0,9999)]
        public string YRY6Capacity { get; set; }

        [BindProperty(Name = "y7-y11-capacity")]
        [Display(Name = "Year 7 to year 11 capacity")]
        [Required(ErrorMessage = "Enter the Year 7 - Year 11 Capacity")]
        [ValidNumber(0,9999)]
        public string Y7Y11Capacity { get; set; }

        [BindProperty(Name = "y12-y14-capacity")]
        [Display(Name = "Year 12 to year 14 capacity")]
        [Required(ErrorMessage = "Enter the Year 12 - Year 14 Capacity")]
        [ValidNumber(0,9999)]
        public string Y12Y14Capacity { get; set; }

        public Nursery HasNursery { get; set; }

        private readonly ErrorService _errorService;

        public CapacityModel(ErrorService errorService, ICreateProjectCache createProjectCache)
            : base(createProjectCache)
        {
            _errorService = errorService;
        }

        public IActionResult OnGet()
        {
            if (!User.IsInRole(RolesConstants.ProjectRecordCreator))
            {
                return new UnauthorizedResult();
            }

            var project = _createProjectCache.Get();
            NurseryCapacity = project.NurseryCapacity.ToString();
            YRY6Capacity = project.YRY6Capacity.ToString();
            Y7Y11Capacity = project.Y7Y11Capacity.ToString();
            Y12Y14Capacity = project.Y12Y14Capacity.ToString();
            HasNursery = project.Nursery;

            BackLink = GetPreviousPage(CreateProjectPageName.Capacity);

            return Page();
        }

        public IActionResult OnPost()
        {
            var project = _createProjectCache.Get();
            BackLink = GetPreviousPage(CreateProjectPageName.Capacity);
            HasNursery = project.Nursery;

            if (HasNursery == Nursery.Yes && string.IsNullOrEmpty(NurseryCapacity))
            {
                ModelState.AddModelError("nursery-capacity", "Enter the Nursery Capacity");
            }

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            project.NurseryCapacity = !string.IsNullOrEmpty(NurseryCapacity) ? int.Parse(NurseryCapacity) : 0;
            project.YRY6Capacity = int.Parse(YRY6Capacity);
            project.Y7Y11Capacity = int.Parse(Y7Y11Capacity);
            project.Y12Y14Capacity = int.Parse(Y12Y14Capacity);
            _createProjectCache.Update(project);

            return Redirect(GetNextPage(CreateProjectPageName.Capacity));
        }
    }
}
