using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class LocalAuthorityConfiguration : IEntityTypeConfiguration<LocalAuthority>
    {
        public void Configure(EntityTypeBuilder<LocalAuthority> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__local_au__3213E83F2525D5E8");
            builder.ToTable("local_authorities", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.Address1)
                .IsRequired()
                .HasMaxLength(4000)
                .HasColumnName("address_1");
            builder.Property(e => e.Address2)
                .HasMaxLength(4000)
                .HasColumnName("address_2");
            builder.Property(e => e.Address3)
                .HasMaxLength(4000)
                .HasColumnName("address_3");
            builder.Property(e => e.AddressCounty)
                .HasMaxLength(4000)
                .HasColumnName("address_county");
            builder.Property(e => e.AddressPostcode)
                .IsRequired()
                .HasMaxLength(4000)
                .HasColumnName("address_postcode");
            builder.Property(e => e.AddressTown)
                .HasMaxLength(4000)
                .HasColumnName("address_town");
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(4000)
                .HasColumnName("code");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(4000)
                .HasColumnName("name");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");

        }
    }

}
