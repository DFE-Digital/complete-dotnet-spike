using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Notes
{
    public interface IGetProjectNoteService
    {
        public Task<GetProjectNoteResponse> Execute(Guid projectId, Guid noteId);
    }

    public class GetProjectNoteService : IGetProjectNoteService
    {
        private readonly CompleteContext _context;

        public GetProjectNoteService(CompleteContext completeContext)
        {
            _context = completeContext;
        }

        public async Task<GetProjectNoteResponse> Execute(Guid projectId, Guid noteId)
        {
            var note = await _context.GetProjectNoteById(projectId, noteId);

            var createdBy = $"{note.User?.FirstName} {note.User?.LastName}".Trim();

            var result = new GetProjectNoteResponse()
            {
                Id = note.Id,
                Note = note.Body,
                DateCreated = note.CreatedAt,
                CreatedBy = createdBy
            };

            return result;
        }
    }
}
