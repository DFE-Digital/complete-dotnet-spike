using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class ArInternalMetadatumConfiguration : IEntityTypeConfiguration<ArInternalMetadatum>
    {
        public void Configure(EntityTypeBuilder<ArInternalMetadatum> builder)
        {
            builder.HasKey(e => e.Key).HasName("PK__ar_inter__DFD83CAEB2BD03D7");
            builder.ToTable("ar_internal_metadata", "complete");

            builder.Property(e => e.Key)
                .HasMaxLength(4000)
                .HasColumnName("key");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");
            builder.Property(e => e.Value)
                .HasMaxLength(4000)
                .HasColumnName("value");

        }
    }

}
