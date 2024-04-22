using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class TermVisitsConfiguration : IEntityTypeConfiguration< TermVisits>
	{
		public void Configure(EntityTypeBuilder<TermVisits> builder)
		{
            builder.ToTable("Term_Visits", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.TermVisitsActionPlan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Action plan");
            builder.Property(e => e.TermVisitsActionPlanDueDate)
                .HasColumnType("date")
                .HasColumnName("Term Visits.Action plan due date");
            builder.Property(e => e.TermVisitsActionPlanReceived)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Action plan received");
            builder.Property(e => e.TermVisitsDateOfFollowUp)
                .HasColumnType("date")
                .HasColumnName("Term Visits.Date of follow up");
            builder.Property(e => e.TermVisitsDateOfVisit)
                .HasColumnType("date")
                .HasColumnName("Term Visits.Date of Visit");
            builder.Property(e => e.TermVisitsFollowUpVisitRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Follow-up visit rating");
            builder.Property(e => e.TermVisitsIsActionPlanRequested)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Is action plan requested?");
            builder.Property(e => e.TermVisitsLinkOfficerFirstTermVisit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Link Officer first term visit");
            builder.Property(e => e.TermVisitsLinkOfficerFirstTermVisitOutcome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Link officer first term visit - outcome");
            builder.Property(e => e.TermVisitsLinkOfficerFirstTermVisitOutcomeTypeOfConcern)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Link officer first term visit outcome - type of concern");
            builder.Property(e => e.TermVisitsLinkOfficerFirstTermVisitReport)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Link officer first term visit – report");
            builder.Property(e => e.TermVisitsNameOfDfEOfficial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Name of DfE official");
            builder.Property(e => e.TermVisitsNameOfEducationAdviser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Name of Education Adviser");
            builder.Property(e => e.TermVisitsNextVisitDate)
                .HasColumnType("date")
                .HasColumnName("Term Visits.Next visit date");
            builder.Property(e => e.TermVisitsSchoolTermVisit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.School Term Visit");
            builder.Property(e => e.TermVisitsVisitFollowUp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Visit follow up");
            builder.Property(e => e.TermVisitsVisitRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Visit Rating");
            builder.Property(e => e.TermVisitsVisitReport)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Visit Report");
            builder.Property(e => e.TermVisitsVisitSummary)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Term Visits.Visit Summary");
            builder.Property(e => e.Visits)
                .HasMaxLength(100)
                .IsUnicode(false);

		}
	}

}
