using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class BasicNeedConfiguration : IEntityTypeConfiguration< BasicNeed>
	{
		public void Configure(EntityTypeBuilder<BasicNeed> builder)
		{
            builder
                .HasNoKey()
                .ToTable("Basic_Need", "dbo");

            builder.Property(e => e.FreeSchoolName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Free school name");
            builder.Property(e => e.Phase)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.PostcodeUsedHere)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Postcode used here");
            builder.Property(e => e.PrimaryPlanningAreaCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Primary planning area code");
            builder.Property(e => e.PrimaryPlanningAreaName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Primary planning area name");
            builder.Property(e => e.ProjectId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Project ID");
            builder.Property(e => e.SecondaryPlanningAreaCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Secondary planning area code");
            builder.Property(e => e.SecondaryPlanningAreaName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Secondary planning area name");
            builder.Property(e => e._201920PrimaryPhaseLocalAreaSSNoPlaces)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("2019/20 Primary Phase Local Area S/S No. places");
            builder.Property(e => e._201920PrimaryPhaseLocalAreaSSPlaces)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("2019/20 Primary Phase Local Area S/S % places");
            builder.Property(e => e._201920PrimaryPhasePlanningAreaSSNoPlaces)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("2019/20 Primary Phase Planning Area S/S No. places");
            builder.Property(e => e._201920PrimaryPhasePlanningAreaSSPlaces)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("2019/20 Primary Phase Planning Area S/S % places");
            builder.Property(e => e._201920SecondaryPhaseLocalAreaSSNoPlaces)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("2019/20 Secondary Phase Local Area S/S No. places");
            builder.Property(e => e._201920SecondaryPhaseLocalAreaSSPlaces)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("2019/20 Secondary Phase Local Area S/S % places");
            builder.Property(e => e._201920SecondaryPhasePlanningAreaSSNoPlaces)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("2019/20 Secondary Phase Planning Area S/S No. places");
            builder.Property(e => e._201920SecondaryPhasePlanningAreaSSPlaces)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("2019/20 Secondary Phase Planning Area S/S % places");

		}
	}

}
