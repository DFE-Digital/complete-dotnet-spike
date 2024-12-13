using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dfe.Complete.Pages.Projects.Transfer.Tasks.HandoverWithDeliveryOfficer
{
    public class ViewHandoverWithDeliveryOfficerTaskModel : PageModel
    {

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
        
    }
}
