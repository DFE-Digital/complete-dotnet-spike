using System;
using System.ComponentModel.DataAnnotations;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create
{
    public class RegionModel : CreateProjectBaseModel
    {
        [BindProperty(Name = "region")]
        [Display(Name = "region")]
        [Required(ErrorMessage = "Select the region of the free school")]
        public string Region { get; set; }
        
        private readonly ErrorService _errorService;

        public RegionModel(ErrorService errorService, ICreateProjectCache createProjectCache)
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

            if (project.Region != 0)
                Region = _createProjectCache.Get().Region.ToString();

            BackLink = GetPreviousPage(CreateProjectPageName.Region); 
            return Page();
        }

        public IActionResult OnPost()
        {
            var project = _createProjectCache.Get();
            BackLink = GetPreviousPage(CreateProjectPageName.Region);

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            if (!project.ReachedCheckYourAnswers)
            {
                project.Region = (ProjectRegion)Enum.Parse(typeof(ProjectRegion), Region);
            }
            else
            {
                project.PreviousRegion = (ProjectRegion)Enum.Parse(typeof(ProjectRegion), Region);
            }

            _createProjectCache.Update(project);

            return Redirect("/project/create/localauthority");
        }
    }
}