using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Notes
{
    public interface IGetProjectNoteListService
    {
        public Task<GetProjectNoteListResponse> Execute(Guid projectId);
    }

    public class GetProjectNoteListService : IGetProjectNoteListService
    {
        private readonly CompleteContext _context;
        private readonly IGetProjectDetailsService _getProjectDetailsService;

        public GetProjectNoteListService(
            CompleteContext context,
            IGetProjectDetailsService getProjectDetailsService)
        {
            _context = context;
            _getProjectDetailsService = getProjectDetailsService;
        }

        public async Task<GetProjectNoteListResponse> Execute(Guid projectId)
        {
            var project = await _context.GetProjectById(projectId);

            var notes = await _context.Notes
                .Include(n => n.User)
                .Where(n => n.ProjectId == projectId)
                .Select(n => GetProjectNoteResponseBuilder.Execute(n))
                .ToListAsync();

            var projectDetails = await _getProjectDetailsService.Execute(project);

            var result = new GetProjectNoteListResponse()
            {
                ProjectDetails = projectDetails,
                Notes = notes,
            };

            return result;
        }
    }
}
