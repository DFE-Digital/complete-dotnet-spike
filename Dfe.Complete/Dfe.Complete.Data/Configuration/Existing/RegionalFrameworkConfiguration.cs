using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class RegionalFrameworkConfiguration : IEntityTypeConfiguration< RegionalFramework>
	{
		public void Configure(EntityTypeBuilder<RegionalFramework> builder)
		{
            builder
                .HasNoKey()
                .ToTable("Regional Framework", "dbo");

            builder.Property(e => e.HighValueBandLot)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("High Value Band Lot");
            builder.Property(e => e.LocalAuthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local authority");
            builder.Property(e => e.LowValueBandLot)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Low Value Band Lot");
            builder.Property(e => e.MediumValueBandLot)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Medium Value Band Lot");
            builder.Property(e => e.RscRegions)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RSC Regions");

		}
	}

}
