using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.Services.Project.Transfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Transfer.Tasks.HandoverWithDeliveryOfficer
{
    public class ViewHandoverWithDeliveryOfficerTaskModel : PageModel
    {
        private readonly IGetTransferProjectByTaskService _getTransferProjectByTaskService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetTransferProjectByTaskResponse Project { get; set; }

        public ViewHandoverWithDeliveryOfficerTaskModel(IGetTransferProjectByTaskService getTransferProjectByTaskService)
        {
            _getTransferProjectByTaskService = getTransferProjectByTaskService;
        }

        public async Task OnGet()
        {
            Project = await _getTransferProjectByTaskService.Execute(ProjectId, TransferProjectTaskName.HandoverWithDeliveryOfficer);
        }
    }
}
