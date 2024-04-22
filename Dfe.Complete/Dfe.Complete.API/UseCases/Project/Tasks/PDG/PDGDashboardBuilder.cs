using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.Refunds;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.TrustLetterPDGLetterSent;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.WriteOff;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG
{
    public static class PDGDashboardBuilder
    {
        public static PDGDashboard Build(Po po)
        {
            if (po == null)
            {
                return new PDGDashboard();
            }

            return new PDGDashboard()
            {
                PaymentScheduleAmount = GetPaymentScheduleAmount(po),
                PaymentScheduleDate = GetPaymentScheduleDate(po),
                PaymentActualAmount = GetPaymentActualAmount(po),
                PaymentActualDate = GetPaymentActualDate(po),
                TrustSignedPDGLetterDate = GetTrustSignedPDGLetterDate(po),
                PDGLetterSavedInWorkspaces = GetPDGLetterSavedInWorkspaces(po),
                PaymentStopped = po.ProjectDevelopmentGrantFundingPaymentsStopped,
                LatestRefundDate = RefundsBuilder.Build(po).LatestRefundDate,
                RefundsTotalAmount = RefundsBuilder.Build(po).TotalAmount,
                WriteOffAmount = WriteOffBuilder.Build(po).WriteOffAmount,
                WriteOffReason = WriteOffBuilder.Build(po).WriteOffReason
            };
        }

        private static bool? GetPDGLetterSavedInWorkspaces(Po po)
        {
            var linkSaved = TrustPDGLetterSentBuilder.GetPDGLetterSavedInWorkspaces(po);
            return linkSaved == false ? null : linkSaved;
        }

        private static DateTime? GetTrustSignedPDGLetterDate(Po po)
        {
            if (po.ProjectDevelopmentGrantFunding4thPdgGrantVariationDate != null)
            {
                return po.ProjectDevelopmentGrantFunding4thPdgGrantVariationDate;
            }

            if (po.ProjectDevelopmentGrantFunding3rdPdgGrantVariationDate != null)
            {
                return po.ProjectDevelopmentGrantFunding3rdPdgGrantVariationDate;
            }

            if (po.ProjectDevelopmentGrantFunding2ndPdgGrantVariationDate != null)
            {
                return po.ProjectDevelopmentGrantFunding2ndPdgGrantVariationDate;
            }

            if (po.ProjectDevelopmentGrantFunding1stPdgGrantVariationDate != null)
            {
                return po.ProjectDevelopmentGrantFunding1stPdgGrantVariationDate;
            }

            if (po.ProjectDevelopmentGrantFundingPdgGrantLetterDate != null)
            {
                return po.ProjectDevelopmentGrantFundingPdgGrantLetterDate;
            }

            return null;
        }

        private static decimal? GetPaymentActualAmount(Po po)
        {
            if (po.ProjectDevelopmentGrantFundingAmountOf1stPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf2ndPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf3rdPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf4thPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf5thPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf6thPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf7thPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf8thPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf9thPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf10thPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf11thPayment == null &&
                po.ProjectDevelopmentGrantFundingAmountOf12thPayment == null)
                return null;

            return ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf1stPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf2ndPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf3rdPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf4thPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf5thPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf6thPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf7thPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf8thPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf9thPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf10thPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf11thPayment) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf12thPayment);
        }

        private static decimal? GetPaymentScheduleAmount(Po po)
        {
            if (po.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf4thPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf5thPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf6thPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf7thPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf8thPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf9thPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf10thPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf11thPaymentDue == null &&
                po.ProjectDevelopmentGrantFundingAmountOf12thPaymentDue == null)
                return null;

            return ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf4thPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf5thPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf6thPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf7thPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf8thPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf9thPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf10thPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf11thPaymentDue) +
                   ParseDecimal(po.ProjectDevelopmentGrantFundingAmountOf12thPaymentDue);
        }

        private static DateTime? GetPaymentScheduleDate(Po po)
        {
            if (po.ProjectDevelopmentGrantFundingDateOf12thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf12thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf11thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf11thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf10thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf10thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf9thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf9thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf8thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf8thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf7thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf7thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf6thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf6thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf5thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf5thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf4thPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf4thPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf3rdPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf3rdPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf2ndPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf2ndPaymentDue;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf1stPaymentDue != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf1stPaymentDue;
            }

            return null;
        }

        private static DateTime? GetPaymentActualDate(Po po)
        {

            if (po.ProjectDevelopmentGrantFundingDateOf12thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf12thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf11thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf11thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf10thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf10thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf9thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf9thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf8thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf8thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf7thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf7thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf6thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf6thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf5thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf5thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf4thActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf4thActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf3rdActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf3rdActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf2ndActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf2ndActualPayment;
            }

            if (po.ProjectDevelopmentGrantFundingDateOf1stActualPayment != null)
            {
                return po.ProjectDevelopmentGrantFundingDateOf1stActualPayment;
            }

            return null;
        }

        private static decimal ParseDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            return decimal.Parse(value);
        }


    }
}
