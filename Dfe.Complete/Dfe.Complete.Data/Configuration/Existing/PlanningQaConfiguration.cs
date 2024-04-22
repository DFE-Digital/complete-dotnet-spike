using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PlanningQaConfiguration : IEntityTypeConfiguration< PlanningQa>
	{
		public void Configure(EntityTypeBuilder<PlanningQa> builder)
		{
            builder
                .HasNoKey()
                .ToTable("Planning_QA", "dbo");

            builder.Property(e => e.AppealProcedureHighlight).HasColumnName("Appeal procedure highlight");
            builder.Property(e => e.AppealRequiredHighlight).HasColumnName("Appeal required? highlight");
            builder.Property(e => e.ClassCExpiryDateActualHighlight).HasColumnName("Class C expiry date (Actual) highlight");
            builder.Property(e => e.DateAppealSubmittedActualHighlight).HasColumnName("Date appeal submitted (actual) highlight");
            builder.Property(e => e.DateAppealSubmittedForecastHighlight).HasColumnName("Date appeal submitted (forecast) highlight");
            builder.Property(e => e.DateAppealValidatedActualHighlight).HasColumnName("Date appeal validated (actual) highlight");
            builder.Property(e => e.DateLetterSentToLocalPlanningAuthorityActualHighlight).HasColumnName("Date letter sent to local planning authority (Actual) highlight");
            builder.Property(e => e.DateLetterSentToLocalPlanningAuthorityForecastHighlight).HasColumnName("Date letter sent to local planning authority (Forecast) highlight");
            builder.Property(e => e.DateOfAppealDecisionNoticeActualHighlight).HasColumnName("Date of appeal decision notice (actual) highlight");
            builder.Property(e => e.DateOfAppealDecisionNoticeForecastHighlight).HasColumnName("Date of appeal decision notice (forecast) highlight");
            builder.Property(e => e.DateOfPlanningDecisionNoticeActualHighlight).HasColumnName("Date of planning decision notice (actual) highlight");
            builder.Property(e => e.DateOfPlanningDecisionNoticeForecastHighlight).HasColumnName("Date of planning decision notice (forecast) highlight");
            builder.Property(e => e.DateOfStatutoryDeterminationActualHighlight).HasColumnName("Date of statutory determination (actual) highlight");
            builder.Property(e => e.DatePlanningApplicationSubmittedActualHighlight).HasColumnName("Date planning application submitted (actual) highlight");
            builder.Property(e => e.DatePlanningApplicationSubmittedForecastHighlight).HasColumnName("Date planning application submitted (forecast) highlight");
            builder.Property(e => e.DatePlanningApplicationValidatedActualHighlight).HasColumnName("Date planning application validated (actual) highlight");
            builder.Property(e => e.LpaApplicationReferenceHighlight).HasColumnName("LPA application reference highlight");
            builder.Property(e => e.Month)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.PlanningPermissionExpiryDateActualHighlight).HasColumnName("Planning permission expiry date (actual) highlight");
            builder.Property(e => e.PlanningPermissionLimitedToASpecificTimeAndExpiryPeriodHighlight).HasColumnName("Planning permission limited to a specific time and expiry period highlight");
            builder.Property(e => e.PlanningRiskHighlight).HasColumnName("Planning risk highlight");
            builder.Property(e => e.TypeOfPlanningRequiredHighlight).HasColumnName("Type of planning required highlight");

		}
	}

}
