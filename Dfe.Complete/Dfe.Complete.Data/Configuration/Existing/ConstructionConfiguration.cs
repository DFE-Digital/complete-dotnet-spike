using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class ConstructionConfiguration : IEntityTypeConfiguration< Construction>
	{
		public void Configure(EntityTypeBuilder<Construction> builder)
		{
            builder.HasKey(e => e.Rid);

            builder.ToTable("Construction", "dbo", e => e.IsTemporal());

            builder.Property(e => e.IctDetailsBroadbandOrdered)
                .HasColumnType("date")
                .HasColumnName("ICT Details.Broadband ordered");
            builder.Property(e => e.IctDetailsIctProcurementRouteAgreedWithTrust)
                .HasColumnType("date")
                .HasColumnName("ICT Details.ICT procurement route agreed with Trust");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.SiteDetailsAreaOfExistingBuildingsM2PermanentArea)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of existing buildings m2 : Permanent Area");
            builder.Property(e => e.SiteDetailsAreaOfExistingBuildingsM2TemporaryArea)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of existing buildings m2 : Temporary Area");
            builder.Property(e => e.SiteDetailsAreaOfHardStandingM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of hard standing m2");
            builder.Property(e => e.SiteDetailsAreaOfMajorRefurbishmentM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of major refurbishment m2");
            builder.Property(e => e.SiteDetailsAreaOfMinorRefurbishmentM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of minor refurbishment m2");
            builder.Property(e => e.SiteDetailsAreaOfMugaPlayingFieldsM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of MUGA / playing fields m2");
            builder.Property(e => e.SiteDetailsAreaOfNewBuildM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of new build m2");
            builder.Property(e => e.SiteDetailsAreaOfRefreshM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of refresh m2");
            builder.Property(e => e.SiteDetailsAreaOfRefurbishmentM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of refurbishment m2");
            builder.Property(e => e.SiteDetailsAreaOfTemporaryAccommodationRequiredM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Area of temporary accommodation required m2");
            builder.Property(e => e.SiteDetailsLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site Details.Location");
            builder.Property(e => e.SiteDetailsMaximumGrossAreaRequiredM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Maximum gross area required m2");
            builder.Property(e => e.SiteDetailsMinimumGrossAreaRequiredM2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site Details.Minimum gross area required m2");
            builder.Property(e => e.SiteDetailsSprinklerInstallationType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site Details.Sprinkler Installation Type");
            builder.Property(e => e.SiteDetailsSprinklerType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site Details.Sprinkler Type");
            builder.Property(e => e.SiteDetailsSprinklers)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site Details.Sprinklers");
            builder.Property(e => e.SiteDetailsTypeOfWorks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site Details.Type of works");

		}
	}

}
