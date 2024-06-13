using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

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

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                throw new UnprocessableContentException("User with email not found");
            }

            var note = new Note()
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Body = request.Text,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = user.Id,
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
