
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.LandQuestionnaire
{
    public class ViewLandQuestionnaireTaskModel : PageModel
    {

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
    }
}
