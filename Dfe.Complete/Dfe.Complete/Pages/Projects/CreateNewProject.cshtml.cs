using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects
{
    public class CreateNewProjectModel : PageModel
    {
        [BindProperty]
        public string ProjectType { get; set; }

        public CreateNewProjectModel()
        {
        }

        public async Task OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var pageToRedirectTo = string.Empty;

            switch (ProjectType)
            {
                case "conversion":
                    pageToRedirectTo = "/Projects/Conversion/CreateNewProject";
                break;
                default:
                    break;
            }

            return RedirectToPage(pageToRedirectTo);
        }
    }
}
