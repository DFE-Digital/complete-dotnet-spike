using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.All
{
    public class ProjectsInProgressModel : PageModel
    {
        private readonly IGetProjectListService _getProjectListService;

        public List<ProjectListEntryResponse> Projects { get; set; }

        public ProjectsInProgressModel(IGetProjectListService getProjectListService)
        {
            _getProjectListService = getProjectListService;
        }

        public async Task OnGet()
        {
            var response = await _getProjectListService.Execute();
            Projects = response.Data.ToList();
        }
    }
}
