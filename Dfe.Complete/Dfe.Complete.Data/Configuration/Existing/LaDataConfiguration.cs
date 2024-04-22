using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class LaDataConfiguration : IEntityTypeConfiguration< LaData>
	{
		public void Configure(EntityTypeBuilder<LaData> builder)
		{
            builder.HasKey(e => e.LocalAuthoritiesLaCode);
            builder.ToTable("LA_Data", "dbo", e => e.IsTemporal());

            builder.Property(e => e.LocalAuthoritiesCapitalCostTier)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local Authorities.Capital cost tier");
            builder.Property(e => e.LocalAuthoritiesGeographicalRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local Authorities.Geographical region");
            builder.Property(e => e.LocalAuthoritiesLaCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local Authorities.LA Code");
            builder.Property(e => e.LocalAuthoritiesLaLondonBased)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local Authorities.LA London Based");
            builder.Property(e => e.LocalAuthoritiesLaName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local Authorities.LA Name");
            builder.Property(e => e.LocalAuthoritiesLondonNotLondon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local Authorities.London/Not London");
            builder.Property(e => e.LocalAuthoritiesRscRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local Authorities.RSC Region");

		}
	}

}
