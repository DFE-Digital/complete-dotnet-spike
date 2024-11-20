using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.UseCases.Project.Conversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion
{
    public class ProjectCreatedModel : PageModel
    {
        private IGetConversionProjectService _getConversionProjectService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public Guid ProjectId { get; set; }

        public GetConversionProjectResponse Project { get; set; }

        public ProjectCreatedModel(IGetConversionProjectService getConversionProjectService)
        {
            _getConversionProjectService = getConversionProjectService;
        }

        public async Task OnGet()
        {
            Project = await _getConversionProjectService.GetConversionProjectById(ProjectId);
        }

        public async Task<IActionResult> OnPost()
        {
            return Redirect($"/conversion-projects/{ProjectId}/tasks");
        }
    }
}
