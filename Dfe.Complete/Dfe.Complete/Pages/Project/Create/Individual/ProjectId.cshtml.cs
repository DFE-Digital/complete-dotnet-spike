using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual
{
    public class ProjectIdModel : CreateProjectBaseModel
    {
        [BindProperty(Name = "projectid")]
        [Display(Name = "temporary project ID")]
        [Required(ErrorMessage = "The temporary project ID field is required")]
        [StringLength(25, ErrorMessage = ValidationConstants.TextValidationMessage)]
        public string ProjectId { get; set; }
        
        private readonly ErrorService _errorService;
        private readonly IGetProjectOverviewService _getProjectOverviewService;

        public ProjectIdModel(ErrorService errorService, ICreateProjectCache createProjectCache, IGetProjectOverviewService getProjectOverviewService)
            :base(createProjectCache)
        {
            _errorService = errorService;
            _getProjectOverviewService = getProjectOverviewService;
        }

        public IActionResult OnGet()
        {
            if (!IsUserAuthorised())
            {
                return new UnauthorizedResult();
            }


            var project = _createProjectCache.Get();
            ProjectId = project.ProjectId;
            
            BackLink = GetPreviousPage(CreateProjectPageName.ProjectId);
           
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var project = _createProjectCache.Get();
            BackLink = GetPreviousPage(CreateProjectPageName.ProjectId);

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            if (ProjectId.Contains(' '))
            {
                ModelState.AddModelError("projectid", "Temporary project ID must not include spaces");
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            if (Regex.Match(ProjectId,  "[^a-zA-Z\\d\\s:]", RegexOptions.None, TimeSpan.FromSeconds(5)).Success)
            {
                ModelState.AddModelError("projectid", "Temporary project ID must only include numbers and letters");
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            try
            {
                //Attempt to get project, will throw an exception when 404 is returned
                await _getProjectOverviewService.Execute(ProjectId);
                ModelState.AddModelError("projectid", "Project Id already exists");
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            project.ProjectId = ProjectId;
            _createProjectCache.Update(project);

            return Redirect(GetNextPage(CreateProjectPageName.ProjectId));
        }
    }
}
