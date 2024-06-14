using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.Constants;
using Dfe.Complete.Services.Project;
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

        private readonly IGetProjectNoteService _getProjectNoteService;
        private readonly ICreateProjectNoteService _createProjectNoteService;
        private readonly IUpdateProjectNoteService _updateProjectNoteService;

        public EditProjectNoteModel(
            ICreateProjectNoteService createProjectNoteService,
            IGetProjectNoteService getProjectNote,
            IUpdateProjectNoteService updateProjectNoteService)
        {
            _createProjectNoteService = createProjectNoteService;
            _getProjectNoteService = getProjectNote;
            _updateProjectNoteService = updateProjectNoteService;
        }

        public async Task OnGet()
        {
            if (NoteExists())
            {
                var note = await _getProjectNoteService.Execute(ProjectId, NoteId);
                NoteText = note.Text;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (NoteExists())
            {
                await _updateProjectNoteService.Execute(ProjectId, NoteId, new UpdateProjectNoteRequest
                {
                    Text = NoteText,
                });
            }
            else
            {
                await _createProjectNoteService.Execute(ProjectId, new CreateProjectNoteRequest()
                {
                    Text = NoteText,
                    Email = User?.Identity?.Name,
                });
            }

            return Redirect(string.Format(RouteConstants.ProjectViewNotes, ProjectId));
        }

        private bool NoteExists()
        {
            return !string.IsNullOrEmpty(NoteId);
        }
    }
}
