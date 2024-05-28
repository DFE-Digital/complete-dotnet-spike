using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Notes
{
    public interface IDeleteProjectNoteService
    {
        public Task Execute(Guid projectId, Guid noteId);
    }

    public class DeleteProjectNoteService : IDeleteProjectNoteService
    {
        private readonly CompleteContext _context;

        public DeleteProjectNoteService(CompleteContext completeContext)
        {
            _context = completeContext;
        }

        public async Task Execute(Guid projectId, Guid noteId)
        {
            var note = await _context.GetProjectNoteById(projectId, noteId);

            _context.Remove(note);

            await _context.SaveChangesAsync();
        }
    }
}
