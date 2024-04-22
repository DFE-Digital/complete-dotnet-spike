
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Trusts
{
    public class UpdateTrustTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateTrustTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.Trust;
            var dbKpi = parameters.Kpi;

            if (task == null)
            {
                return;
            }
            var trust = await GetTrust(task.TRN);

            dbKpi.TrustId = trust.TrustRef;
            dbKpi.TrustName = trust.TrustsTrustName;
            dbKpi.TrustType = trust.TrustsTrustType;

            dbKpi.SchoolDetailsTrustId = trust.TrustsTrustRef;
            dbKpi.SchoolDetailsTrustName = trust.TrustsTrustName;
            dbKpi.SchoolDetailsTrustType = trust.TrustsTrustType;
        }

        private async Task<Trust> GetTrust(string trustRef)
        {
            var result = await _context.Trust.FirstOrDefaultAsync(e => e.TrustRef == trustRef);

            return result;
        }
    }
}
