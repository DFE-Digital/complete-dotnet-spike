using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.SupplementalFundingAgreement
{
    public class ViewSupplementalFundingAgreementTaskTaskModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
        
    }
}
