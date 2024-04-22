using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Reports
{
    public static class SfaReportBuilder
    {
        private const string NotAvailable = "NA";

        public static SfaReport Build(List<SfaReportSourceData> sourceData)
        {
            var result = new SfaReport();

            foreach (var project in sourceData)
            {
                var entry = new SfaReportEntry()
                {
                    SchoolName = RemoveCommas(project.Kpi.ProjectStatusCurrentFreeSchoolName),
                    Id = project.Kpi.ProjectStatusProjectId,
                    ProjectStatus = project.Kpi.ProjectStatusProjectStatus,
                    Type = project.Kpi.SchoolDetailsSchoolTypeMainstreamApEtc,
                    Phase = project.Kpi.SchoolDetailsSchoolPhasePrimarySecondary,
                    EntryPo = project.Kpi.ProjectStatusDateOfEntryIntoPreOpening.ToUkDateString(),
                    Wave = project.Kpi.ProjectStatusFreeSchoolApplicationWave,
                    ProvisionalOpeningDate = project.Kpi.ProjectStatusProvisionalOpeningDateAgreedWithTrust.ToUkDateString(),
                    Ryo = project.Kpi.ProjectStatusRealisticYearOfOpening,
                    OpeningDate = project.Kpi.ProjectStatusActualOpeningDate.ToUkDateString(),
                    Sfc = project.Kpi.SchoolDetailsSixthForm,
                    Ind = project.Kpi.SchoolDetailsIndependentConverter,
                    Deferred = project.Kpi.ProjectStatusHasTheProjectBeenDeferred,
                    Deferred2 = project.Kpi.ProjectStatusHasProjectBeenDeferredForASecondTime,
                    Deferred3 = project.Kpi.ProjectStatusHasProjectBeenDeferredForAThirdTime
                };

                ApplyOpens(entry, project.Opens);
                ApplyPo(entry, project.Po);
                ApplyBs(entry, project.Bs);

                entry.WaveNumber = GetWaveNumber(entry.Wave, entry.Phase);
                entry.PhaseCategory = GetPhaseCategory(entry.Type);
                entry.Flag = GetFlag(
                    project.Po?.ProjectDevelopmentGrantFundingDateOf2ndPaymentDue,
                    project.Po?.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue,
                    project.Kpi?.ProjectStatusDateOfEntryIntoPreOpening);

                entry.Omit = GetOmit(entry);

                result.Projects.Add(entry);
            }

            return result;
        }

        private static string RemoveCommas(string value)
        {
            return value?.Replace(",", string.Empty);
        }

        private static void ApplyOpens(SfaReportEntry entry, Opens opens)
        {
            if (opens == null)
            {
                return;
            }

            entry.PupilsOnRoll = opens.OpenPupilNumbersCurrentPupilsOnRoll;
        }

        private static void ApplyPo(SfaReportEntry entry, Po po)
        {
            if (po == null)
            {
                return;
            }

            entry.PupilNum = po.PupilNumbersAndCapacityTotalOfCapacityTotals;
            entry.InitialAllocation = po.ProjectDevelopmentGrantFundingInitialGrantAllocation;
            entry.RevisedAllocation = po.ProjectDevelopmentGrantFundingRevisedGrantAllocation;
            entry.TotalPayments = po.ProjectDevelopmentGrantFundingTotalPaymentsMade;
            entry.WriteOff = po.ProjectDevelopmentGrantFundingPaymentAmountWrittenOff;
            entry.StoppedPayments = po.ProjectDevelopmentGrantFundingPaymentsStopped;
            entry.StoppedPaymentsDate = po.ProjectDevelopmentGrantFundingDatePaymentsStopped.ToUkDateString();
            entry.DatePaymentFirst = po.ProjectDevelopmentGrantFundingDateOf1stPaymentDue.ToUkDateString();
            entry.PaymentFirst = po.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue;
            entry.DatePaymentSecond = po.ProjectDevelopmentGrantFundingDateOf2ndPaymentDue.ToUkDateString();
            entry.PaymentSecond = po.ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue;
            entry.DatePaymentThird = po.ProjectDevelopmentGrantFundingDateOf3rdPaymentDue.ToUkDateString();
            entry.PaymentThird = po.ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue;
            entry.DatePaymentFourth = po.ProjectDevelopmentGrantFundingDateOf4thPaymentDue.ToUkDateString();
            entry.PaymentFourth = po.ProjectDevelopmentGrantFundingAmountOf4thPaymentDue;
            entry.DatePaymentFifth = po.ProjectDevelopmentGrantFundingDateOf5thPaymentDue.ToUkDateString();
            entry.PaymentFifth = po.ProjectDevelopmentGrantFundingAmountOf5thPaymentDue;
            entry.DatePaymentSixth = po.ProjectDevelopmentGrantFundingDateOf6thPaymentDue.ToUkDateString();
            entry.PaymentSixth = po.ProjectDevelopmentGrantFundingAmountOf6thPaymentDue;
            entry.DatePaymentSeventh = po.ProjectDevelopmentGrantFundingDateOf7thPaymentDue.ToUkDateString();
            entry.PaymentSeventh = po.ProjectDevelopmentGrantFundingAmountOf7thPaymentDue;
            entry.DatePaymentEighth = po.ProjectDevelopmentGrantFundingDateOf8thPaymentDue.ToUkDateString();
            entry.PaymentEighth = po.ProjectDevelopmentGrantFundingAmountOf8thPaymentDue;
            entry.PaymentNinth = po.ProjectDevelopmentGrantFundingAmountOf9thPaymentDue;
            entry.DatePaymentNinth = po.ProjectDevelopmentGrantFundingDateOf9thPaymentDue.ToUkDateString();
            entry.DatePaymentTenth = po.ProjectDevelopmentGrantFundingDateOf10thPaymentDue.ToUkDateString();
            entry.PaymentTenth = po.ProjectDevelopmentGrantFundingAmountOf10thPaymentDue;
            entry.DatePaymentEleventh = po.ProjectDevelopmentGrantFundingDateOf11thPaymentDue.ToUkDateString();
            entry.PaymentEleventh = po.ProjectDevelopmentGrantFundingAmountOf11thPaymentDue;
            entry.DatePaymentTwelfth = po.ProjectDevelopmentGrantFundingDateOf12thPaymentDue.ToUkDateString();
            entry.PaymentTwelfth = po.ProjectDevelopmentGrantFundingAmountOf12thPaymentDue;
            entry.RefundFirst = po.ProjectDevelopmentGrantFundingAmountOf1stRefund;
            entry.RefundSecond = po.ProjectDevelopmentGrantFundingAmountOf2ndRefund;
            entry.RefundThird = po.ProjectDevelopmentGrantFundingAmountOf3rdRefund;
            entry.FirstRefundDate = po.ProjectDevelopmentGrantFundingDateOf1stRefund.ToUkDateString();
            entry.SecondRefundDate = po.ProjectDevelopmentGrantFundingDateOf2ndRefund.ToUkDateString();
            entry.ThirdRefundDate = po.ProjectDevelopmentGrantFundingDateOf3rdRefund.ToUkDateString();
        }

        private static void ApplyBs(SfaReportEntry entry, Bs bs)
        {
            if (bs == null)
            {
                return;
            }

            entry.Stage = GetStage(bs);
        }

        private static int GetFlag(DateTime? datePaymentSecond, string paymentFirst, DateTime? entryPo)
        {
            double.TryParse(paymentFirst, out var paymentFirstValue);

            if (!datePaymentSecond.HasValue && paymentFirstValue >= 25000)
            {
                return 1;
            }

            var differenceInDays = CalculateDaysOverdueAfterOneYear(datePaymentSecond, entryPo);

            if (differenceInDays > 0)
            {
                return (int)differenceInDays.Value;
            }

            return -1;
        }

        private static double? CalculateDaysOverdueAfterOneYear(DateTime? datePaymentSecond, DateTime? entryPo)
        {
            var timeSpan = datePaymentSecond - entryPo;
            var differenceInDays = timeSpan?.TotalDays - 365;

            return differenceInDays;
        }

        private static string GetStage(Bs bs)
        {
            if (bs.BudgetSummaryCostsAtPracticalCompletionApproved == "Yes")
            {
                return "5";
            }

            if (bs.BudgetSummaryCostPlan2Approved == "Yes")
            {
                return "4";
            }

            if (bs.BudgetSummaryCostPlan1Approved == "Yes")
            {
                return "3";
            }

            return "2";
        }

        private static string GetWaveNumber(string wave, string phase)
        {
            if (string.IsNullOrEmpty(wave))
            {
                return NotAvailable;
            }

            if (wave == "LA Special - Wave 1")
            {
                return "12.1";
            }

            if (wave == "LA Special - Wave 2")
            {
                return "13.1";
            }

            if (wave == "Outside of wave")
            {
                return "0.1";
            }

            if (wave == "VA - Wave 1")
            {
                return phase == "Primary" ? "14.1" : "14.2";
            }

            if (wave == "FS - Presumption")
            {
                return "99";
            }

            var lastTwoChars = wave.Substring(wave.Length - 2);

            if (int.TryParse(lastTwoChars, out var waveNumber))
            {
                return waveNumber.ToString();
            }

            return NotAvailable;
        }

        private static string GetPhaseCategory(string phase)
        {
            if (phase == "FS - Mainstream" || phase == "FS - Special" || phase == "FS - AP")
            {
                return "free schools";
            }

            if (phase == "UTC")
            {
                return "UTC";
            }

            if (phase == "SS" || phase == "FS - SS")
            {
                return "SS";
            }

            return NotAvailable;
        }

        private static string GetOmit(SfaReportEntry entry)
        {
            double.TryParse(entry.WaveNumber, out var waveNumber);
            double.TryParse(entry.RevisedAllocation, out var revisedAllocation);

            if (waveNumber < 99 && revisedAllocation > 3000 && entry.Flag > 0)
            {
                return "payment";
            }

            if (entry.Wave == "FS - Presumption" && revisedAllocation > 0)
            {
                return "payment";
            }

            return "omit";
        }
    }

    public class SfaReport
    {
        public List<SfaReportEntry> Projects { get; set; } = new List<SfaReportEntry>();
    }

    public class SfaReportEntry
    {
        [DisplayName("school_name")]
        public string SchoolName { get; set; }

        [DisplayName("ID")]
        public string Id { get; set; }

        [DisplayName("project_status")]
        public string ProjectStatus { get; set; }

        [DisplayName("type")]
        public string Type { get; set; }

        [DisplayName("phase")]
        public string Phase { get; set; }

        [DisplayName("entry_po")]
        public string EntryPo { get; set; }

        [DisplayName("wave")]
        public string Wave { get; set; }

        [DisplayName("provisional_opening_date")]
        public string ProvisionalOpeningDate { get; set; }

        [DisplayName("RYO")]
        public string Ryo { get; set; }

        [DisplayName("opening_date")]
        public string OpeningDate { get; set; }

        [DisplayName("SFC")]
        public string Sfc { get; set; }

        [DisplayName("ind")]
        public string Ind { get; set; }

        [DisplayName("pupils_on_roll")]
        public string PupilsOnRoll { get; set; }

        [DisplayName("pupil_num")]
        public string PupilNum { get; set; }

        [DisplayName("stage")]
        public string Stage { get; set; }

        [DisplayName("initial_allocation")]
        public string InitialAllocation { get; set; }

        [DisplayName("revised_allocation")]
        public string RevisedAllocation { get; set; }

        [DisplayName("total_payments")]
        public string TotalPayments { get; set; }

        [DisplayName("write_off")]
        public string WriteOff { get; set; }

        [DisplayName("deferred")]
        public string Deferred { get; set; }

        [DisplayName("deferred2")]
        public string Deferred2 { get; set; }

        [DisplayName("deferred3")]
        public string Deferred3 { get; set; }

        [DisplayName("stopped_payments")]
        public string StoppedPayments { get; set; }

        [DisplayName("stopped_payments_date")]
        public string StoppedPaymentsDate { get; set; }

        [DisplayName("date_payment_first")]
        public string DatePaymentFirst { get; set; }

        [DisplayName("payment_first")]
        public string PaymentFirst { get; set; }

        [DisplayName("date_payment_second")]
        public string DatePaymentSecond { get; set; }

        [DisplayName("payment_second")]
        public string PaymentSecond { get; set; }

        [DisplayName("date_payment_third")]
        public string DatePaymentThird { get; set; }

        [DisplayName("payment_third")]
        public string PaymentThird { get; set; }

        [DisplayName("date_payment_fourth")]
        public string DatePaymentFourth { get; set; }

        [DisplayName("payment_fourth")]
        public string PaymentFourth { get; set; }

        [DisplayName("date_payment_fifth")]
        public string DatePaymentFifth { get; set; }

        [DisplayName("payment_fifth")]
        public string PaymentFifth { get; set; }

        [DisplayName("date_payment_sixth")]
        public string DatePaymentSixth { get; set; }

        [DisplayName("payment_sixth")]
        public string PaymentSixth { get; set; }

        [DisplayName("date_payment_seventh")]
        public string DatePaymentSeventh { get; set; }

        [DisplayName("payment_seventh")]
        public string PaymentSeventh { get; set; }

        [DisplayName("date_payment_eighth")]
        public string DatePaymentEighth { get; set; }

        [DisplayName("payment_eighth")]
        public string PaymentEighth { get; set; }

        [DisplayName("payment_ninth")]
        public string PaymentNinth { get; set; }

        [DisplayName("date_payment_ninth")]
        public string DatePaymentNinth { get; set; }

        [DisplayName("date_payment_tenth")]
        public string DatePaymentTenth { get; set; }

        [DisplayName("payment_tenth")]
        public string PaymentTenth { get; set; }

        [DisplayName("date_payment_eleventh")]
        public string DatePaymentEleventh { get; set; }

        [DisplayName("payment_eleventh")]
        public string PaymentEleventh { get; set; }

        [DisplayName("date_payment_twelfth")]
        public string DatePaymentTwelfth { get; set; }

        [DisplayName("payment_twelfth")]
        public string PaymentTwelfth { get; set; }

        [DisplayName("refund_first")]
        public string RefundFirst { get; set; }

        [DisplayName("refund_second")]
        public string RefundSecond { get; set; }

        [DisplayName("refund_third")]
        public string RefundThird { get; set; }

        [DisplayName("first_refund_date")]
        public string FirstRefundDate { get; set; }

        [DisplayName("second_refund_date")]
        public string SecondRefundDate { get; set; }

        [DisplayName("third_refund_date")]
        public string ThirdRefundDate { get; set; }

        [DisplayName("flag")]
        public double Flag { get; set; }

        [DisplayName("wave_number")]
        public string WaveNumber { get; set; }

        [DisplayName("phase_category")]
        public string PhaseCategory { get; set; }

        [DisplayName("omit")]
        public string Omit { get; set; }
    }
}
