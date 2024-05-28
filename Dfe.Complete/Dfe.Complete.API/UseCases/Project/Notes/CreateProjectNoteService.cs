using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Notes
{
    public interface ICreateProjectNoteService
    {
        public Task<CreateProjectNoteResponse> Execute(Guid projectId, CreateProjectNoteRequest request);
    }

    public class CreateProjectNoteService : ICreateProjectNoteService
    {
        private readonly CompleteContext _context;

        public CreateProjectNoteService(CompleteContext completeContext)
        {
            _context = completeContext;
        }

        public async Task<CreateProjectNoteResponse> Execute(Guid projectId, CreateProjectNoteRequest request)
        {
            await _context.GetProjectById(projectId);

            var note = new Note()
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Body = request.Note,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.Notes.Add(note);

            await _context.SaveChangesAsync();

            var result = new CreateProjectNoteResponse()
            {
                Id = note.Id,
            };

            return result;
        }
    }
}
