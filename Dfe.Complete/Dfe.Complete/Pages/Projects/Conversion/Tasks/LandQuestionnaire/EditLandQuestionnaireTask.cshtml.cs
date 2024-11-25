using Dfe.Complete.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.LandQuestionnaire
{
    public class EditLandQuestionnaireTaskModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public Guid ProjectId { get; set; }

        public string SchoolName { get; set; }

        [BindProperty(Name = "cleared")]
        public bool? Cleared { get; set; }

        [BindProperty(Name = "received")]
        public bool? Received { get; set; }

        [BindProperty(Name = "signed")]
        public bool? Signed { get; set; }

        [BindProperty(Name = "saved")]
        public bool? Saved { get; set; }
        
        public async Task<IActionResult> OnPost()
        {
            return Redirect(string.Format(RouteConstants.ConversionLandQuestionnaireTask, ProjectId));
        }
    }
}
