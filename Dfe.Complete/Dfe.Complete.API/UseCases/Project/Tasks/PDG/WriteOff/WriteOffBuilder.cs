using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.WriteOff
{
    public class WriteOffBuilder
    {
        public static WriteOffTask Build(Po po)
        {
            if (po == null)
            {
                return new WriteOffTask();
            }

            return new WriteOffTask()
            {
                WriteOffReason = po.ProjectDevelopmentGrantFundingReasonFor1stWriteOff,
                WriteOffAmount = ParseDecimal(po.ProjectDevelopmentGrantFundingAmountApprovedFor1stWriteOff),
                WriteOffDate = po.ProjectDevelopmentGrantFundingDateOf1stWriteOff,
                FinanceBusinessPartnerApprovalReceivedFrom = po.ProjectDevelopmentGrantFundingFinanceBusinessPartnerApprovalReceivedFrom,
                ApprovalDate = po.ProjectDevelopmentGrantFundingDateWriteOffApprovedByFinanceBusinessPartners,
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
