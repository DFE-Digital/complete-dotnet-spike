using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Dashboard
{
    public interface IGetProjectManagersService
    {
        public Task<GetProjectManagersResponse> Execute();
    }

    public class GetProjectManagersService : IGetProjectManagersService
    {
        private readonly MfspContext _context;

        public GetProjectManagersService(MfspContext context)
        {
            _context = context;
        }

        public async Task<GetProjectManagersResponse> Execute()
        {
            GetProjectManagersResponse projectManagers = new GetProjectManagersResponse();
            projectManagers.ProjectManagers = await _context.Kpi.Where(k => !string.IsNullOrEmpty(k.KeyContactsFsgLeadContact))
                                                                .OrderBy(k => k.KeyContactsFsgLeadContact)
                                                                .Select(k => k.KeyContactsFsgLeadContact)
                                                                .Distinct()
                                                                .ToListAsync();

            return projectManagers;
        }
    }
}