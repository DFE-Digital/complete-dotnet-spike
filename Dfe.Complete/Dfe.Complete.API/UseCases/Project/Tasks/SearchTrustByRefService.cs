using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks
{
    public interface ISearchTrustByRefService
    {
        public Task<(List<SearchTrustByRefResponse>, int)> Execute(string searchTerm);
    }

    public class SearchTrustByRefService : ISearchTrustByRefService
    {
        private readonly MfspContext _context;

        public SearchTrustByRefService(MfspContext context)
        {
            _context = context;
        }

        public async Task<(List<SearchTrustByRefResponse>, int)> Execute(string searchTerm)
        {
            var query = _context.Trust.AsQueryable();

            query = query.Where(trust => trust.TrustRef.Contains(searchTerm));

            var count = query.Count();

            var projectRecords = await query.OrderBy(trust => trust.TrustRef).Take(10).ToListAsync();

            var result = projectRecords.Select(record =>
            {
                return new SearchTrustByRefResponse()
                {
                    Trust = new TrustTask()
                    {
                        TRN = record.TrustRef,
                        TrustName = record.TrustsTrustName,
                        TrustType = ProjectMapper.ToTrustType(record.TrustsTrustType),
                    }
                };
            }).ToList();

            return (result, count);
        }
    }
}
