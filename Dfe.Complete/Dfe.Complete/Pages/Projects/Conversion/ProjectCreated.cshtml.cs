using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion
{
    public class ProjectCreatedModel : PageModel
    {

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public Guid ProjectId { get; set; }

        // public GetConversionProjectResponse Project { get; set; }
        
        public async Task<IActionResult> OnPost()
        {
            return Redirect($"/conversion-projects/{ProjectId}/tasks");
        }
    }
}
