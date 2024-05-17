using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.Services.Project.Conversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion
{
    public class AboutConversionProjectModel : PageModel
    {
        private IGetConversionProjectService _getConversionProjectService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetConversionProjectResponse Project { get; set; }

        public AboutConversionProjectModel(IGetConversionProjectService getConversionProjectService)
        {
            _getConversionProjectService = getConversionProjectService;
        }

        public async Task OnGet()
        {
            Project = await _getConversionProjectService.Execute(ProjectId);
        }
    }
}
