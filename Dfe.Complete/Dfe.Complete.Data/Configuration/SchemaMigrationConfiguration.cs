using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class SchemaMigrationConfiguration : IEntityTypeConfiguration<SchemaMigration>
    {
        public void Configure(EntityTypeBuilder<SchemaMigration> builder)
        {
            builder.HasKey(e => e.Version).HasName("PK__schema_m__79B5C94C4C13779A");
            builder.ToTable("schema_migrations", "complete");

            builder.Property(e => e.Version)
                .HasMaxLength(4000)
                .HasColumnName("version");

        }
    }

}
