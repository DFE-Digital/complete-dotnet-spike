using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.Refunds
{
    public static class RefundsBuilder
    {
        public static RefundsTask Build(Po po)
        {
            if (po == null)
            {
                return new RefundsTask();
            }

            return new RefundsTask()
            {
                LatestRefundDate = GetPaymentScheduleDate(po),
                TotalAmount = GetTotalAmount(po),
            };
        }

        private static decimal? GetTotalAmount(Po po)
        {
            if (po.ProjectDevelopmentGrantFundingAmountOf1stRefund == null &&
                po.ProjectDevelopmentGrantFundingAmountOf2ndRefund == null &&
                po.ProjectDevelopmentGrantFundingAmountOf3rdRefund == null)
                return null;

            return ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf1stRefund) +
                    ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf2ndRefund) +
                    ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf3rdRefund);
        }


        private static DateTime? GetPaymentScheduleDate(Po po)
        {
            
            if (po.ProjectDevelopmentGrantFundingDateOf3rdRefund != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf3rdRefund;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf2ndRefund != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf2ndRefund;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf1stRefund != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf1stRefund;
            }

            return null;
        }

        private static decimal? ParseDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            return decimal.Parse(value);
        }

    }
}


