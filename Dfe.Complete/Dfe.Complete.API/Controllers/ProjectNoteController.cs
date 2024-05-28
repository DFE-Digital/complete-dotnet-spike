using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.API.UseCases.Project.Notes;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.Complete.API.Controllers
{
    [Route("api/v{version:apiVersion}/client/projects/{projectId}/notes")]
    [ApiController]
    [Tags("Project Note (Client only)")]
    public class ProjectNoteController : ControllerBase
    {
        private readonly IGetProjectNoteService _getProjectNoteService;
        private readonly ICreateProjectNoteService _createProjectNoteService;
        private readonly IUpdateProjectNoteService _updateProjectNoteService;
        private readonly IDeleteProjectNoteService _deleteProjectNoteService;

        public ProjectNoteController(
            IGetProjectNoteService getProjectNoteService, 
            ICreateProjectNoteService createProjectNoteService,
            IUpdateProjectNoteService updateProjectNoteService,
            IDeleteProjectNoteService deleteProjectNoteService)
        {
            _getProjectNoteService = getProjectNoteService;
            _createProjectNoteService = createProjectNoteService;
            _updateProjectNoteService = updateProjectNoteService;
            _deleteProjectNoteService = deleteProjectNoteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectNote(Guid projectId, CreateProjectNoteRequest request)
        {
            var projectNote = await _createProjectNoteService.Execute(projectId, request);

            return CreatedAtAction(nameof(GetProjectNote), new { projectId, noteId = projectNote.Id }, projectNote);
        }

        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetProjectNote(Guid projectId, Guid noteId)
        {
            var projectNote = await _getProjectNoteService.Execute(projectId, noteId);

            return new OkObjectResult(projectNote);
        }

        [HttpPatch("{noteId}")]
        public async Task<IActionResult> UpdateProjectNote(Guid projectId, Guid noteId, UpdateProjectNoteRequest request)
        {
            await _updateProjectNoteService.Execute(projectId, noteId, request);

            return new OkObjectResult(new object());
        }

        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteProjectNote(Guid projectId, Guid noteId)
        {
            await _deleteProjectNoteService.Execute(projectId, noteId);

            return new OkObjectResult(new object());
        }
    }
}
