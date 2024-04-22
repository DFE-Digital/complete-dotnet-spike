using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.PaymentSchedule
{
    public static class PaymentScheduleBuilder
    {
        public static PaymentScheduleTask Build(Po po)
        {
            if (po == null)
            {
                return new PaymentScheduleTask();
            }

            return new PaymentScheduleTask()
            {
                PaymentScheduleAmount = ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue),
                PaymentScheduleDate = po.ProjectDevelopmentGrantFundingDateOf1stPaymentDue,
                PaymentActualAmount = ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf1stPayment),
                PaymentActualDate = po.ProjectDevelopmentGrantFundingDateOf1stActualPayment,
            };
        }

        private static decimal? ParseDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return decimal.Parse(value);
        }
    }
}
