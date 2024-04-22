using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create
{
    public class MethodModel : PageModel
    {
        [BindProperty(Name = "method")]
        [Display(Name = "method")]
        [Required]
        public string Method { get; set; }

        private readonly ErrorService _errorService;
        private readonly ICreateProjectCache _createProjectCache;

        public MethodModel(ErrorService errorService,ICreateProjectCache createProjectCache)
        {
            _createProjectCache = createProjectCache;
            _errorService = errorService;
        }

        public IActionResult OnGet()
        {
            if(!User.IsInRole(RolesConstants.ProjectRecordCreator))
            {
                return new UnauthorizedResult();
            }
            
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            var chosenMethod = (ProjectCreateMethod)Enum.Parse(typeof(ProjectCreateMethod), Method);

            switch (chosenMethod)
            {
                case ProjectCreateMethod.Individual:
                    _createProjectCache.Delete();
                    return Redirect(RouteConstants.CreateProjectId);
                case ProjectCreateMethod.Bulk:
                    return Redirect("/project/create/bulk");
                default:
                    throw new InvalidOperationException($"Unrecognised method {Method}");
            }
        }
    }
}
