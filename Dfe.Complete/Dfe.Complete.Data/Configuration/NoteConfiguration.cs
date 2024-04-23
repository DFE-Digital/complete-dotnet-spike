using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__notes__3213E83FA7601CD0");
            builder.ToTable("notes", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.Body).HasColumnName("body");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.ProjectId).HasColumnName("project_id");
            builder.Property(e => e.SignificantDateHistoryId).HasColumnName("significant_date_history_id");
            builder.Property(e => e.TaskIdentifier)
                .HasMaxLength(4000)
                .HasColumnName("task_identifier");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");
            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.Project).WithMany(p => p.Notes)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("fk_rails_99e097b079");

            builder.HasOne(d => d.User).WithMany(p => p.Notes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_rails_7f2323ad43");

        }
    }

}
