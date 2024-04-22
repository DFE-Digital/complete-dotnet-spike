using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class OpensConfiguration : IEntityTypeConfiguration< Opens>
	{
		public void Configure(EntityTypeBuilder<Opens> builder)
		{
            builder.ToTable("Opens", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.CurrentStatusCaseNote)
                .IsUnicode(false)
                .HasColumnName("Current Status.Case note");
            builder.Property(e => e.CurrentStatusDateOfLatestCaseNote)
                .HasColumnType("date")
                .HasColumnName("Current Status.Date of latest case note");
            builder.Property(e => e.CurrentStatusDueDiligenceConcerns)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Status.Due diligence concerns?");
            builder.Property(e => e.CurrentStatusEfaTerritoryConcernLevel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Status.EFA territory concern level");
            builder.Property(e => e.CurrentStatusFinancialConcerns)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Current Status.Financial concerns");
            builder.Property(e => e.CurrentStatusGovernanceAndCompliance)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Current Status.Governance and compliance");
            builder.Property(e => e.CurrentStatusIntervention)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Status.Intervention");
            builder.Property(e => e.CurrentStatusIrregularity)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Current Status.Irregularity");
            builder.Property(e => e.CurrentStatusPrincipalSameAsOnOpening)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Current Status.Principal same as on opening");
            builder.Property(e => e.FinancialChecksAdditionalDebtDeficit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Additional Debt/ Deficit");
            builder.Property(e => e.FinancialChecksBudgetReturnSubmittedByLastDeadline)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Budget return submitted by last deadline");
            builder.Property(e => e.FinancialChecksFinancialNoticeToImproveIssued)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Financial Notice to Improve issued");
            builder.Property(e => e.FinancialChecksFinancialStatementsQualified)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Financial statements qualified");
            builder.Property(e => e.FinancialChecksFinancialStatementsSubmittedByLastDeadline)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Financial statements submitted by last deadline");
            builder.Property(e => e.FinancialChecksFmgsReturnSubmittedByLastDeadline)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.FMGS return submitted by last deadline");
            builder.Property(e => e.FinancialChecksMindedToIssueFnti)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Minded to issue FNTI");
            builder.Property(e => e.FinancialChecksMostRecentAuditedAccountsReceivedOnTime)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Most recent audited accounts received on time");
            builder.Property(e => e.FinancialChecksProjectDevelopmentGrantFinalReturnReceived)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Project Development Grant final return received");
            builder.Property(e => e.FinancialChecksRegularityOpinionQualified)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Regularity opinion qualified");
            builder.Property(e => e.FinancialChecksTotalOutstandingPna)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Total Outstanding PNA");
            builder.Property(e => e.FinancialChecksTotalRevenueLiabilities)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Checks.Total Revenue Liabilities");
            builder.Property(e => e.OpenPupilNumbersAcceptedApplicationsYr10ForNextYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Accepted applications Yr 10 for next year");
            builder.Property(e => e.OpenPupilNumbersAcceptedApplicationsYr12ForNextYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Accepted applications Yr 12 for next year");
            builder.Property(e => e.OpenPupilNumbersApplicationsYr10ForTheComingYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Applications Yr 10 for the coming year");
            builder.Property(e => e.OpenPupilNumbersApplicationsYr12ForTheComingYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Applications Yr 12 for the coming year");
            builder.Property(e => e.OpenPupilNumbersCapacityAgreedInPreOpening)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Capacity agreed in pre-opening");
            builder.Property(e => e.OpenPupilNumbersCensusDate)
                .HasColumnType("date")
                .HasColumnName("Open Pupil Numbers.Census date");
            builder.Property(e => e.OpenPupilNumbersCurrentPupilsOnRoll)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Current pupils on roll");
            builder.Property(e => e.OpenPupilNumbersDateEfaRingRoundPupilNumbersUpdated)
                .HasColumnType("date")
                .HasColumnName("Open Pupil Numbers.Date EFA ring round pupil numbers updated");
            builder.Property(e => e.OpenPupilNumbersEfaRingRoundPupilNumbers)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.EFA ring round pupil numbers");
            builder.Property(e => e.OpenPupilNumbersFull)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.%full");
            builder.Property(e => e.OpenPupilNumbersFundedNumberForTheComingYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Funded number for the coming year");
            builder.Property(e => e.OpenPupilNumbersFundedNumberForTheCurrentAcademicYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Funded number for the current academic year");
            builder.Property(e => e.OpenPupilNumbersNorAsOfFundedNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.NOR as % of funded number");
            builder.Property(e => e.OpenPupilNumbersReception)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Reception");
            builder.Property(e => e.OpenPupilNumbersTotal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Total");
            builder.Property(e => e.OpenPupilNumbersViabilityThresholdForTheComingYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Viability threshold for the coming year");
            builder.Property(e => e.OpenPupilNumbersViabilityThresholdForTheCurrentAcademicYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Viability threshold for the current academic year");
            builder.Property(e => e.OpenPupilNumbersY12Y14Total)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Y12 - Y14 Total");
            builder.Property(e => e.OpenPupilNumbersY7Y11Total)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Y7 - Y11 Total");
            builder.Property(e => e.OpenPupilNumbersYear1)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 1");
            builder.Property(e => e.OpenPupilNumbersYear10)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 10");
            builder.Property(e => e.OpenPupilNumbersYear11)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 11");
            builder.Property(e => e.OpenPupilNumbersYear12)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 12");
            builder.Property(e => e.OpenPupilNumbersYear13)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 13");
            builder.Property(e => e.OpenPupilNumbersYear14)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 14");
            builder.Property(e => e.OpenPupilNumbersYear2)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 2");
            builder.Property(e => e.OpenPupilNumbersYear3)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 3");
            builder.Property(e => e.OpenPupilNumbersYear4)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 4");
            builder.Property(e => e.OpenPupilNumbersYear5)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 5");
            builder.Property(e => e.OpenPupilNumbersYear6)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 6");
            builder.Property(e => e.OpenPupilNumbersYear7)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 7");
            builder.Property(e => e.OpenPupilNumbersYear8)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 8");
            builder.Property(e => e.OpenPupilNumbersYear9)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.Year 9");
            builder.Property(e => e.OpenPupilNumbersYrY6Total)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Open Pupil Numbers.YR - Y6 Total");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

            AuditConfiguration.Apply(builder);
        }
	}

}
