using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.Refunds
{
    public class UpdateRefundsService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateRefundsService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.Refunds;
            var dbKpi = parameters.Kpi;

            if (task is null)
            {
                return;
            }

            var db = await _context.Po.FirstOrDefaultAsync(r => r.Rid == dbKpi.Rid);

            if (db == null)
            {
                db = new Po();
                db.Rid = dbKpi.Rid;
                _context.Add(db);
            }

            db.ProjectDevelopmentGrantFundingDateOf1stRefund = task.LatestRefundDate;
            db.ProjectDevelopmentGrantFundingAmountOf1stRefund = task.TotalAmount?.ToString("0.00");
        }
    }
}
