using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Services.Project.Conversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks
{
    public class ConversionTaskListModel : PageModel
    {
        private readonly IGetConversionProjectByTaskSummaryService _getConversionProjectByTaskSummaryService;

        public ConversionTaskListModel(IGetConversionProjectByTaskSummaryService getConversionProjectByTaskSummaryService)
        {
            _getConversionProjectByTaskSummaryService = getConversionProjectByTaskSummaryService;
        }

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetConversionProjectByTaskSummaryResponse Tasks { get; set; }

        public async Task OnGet()
        {
            Tasks = await _getConversionProjectByTaskSummaryService.Execute(ProjectId);
        }
    }
}
