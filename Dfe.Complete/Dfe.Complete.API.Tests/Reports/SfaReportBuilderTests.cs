using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Reports;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Reports
{
    public class SfaReportBuilderTests
    {
        private static readonly Fixture _autoFixture = new Fixture();

        static SfaReportBuilderTests()
        {
            _autoFixture.Customize(new OmitNestedPropertiesCustomization());
        }

        [Fact]
        public void When_AllDataProvided_Returns_ValidReport()
        {
            // Arrange
            var reportSourceData = CreateSfaReportSourceData();

            var expected = reportSourceData.First();
            expected.Kpi.ProjectStatusCurrentFreeSchoolName = "This, is my, school, name";

            // Act
            var report = SfaReportBuilder.Build(reportSourceData);

            report.Projects.Should().HaveCount(1);

            var project = report.Projects.First();

            project.SchoolName.Should().Be("This is my school name");
            project.Id.Should().Be(expected.Kpi.ProjectStatusProjectId);
            project.ProjectStatus.Should().Be(expected.Kpi.ProjectStatusProjectStatus);
            project.Type.Should().Be(expected.Kpi.SchoolDetailsSchoolTypeMainstreamApEtc);
            project.Phase.Should().Be(expected.Kpi.SchoolDetailsSchoolPhasePrimarySecondary);
            project.EntryPo.Should().Be(expected.Kpi.ProjectStatusDateOfEntryIntoPreOpening.ToUkDateString());
            project.Wave.Should().Be(expected.Kpi.ProjectStatusFreeSchoolApplicationWave);
            project.ProvisionalOpeningDate.Should().Be(expected.Kpi.ProjectStatusProvisionalOpeningDateAgreedWithTrust.ToUkDateString());
            project.Ryo.Should().Be(expected.Kpi.ProjectStatusRealisticYearOfOpening);
            project.OpeningDate.Should().Be(expected.Kpi.ProjectStatusActualOpeningDate.ToUkDateString());
            project.Sfc.Should().Be(expected.Kpi.SchoolDetailsSixthForm);
            project.Ind.Should().Be(expected.Kpi.SchoolDetailsIndependentConverter);
            project.Deferred.Should().Be(expected.Kpi.ProjectStatusHasTheProjectBeenDeferred);
            project.Deferred2.Should().Be(expected.Kpi.ProjectStatusHasProjectBeenDeferredForASecondTime);
            project.Deferred3.Should().Be(expected.Kpi.ProjectStatusHasProjectBeenDeferredForAThirdTime);

            project.PupilNum.Should().Be(expected.Po.PupilNumbersAndCapacityTotalOfCapacityTotals);
            project.InitialAllocation.Should().Be(expected.Po.ProjectDevelopmentGrantFundingInitialGrantAllocation);
            project.RevisedAllocation.Should().Be(expected.Po.ProjectDevelopmentGrantFundingRevisedGrantAllocation);
            project.TotalPayments.Should().Be(expected.Po.ProjectDevelopmentGrantFundingTotalPaymentsMade);
            project.WriteOff.Should().Be(expected.Po.ProjectDevelopmentGrantFundingPaymentAmountWrittenOff);
            project.StoppedPayments.Should().Be(expected.Po.ProjectDevelopmentGrantFundingPaymentsStopped);
            project.StoppedPaymentsDate.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDatePaymentsStopped.ToUkDateString());
            project.DatePaymentFirst.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf1stPaymentDue.ToUkDateString());
            project.PaymentFirst.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue);
            project.DatePaymentSecond.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf2ndPaymentDue.ToUkDateString());
            project.PaymentSecond.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue);
            project.DatePaymentThird.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf3rdPaymentDue.ToUkDateString());
            project.PaymentThird.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue);
            project.DatePaymentFourth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf4thPaymentDue.ToUkDateString());
            project.PaymentFourth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf4thPaymentDue);
            project.DatePaymentFifth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf5thPaymentDue.ToUkDateString());
            project.PaymentFifth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf5thPaymentDue);
            project.DatePaymentSixth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf6thPaymentDue.ToUkDateString());
            project.PaymentSixth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf6thPaymentDue);
            project.DatePaymentSeventh.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf7thPaymentDue.ToUkDateString());
            project.PaymentSeventh.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf7thPaymentDue);
            project.DatePaymentEighth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf8thPaymentDue.ToUkDateString());
            project.PaymentEighth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf8thPaymentDue);
            project.PaymentNinth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf9thPaymentDue);
            project.DatePaymentNinth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf9thPaymentDue.ToUkDateString());
            project.DatePaymentTenth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf10thPaymentDue.ToUkDateString());
            project.PaymentTenth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf10thPaymentDue);
            project.DatePaymentEleventh.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf11thPaymentDue.ToUkDateString());
            project.PaymentEleventh.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf11thPaymentDue);
            project.DatePaymentTwelfth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf12thPaymentDue.ToUkDateString());
            project.PaymentTwelfth.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf12thPaymentDue);
            project.RefundFirst.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf1stRefund);
            project.RefundSecond.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf2ndRefund);
            project.RefundThird.Should().Be(expected.Po.ProjectDevelopmentGrantFundingAmountOf3rdRefund);
            project.FirstRefundDate.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf1stRefund.ToUkDateString());
            project.SecondRefundDate.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf2ndRefund.ToUkDateString());
            project.ThirdRefundDate.Should().Be(expected.Po.ProjectDevelopmentGrantFundingDateOf3rdRefund.ToUkDateString());
        }

        [Fact]
        public void When_AllPropertiesNull()
        {
            var reportSourceData = new List<SfaReportSourceData>
            {
                new SfaReportSourceData
                {
                    Kpi = new Kpi(),
                    Po = new Po(),
                    Opens = new Opens(),
                    Bs = new Bs()
                }
            };

            var report = SfaReportBuilder.Build(reportSourceData);

            report.Projects.Should().HaveCount(1);

            var project = report.Projects.First();

            project.SchoolName.Should().Be(null);
            project.Id.Should().Be(null);
        }

        [Fact]
        public void When_OptionalDataMissing()
        {
            var reportSourceData = new List<SfaReportSourceData>
            {
                new SfaReportSourceData
                {
                    Kpi = _autoFixture.Create<Kpi>()
                }
            };

            var report = SfaReportBuilder.Build(reportSourceData);

            report.Projects.Should().HaveCount(1);

            var project = report.Projects.First();
            var expected = reportSourceData.First();

            project.SchoolName.Should().Be(expected.Kpi.ProjectStatusCurrentFreeSchoolName);
            project.Id.Should().Be(expected.Kpi.ProjectStatusProjectId);
            project.ProjectStatus.Should().Be(expected.Kpi.ProjectStatusProjectStatus);
            project.Type.Should().Be(expected.Kpi.SchoolDetailsSchoolTypeMainstreamApEtc);
            project.PupilsOnRoll.Should().BeNull();
            project.PupilNum.Should().BeNull();
            project.Stage.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(FlagData))]
        public void When_Flag(
            DateTime? datePaymentSecond,
            string paymentFirst,
            DateTime? entryPo,
            int expectedFlag)
        {
            var reportSourceData = CreateSfaReportSourceData();
            var sourceEntry = reportSourceData.First();

            sourceEntry.Po.ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = datePaymentSecond;
            sourceEntry.Po.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = paymentFirst;
            sourceEntry.Kpi.ProjectStatusDateOfEntryIntoPreOpening = entryPo;

            var report = SfaReportBuilder.Build(reportSourceData);
            var project = report.Projects.First();

            project.Flag.Should().Be(expectedFlag);
        }

        [Theory]
        [MemberData(nameof(StageData))]
        public void When_Stage(
            string costsAtPracticalCompletionApproved,
            string costPlanTwoApproved,
            string costPlanOneApproved,
            string expectedStage)
        {
            var reportSourceData = CreateSfaReportSourceData();
            var sourceEntry = reportSourceData.First();

            sourceEntry.Bs.BudgetSummaryCostsAtPracticalCompletionApproved = costsAtPracticalCompletionApproved;
            sourceEntry.Bs.BudgetSummaryCostPlan2Approved = costPlanTwoApproved;
            sourceEntry.Bs.BudgetSummaryCostPlan1Approved = costPlanOneApproved;

            var report = SfaReportBuilder.Build(reportSourceData);

            var project = report.Projects.First();

            project.Stage.Should().Be(expectedStage);
        }

        [Theory]
        [MemberData(nameof(WaveNumberData))]
        public void When_WaveNumber(
            string wave,
            string phase,
            string expectedWaveNumber)
        {
            var reportSourceData = CreateSfaReportSourceData();
            var sourceEntry = reportSourceData.First();

            sourceEntry.Kpi.ProjectStatusFreeSchoolApplicationWave = wave;
            sourceEntry.Kpi.SchoolDetailsSchoolPhasePrimarySecondary = phase;

            var report = SfaReportBuilder.Build(reportSourceData);

            var project = report.Projects.First();

            project.WaveNumber.Should().Be(expectedWaveNumber);
        }

        [Theory]
        [MemberData(nameof(PhaseCategoryData))]
        public void When_PhaseCategory(
            string type,
            string expectedPhaseCategory)
        {
            var reportSourceData = CreateSfaReportSourceData();
            var sourceEntry = reportSourceData.First();

            sourceEntry.Kpi.SchoolDetailsSchoolTypeMainstreamApEtc = type;

            var report = SfaReportBuilder.Build(reportSourceData);
            var project = report.Projects.First();

            project.PhaseCategory.Should().Be(expectedPhaseCategory);
        }

        [Theory]
        [MemberData(nameof(OmitData))]
        public void When_Omit(
            string wave,
            string revisedAllocation,
            string paymentFirst,
            string expectedOmit)
        {
            var reportSourceData = CreateSfaReportSourceData();
            var sourceEntry = reportSourceData.First();

            sourceEntry.Kpi.ProjectStatusFreeSchoolApplicationWave = wave;
            sourceEntry.Po.ProjectDevelopmentGrantFundingRevisedGrantAllocation = revisedAllocation;
            sourceEntry.Po.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = paymentFirst;
            sourceEntry.Po.ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = null;


            var report = SfaReportBuilder.Build(reportSourceData);
            var project = report.Projects.First();

            project.Omit.Should().Be(expectedOmit);
        }

        public static IEnumerable<object[]> FlagData()
        {
            yield return new object[] { null, "25000.50", null, 1 };
            yield return new object[] { null, "26000", null, 1 };
            yield return new object[] { null, "23000", null, -1 };

            yield return new object[] { new DateTime(2023, 1, 2), "24000", new DateTime(2022, 1, 1), 1 };
            yield return new object[] { new DateTime(2023, 1, 30), "24000", new DateTime(2022, 1, 1), 29 };
            yield return new object[] { new DateTime(2022, 1, 2), "24000", new DateTime(2023, 1, 1), -1 };
            yield return new object[] { null, null, null, -1 };
        }

        public static IEnumerable<object[]> StageData()
        {
            yield return new object[] { "Yes", "No", "No", "5" };
            yield return new object[] { "No", "Yes", "No", "4" };
            yield return new object[] { "No", "No", "Yes", "3" };
            yield return new object[] { null, null, null, "2" };
        }

        public static IEnumerable<object[]> WaveNumberData()
        {
            yield return new object[] { "LA Special - Wave 1", "", "12.1" };
            yield return new object[] { "LA Special - Wave 2", "", "13.1" };
            yield return new object[] { "Outside of wave", "", "0.1" };
            yield return new object[] { "VA - Wave 1", "Primary", "14.1" };
            yield return new object[] { "VA - Wave 1", "Secondary", "14.2" };
            yield return new object[] { "FS - Presumption", "Secondary", "99" };
            yield return new object[] { "Super awesome - Wave 6", "", "6" };
            yield return new object[] { "Super awesome - Wave 26", "", "26" };
            yield return new object[] { "Super awesome - Wave", "", "NA" };
            yield return new object[] { null, "", "NA" };
        }

        public static IEnumerable<object[]> PhaseCategoryData()
        {
            yield return new object[] { "FS - Mainstream", "free schools" };
            yield return new object[] { "FS - Special", "free schools" };
            yield return new object[] { "FS - AP", "free schools" };
            yield return new object[] { "UTC", "UTC" };
            yield return new object[] { "SS", "SS" };
            yield return new object[] { "FS - SS", "SS" };
            yield return new object[] { null, "NA" };
        }

        public static IEnumerable<object[]> OmitData()
        {
            // This relies on data calculated elsehwere, if it becomes too difficult to maintain, split the code
            yield return new object[] { "LA Special - Wave 1", "3001.80", "25000", "payment" };
            yield return new object[] { "LA Special - Wave 1", "2900", "25000", "omit" };
            yield return new object[] { "LA Special - Wave 1", "3001", "", "omit" };

            yield return new object[] { "FS - Presumption", "3001", null, "payment" };
            yield return new object[] { "FS - Saved", "3001", null, "omit" };
            yield return new object[] { "FS - Presumption", "-1", null, "omit" };

            yield return new object[] { null, null, null, "omit" };
        }

        private static List<SfaReportSourceData> CreateSfaReportSourceData()
        {
            return new List<SfaReportSourceData>
            {
                new SfaReportSourceData
                {
                    Kpi = _autoFixture.Create<Kpi>(),
                    Po = _autoFixture.Create<Po>(),
                    Opens = _autoFixture.Create<Opens>(),
                    Bs = _autoFixture.Create<Bs>()
                }
            };
        }
    }
}
