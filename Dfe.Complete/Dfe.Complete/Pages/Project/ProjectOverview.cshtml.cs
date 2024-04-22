using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project
{
    public class ProjectOverviewModel : PageModel
    {
        private readonly IGetProjectOverviewService _getProjectOverviewService;
        private readonly ILogger<ProjectOverviewModel> _logger;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public ProjectOverviewResponse Project { get; set; }

        public ProjectOverviewModel(
            IGetProjectOverviewService getProjectOverviewService,
            ILogger<ProjectOverviewModel> logger)
        {
            _getProjectOverviewService = getProjectOverviewService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            try
            {
                var projectId = RouteData.Values["projectId"] as string;

                Project = await _getProjectOverviewService.Execute(projectId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
            }

            return Page();
        }
    }
}
