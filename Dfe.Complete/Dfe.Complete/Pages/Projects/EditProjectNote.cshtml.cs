using Dfe.Complete.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects
{
    public class EditProjectNoteModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(SupportsGet = true, Name = "noteId")]
        public string NoteId { get; set; }

        [BindProperty(Name = "note-text")]
        public string NoteText { get; set; }
        

        public async Task OnGet()
        {
            if (NoteExists())
            {
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (NoteExists())
            {
            }
            else
            {
            }

            return Redirect(string.Format(RouteConstants.ProjectViewNotes, ProjectId));
        }

        private bool NoteExists()
        {
            return !string.IsNullOrEmpty(NoteId);
        }
    }
}
