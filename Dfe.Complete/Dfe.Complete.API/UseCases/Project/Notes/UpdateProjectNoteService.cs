using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Notes
{
    public interface IUpdateProjectNoteService
    {
        public Task Execute(Guid projectId, Guid noteId, UpdateProjectNoteRequest request);
    }

    public class UpdateProjectNoteService : IUpdateProjectNoteService
    {
        private readonly CompleteContext _context;

        public UpdateProjectNoteService(CompleteContext completeContext)
        {
            _context = completeContext;
        }

        public async Task Execute(Guid projectId, Guid noteId, UpdateProjectNoteRequest request)
        {
            var note = await _context.GetProjectNoteById(projectId, noteId);

            note.Body = request.Note;

            await _context.SaveChangesAsync();
        }
    }
}
