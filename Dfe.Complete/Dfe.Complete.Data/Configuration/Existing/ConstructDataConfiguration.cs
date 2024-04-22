using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class ConstructDataConfiguration : IEntityTypeConfiguration< ConstructData>
	{
		public void Configure(EntityTypeBuilder<ConstructData> builder)
		{
            builder
                .HasNoKey()
                .ToTable("constructData", "dbo");

            builder.Property(e => e.CapitalProjectRag)
                .IsUnicode(false)
                .HasColumnName("Capital Project RAG");
            builder.Property(e => e.CapitalProjectRagRatingCommentary)
                .IsUnicode(false)
                .HasColumnName("Capital Project RAG Rating Commentary");
            builder.Property(e => e.DateOfHoTSecuredOnTemporaryAccommodationSiteIfRequired)
                .IsUnicode(false)
                .HasColumnName("Date of HoT secured on temporary accommodation site, if required");
            builder.Property(e => e.HoTAgreedForSiteForMainSchoolBuildingActual)
                .IsUnicode(false)
                .HasColumnName("HoT Agreed for site for Main School Building (Actual)");
            builder.Property(e => e.IsThisTheMainPlanningRecord)
                .IsUnicode(false)
                .HasColumnName("Is this the main planning record?");
            builder.Property(e => e.MainSchoolBuildingFirstReadyForOccupationActual)
                .IsUnicode(false)
                .HasColumnName("Main School Building first ready for occupation (Actual)");
            builder.Property(e => e.MainSchoolBuildingFirstReadyForOccupationForecast)
                .IsUnicode(false)
                .HasColumnName("Main School Building first ready for occupation (Forecast)");
            builder.Property(e => e.PlanningDecision)
                .IsUnicode(false)
                .HasColumnName("Planning decision");
            builder.Property(e => e.PlanningRisk)
                .IsUnicode(false)
                .HasColumnName("Planning risk");
            builder.Property(e => e.PlanningSiteId)
                .IsUnicode(false)
                .HasColumnName("Planning Site ID");
            builder.Property(e => e.PostcodeOfSite)
                .IsUnicode(false)
                .HasColumnName("Postcode of site");
            builder.Property(e => e.PracticalCompletionCertificateIssuedDateA)
                .IsUnicode(false)
                .HasColumnName("Practical Completion Certificate issued date (A)");
            builder.Property(e => e.ProjectDirector)
                .IsUnicode(false)
                .HasColumnName("Project Director");
            builder.Property(e => e.ProjectId)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("Project ID");
            builder.Property(e => e.ProjectManager)
                .IsUnicode(false)
                .HasColumnName("Project Manager");
            builder.Property(e => e.RegionalHead)
                .IsUnicode(false)
                .HasColumnName("Regional Head");
            builder.Property(e => e.SiteId)
                .IsUnicode(false)
                .HasColumnName("Site ID");
            builder.Property(e => e.SiteIdentifiedForMainSchoolBuildingActual)
                .IsUnicode(false)
                .HasColumnName("Site identified for main school building (Actual)");
            builder.Property(e => e.SiteStatus)
                .IsUnicode(false)
                .HasColumnName("Site status");
            builder.Property(e => e.TemporaryAccommodationFirstReadyForOccupationActual)
                .IsUnicode(false)
                .HasColumnName("Temporary accommodation first ready for occupation (Actual)");
            builder.Property(e => e.TemporaryAccommodationFirstReadyForOccupationForecast)
                .IsUnicode(false)
                .HasColumnName("Temporary accommodation first ready for occupation (Forecast)");
            builder.Property(e => e.TemporaryRagRating)
                .IsUnicode(false)
                .HasColumnName("Temporary RAG rating");
            builder.Property(e => e.TemporaryRagRatingCommentary)
                .IsUnicode(false)
                .HasColumnName("Temporary RAG Rating Commentary");
            builder.Property(e => e.TypeOfSite)
                .IsUnicode(false)
                .HasColumnName("Type of Site");

            AuditConfiguration.Apply(builder);
        }
	}

}
