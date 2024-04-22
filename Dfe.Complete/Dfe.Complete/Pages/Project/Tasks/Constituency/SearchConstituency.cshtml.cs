using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.School;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Validators;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.Constituency
{
    public class SearchConstituencyModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name="search-constituency")]
        [Display(Name = "Name or postcode")]
        [Required(ErrorMessage = "Enter a name or postcode. For example, South London or W1A 1AA")]
        [ValidText(50)]
        public string SearchConstituency { get; set; }

        [BindProperty]
        public string CurrentFreeSchoolName { get; set; }

        private readonly ILogger<ViewSchoolTask> _logger;
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly ErrorService _errorService;

        public SearchConstituencyModel(
            IGetProjectByTaskService getProjectService,
            ILogger<ViewSchoolTask> logger,
            ErrorService errorService)
        {
            _logger = logger;
            _errorService = errorService;
            _getProjectService = getProjectService;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            var project = await _getProjectService.Execute(ProjectId, TaskName.Constituency);

            CurrentFreeSchoolName = project.SchoolName;

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.Constituency);
            CurrentFreeSchoolName = project.SchoolName;

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            return Redirect(string.Format(RouteConstants.EditConstituency, ProjectId, SearchConstituency));
        }
    }
}
