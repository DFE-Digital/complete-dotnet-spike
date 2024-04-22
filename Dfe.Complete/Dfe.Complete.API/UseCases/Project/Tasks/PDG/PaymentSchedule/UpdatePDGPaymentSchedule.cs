using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.PaymentSchedule
{
    public class UpdatePDGPaymentSchedule : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdatePDGPaymentSchedule(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.PaymentSchedule;
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

            db.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = task.PaymentScheduleAmount?.ToString("0.00");
            db.ProjectDevelopmentGrantFundingAmountOf1stPayment = task.PaymentActualAmount?.ToString("0.00");
            db.ProjectDevelopmentGrantFundingDateOf1stPaymentDue = task.PaymentScheduleDate;
            db.ProjectDevelopmentGrantFundingDateOf1stActualPayment = task.PaymentActualDate;

            db.ProjectDevelopmentGrantFundingInitialGrantAllocation = task.PaymentScheduleAmount?.ToString("0.00");
            db.ProjectDevelopmentGrantFundingRevisedGrantAllocation = task.PaymentScheduleAmount?.ToString("0.00");
            db.ProjectDevelopmentGrantFundingTotalPaymentsMade = task.PaymentActualAmount?.ToString("0.00");
        }
    }
}
