using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project
{
    public interface IGetProjectListService
    {
        public Task<List<ProjectListEntryResponse>> Execute();
    }

    public class GetProjectListService : IGetProjectListService
    {
        private readonly CompleteContext _context;

        public GetProjectListService(CompleteContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectListEntryResponse>> Execute()
        {
            var result = await _context.Projects
                .Include(p => p.AssignedTo)
                .Where(p => p.State == ProjectState.Active && p.AssignedToId != null)
                .Select(p => new ProjectListEntryResponse
                {
                    Id = p.Id,
                    Urn = p.Urn,
                    ConversionOrTransferDate = p.SignificantDate,
                    ProjectType = p.Type,
                    AssignedTo = $"{p.AssignedTo.FirstName} {p.AssignedTo.LastName}"
                })
                .OrderBy(p => p.ConversionOrTransferDate)
                .ToListAsync();

            return result;
        }
    }
}
