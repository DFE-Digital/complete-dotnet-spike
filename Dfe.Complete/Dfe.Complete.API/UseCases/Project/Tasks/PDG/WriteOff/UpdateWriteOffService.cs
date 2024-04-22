using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.WriteOff
{
    public class UpdateWriteOffService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateWriteOffService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.WriteOff;
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

            db.ProjectDevelopmentGrantFundingDateOf1stWriteOff = task.WriteOffDate;
            db.ProjectDevelopmentGrantFundingAmountApprovedFor1stWriteOff = task.WriteOffAmount.ToString();
            db.ProjectDevelopmentGrantFundingReasonFor1stWriteOff = task.WriteOffReason;
            db.ProjectDevelopmentGrantFundingFinanceBusinessPartnerApprovalReceivedFrom = task.FinanceBusinessPartnerApprovalReceivedFrom;
            db.ProjectDevelopmentGrantFundingDateWriteOffApprovedByFinanceBusinessPartners = task.ApprovalDate;
        }
    }
}
