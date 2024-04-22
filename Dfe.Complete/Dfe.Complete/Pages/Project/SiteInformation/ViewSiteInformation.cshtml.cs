using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.SiteInformation
{
    public class ViewSiteInformationModel : PageModel
    {
        private readonly IGetProjectSitesService _getProjectSitesService;
        private readonly ILogger<ViewSiteInformationModel> _logger;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetProjectSitesResponse SiteInformation { get; set; }

        public ViewSiteInformationModel(
            IGetProjectSitesService getProjectSitesService,
            ILogger<ViewSiteInformationModel> logger)
        {
            _getProjectSitesService = getProjectSitesService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            SiteInformation = await _getProjectSitesService.Execute(ProjectId);

            return Page();
        }
    }
}
