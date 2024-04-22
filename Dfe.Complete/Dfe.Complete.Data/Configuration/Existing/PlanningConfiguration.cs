using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PlanningConfiguration : IEntityTypeConfiguration< Planning>
	{
		public void Configure(EntityTypeBuilder<Planning> builder)
		{
            builder.ToTable("Planning", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.PlanningRecordAddressManualOverwrite).HasColumnName("Planning Record.Address - Manual overwrite?");
            builder.Property(e => e.PlanningRecordAddressOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Address of site");
            builder.Property(e => e.PlanningRecordAppealDecision)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Appeal decision");
            builder.Property(e => e.PlanningRecordAppealProcedure)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Appeal procedure");
            builder.Property(e => e.PlanningRecordAppealRequired)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Appeal required?");
            builder.Property(e => e.PlanningRecordClassCExpiryDateActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Class C expiry date (Actual)");
            builder.Property(e => e.PlanningRecordDateAppealSubmittedActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date appeal submitted (actual)");
            builder.Property(e => e.PlanningRecordDateAppealSubmittedForecast)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date appeal submitted (forecast)");
            builder.Property(e => e.PlanningRecordDateAppealValidatedActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date appeal validated (actual)");
            builder.Property(e => e.PlanningRecordDateLetterSentToLocalPlanningAuthorityActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date letter sent to local planning authority (Actual)");
            builder.Property(e => e.PlanningRecordDateLetterSentToLocalPlanningAuthorityForecast)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date letter sent to local planning authority (Forecast)");
            builder.Property(e => e.PlanningRecordDateOfAppealDecisionNoticeActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date of appeal decision notice (actual)");
            builder.Property(e => e.PlanningRecordDateOfAppealDecisionNoticeForecast)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date of appeal decision notice (forecast)");
            builder.Property(e => e.PlanningRecordDateOfPlanningDecisionNoticeActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date of planning decision notice (actual)");
            builder.Property(e => e.PlanningRecordDateOfPlanningDecisionNoticeForecast)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date of planning decision notice (forecast)");
            builder.Property(e => e.PlanningRecordDateOfStatutoryDeterminationActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date of statutory determination (actual)");
            builder.Property(e => e.PlanningRecordDatePlanningApplicationSubmittedActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date planning application submitted (actual)");
            builder.Property(e => e.PlanningRecordDatePlanningApplicationSubmittedForecast)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date planning application submitted (forecast)");
            builder.Property(e => e.PlanningRecordDatePlanningApplicationValidatedActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date planning application validated (actual)");
            builder.Property(e => e.PlanningRecordDatePlanningAppraisalCompletedActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.Date planning appraisal completed (actual)");
            builder.Property(e => e.PlanningRecordDescriptionOfDevelopment)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Description of development");
            builder.Property(e => e.PlanningRecordIsPlanningPermissionRequired)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Is planning permission required?");
            builder.Property(e => e.PlanningRecordIsThisTheMainPlanningRecord)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Is this the main planning record?");
            builder.Property(e => e.PlanningRecordJrChallengePeriodFinishedActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.JR challenge period finished (actual)");
            builder.Property(e => e.PlanningRecordLocalPlanningAuthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Local planning authority");
            builder.Property(e => e.PlanningRecordLpaApplicationReference)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.LPA application reference");
            builder.Property(e => e.PlanningRecordNameManualOverwrite).HasColumnName("Planning Record.Name - Manual overwrite?");
            builder.Property(e => e.PlanningRecordPlanningAppraisalCompleted)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Planning appraisal completed");
            builder.Property(e => e.PlanningRecordPlanningDecision)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Planning decision");
            builder.Property(e => e.PlanningRecordPlanningLeadComments)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Planning Lead comments");
            builder.Property(e => e.PlanningRecordPlanningPermissionLimitedToASpecificTimeAndExpiryPeriod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Planning permission limited to a specific time and expiry period");
            builder.Property(e => e.PlanningRecordPlanningRisk)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Planning risk");
            builder.Property(e => e.PlanningRecordPostcodeManualOverwrite).HasColumnName("Planning Record.Postcode - Manual overwrite?");
            builder.Property(e => e.PlanningRecordPostcodeOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Postcode of site");
            builder.Property(e => e.PlanningRecordPrNameOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.PR_Name of site");
            builder.Property(e => e.PlanningRecordPrPlanningPermissionExpiryDateActual)
                .HasColumnType("date")
                .HasColumnName("Planning Record.PR_Planning permission expiry date (actual)");
            builder.Property(e => e.PlanningRecordSiteId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Site ID");
            builder.Property(e => e.PlanningRecordStorePlanningRecordId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Store planning record ID");
            builder.Property(e => e.PlanningRecordTypeOfPlanningRequired)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Type of planning required");
            builder.Property(e => e.PlanningRecordWasPlanningSecuredInTimeForSchoolRequirements)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Planning Record.Was planning secured in time for school requirements?");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

		}
	}

}
