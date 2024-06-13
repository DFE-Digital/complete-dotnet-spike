using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects
{
    public class ViewProjectNotesModel : PageModel
    {
        private IGetProjectNoteListService _getProjectNoteListService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetProjectNoteListResponse Project { get; set; }

        public ViewProjectNotesModel(IGetProjectNoteListService getProjectNoteListService)
        {
            _getProjectNoteListService = getProjectNoteListService;
        }

        public async Task OnGet()
        {
            Project = await _getProjectNoteListService.Execute(ProjectId);
        }
    }
}
