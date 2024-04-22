using System.ComponentModel.DataAnnotations;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual
{
    public class SchoolModel : CreateProjectBaseModel
    {
        [BindProperty(Name = "school")]
        [Display(Name = "School name")]
        [Required(ErrorMessage = "Enter the current free school name")]
        [ValidText(100)]
        public string School { get; set; }
        
        private readonly ErrorService _errorService;

        public SchoolModel(ErrorService errorService, ICreateProjectCache createProjectCache)
            :base(createProjectCache)
        {
            _errorService = errorService;
        }

        public IActionResult OnGet()
        {
            if (!IsUserAuthorised())
            {
                return new UnauthorizedResult();
            }

            var project = _createProjectCache.Get();
            School = project.SchoolName;
            BackLink = GetPreviousPage(CreateProjectPageName.SchoolName);

            return Page();
        }

        public IActionResult OnPost()
        {
            var project = _createProjectCache.Get();
            BackLink = GetPreviousPage(CreateProjectPageName.SchoolName);

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            project.SchoolName = School;
            _createProjectCache.Update(project);

            return Redirect(GetNextPage(CreateProjectPageName.SchoolName));
        }
    }
}
