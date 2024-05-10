using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.Services.Project.Transfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Transfer.Tasks
{
    public class TransferTaskListModel : PageModel
    {
        private readonly IGetTransferProjectByTaskSummaryService _getTransferProjectByTaskSummaryService;

        public TransferTaskListModel(IGetTransferProjectByTaskSummaryService getTransferProjectByTaskSummaryService)
        {
            _getTransferProjectByTaskSummaryService = getTransferProjectByTaskSummaryService;
        }

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetTransferProjectByTaskSummaryResponse Tasks { get; set; }

        public async Task OnGet()
        {
            Tasks = await _getTransferProjectByTaskSummaryService.Execute(ProjectId);
        }
    }
}
