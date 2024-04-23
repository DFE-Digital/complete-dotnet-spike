using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__events__3213E83F15C45895");

            builder.ToTable("events", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.EventableId).HasColumnName("eventable_id");
            builder.Property(e => e.EventableType)
                .HasMaxLength(4000)
                .HasColumnName("eventable_type");
            builder.Property(e => e.Grouping).HasColumnName("grouping");
            builder.Property(e => e.Message)
                .HasMaxLength(4000)
                .HasColumnName("message");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");
            builder.Property(e => e.UserId).HasColumnName("user_id");

        }
    }

}
