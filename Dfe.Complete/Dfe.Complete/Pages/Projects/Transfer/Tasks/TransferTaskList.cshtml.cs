using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Transfer.Tasks
{
    public class TransferTaskListModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetTransferProjectByTaskSummaryResponse Tasks { get; set; }
    }
}
