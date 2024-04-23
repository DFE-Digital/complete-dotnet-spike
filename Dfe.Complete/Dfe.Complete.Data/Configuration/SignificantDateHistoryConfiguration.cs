using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class SignificantDateHistoryConfiguration : IEntityTypeConfiguration<SignificantDateHistory>
    {
        public void Configure(EntityTypeBuilder<SignificantDateHistory> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__signific__3213E83F4D572112");
            builder.ToTable("significant_date_histories", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.PreviousDate)
                .HasColumnType("date")
                .HasColumnName("previous_date");
            builder.Property(e => e.ProjectId).HasColumnName("project_id");
            builder.Property(e => e.RevisedDate)
                .HasColumnType("date")
                .HasColumnName("revised_date");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");

        }
    }

}
