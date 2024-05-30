using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Notes
{
    public static class GetProjectNoteResponseBuilder
    {
        public static GetProjectNoteResponse Execute(Note note)
        {
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
