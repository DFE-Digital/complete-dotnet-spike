using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class GiasEstablishmentConfiguration : IEntityTypeConfiguration<GiasEstablishment>
    {
        public void Configure(EntityTypeBuilder<GiasEstablishment> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__gias_est__3213E83FA2A1F9EF");

            builder.ToTable("gias_establishments", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.AddressAdditional)
                .HasMaxLength(4000)
                .HasColumnName("address_additional");
            builder.Property(e => e.AddressCounty)
                .HasMaxLength(4000)
                .HasColumnName("address_county");
            builder.Property(e => e.AddressLocality)
                .HasMaxLength(4000)
                .HasColumnName("address_locality");
            builder.Property(e => e.AddressPostcode)
                .HasMaxLength(4000)
                .HasColumnName("address_postcode");
            builder.Property(e => e.AddressStreet)
                .HasMaxLength(4000)
                .HasColumnName("address_street");
            builder.Property(e => e.AddressTown)
                .HasMaxLength(4000)
                .HasColumnName("address_town");
            builder.Property(e => e.AgeRangeLower).HasColumnName("age_range_lower");
            builder.Property(e => e.AgeRangeUpper).HasColumnName("age_range_upper");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.DioceseCode)
                .HasMaxLength(4000)
                .HasColumnName("diocese_code");
            builder.Property(e => e.DioceseName)
                .HasMaxLength(4000)
                .HasColumnName("diocese_name");
            builder.Property(e => e.EstablishmentNumber)
                .HasMaxLength(4000)
                .HasColumnName("establishment_number");
            builder.Property(e => e.LocalAuthorityCode)
                .HasMaxLength(4000)
                .HasColumnName("local_authority_code");
            builder.Property(e => e.LocalAuthorityName)
                .HasMaxLength(4000)
                .HasColumnName("local_authority_name");
            builder.Property(e => e.Name)
                .HasMaxLength(4000)
                .HasColumnName("name");
            builder.Property(e => e.ParliamentaryConstituencyCode)
                .HasMaxLength(4000)
                .HasColumnName("parliamentary_constituency_code");
            builder.Property(e => e.ParliamentaryConstituencyName)
                .HasMaxLength(4000)
                .HasColumnName("parliamentary_constituency_name");
            builder.Property(e => e.PhaseCode)
                .HasMaxLength(4000)
                .HasColumnName("phase_code");
            builder.Property(e => e.PhaseName)
                .HasMaxLength(4000)
                .HasColumnName("phase_name");
            builder.Property(e => e.RegionCode)
                .HasMaxLength(4000)
                .HasColumnName("region_code");
            builder.Property(e => e.RegionName)
                .HasMaxLength(4000)
                .HasColumnName("region_name");
            builder.Property(e => e.TypeCode)
                .HasMaxLength(4000)
                .HasColumnName("type_code");
            builder.Property(e => e.TypeName)
                .HasMaxLength(4000)
                .HasColumnName("type_name");
            builder.Property(e => e.Ukprn).HasColumnName("ukprn");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");
            builder.Property(e => e.Url)
                .HasMaxLength(4000)
                .HasColumnName("url");
            builder.Property(e => e.Urn).HasColumnName("urn");

        }
    }

}
