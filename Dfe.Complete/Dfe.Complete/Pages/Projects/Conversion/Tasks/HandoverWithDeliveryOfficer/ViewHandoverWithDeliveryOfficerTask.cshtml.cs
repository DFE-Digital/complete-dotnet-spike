using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Services.Project.Conversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.HandoverWithDeliveryOfficer
{
    public class ViewHandoverWithDeliveryOfficerTaskModel : PageModel
    {
        private readonly IGetConversionProjectByTaskService _getConversionProjectByTaskService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetConversionProjectByTaskResponse Project { get; set; }

        public ViewHandoverWithDeliveryOfficerTaskModel(IGetConversionProjectByTaskService getConversionProjectByTaskService)
        {
            _getConversionProjectByTaskService = getConversionProjectByTaskService;
        }

        public async Task OnGet()
        {
            Project = await _getConversionProjectByTaskService.Execute(ProjectId, ConversionProjectTaskName.HandoverWithDeliveryOfficer);
        }
    }
}
