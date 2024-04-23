using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class GiasGroupConfiguration : IEntityTypeConfiguration<GiasGroup>
    {
        public void Configure(EntityTypeBuilder<GiasGroup> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__gias_gro__3213E83F9E44E2E2");
            builder.ToTable("gias_groups", "complete");

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
            builder.Property(e => e.CompaniesHouseNumber)
                .HasMaxLength(4000)
                .HasColumnName("companies_house_number");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.GroupIdentifier)
                .HasMaxLength(4000)
                .HasColumnName("group_identifier");
            builder.Property(e => e.OriginalName)
                .HasMaxLength(4000)
                .HasColumnName("original_name");
            builder.Property(e => e.Ukprn).HasColumnName("ukprn");
            builder.Property(e => e.UniqueGroupIdentifier).HasColumnName("unique_group_identifier");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");

        }
    }

}
