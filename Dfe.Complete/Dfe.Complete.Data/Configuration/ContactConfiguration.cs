using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__contacts__3213E83F18693201");
            builder.ToTable("contacts", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.Category).HasColumnName("category");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.Email)
                .HasMaxLength(4000)
                .HasColumnName("email");
            builder.Property(e => e.EstablishmentUrn).HasColumnName("establishment_urn");
            builder.Property(e => e.LocalAuthorityId).HasColumnName("local_authority_id");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(4000)
                .HasColumnName("name");
            builder.Property(e => e.OrganisationName)
                .HasMaxLength(4000)
                .HasColumnName("organisation_name");
            builder.Property(e => e.Phone)
                .HasMaxLength(4000)
                .HasColumnName("phone");
            builder.Property(e => e.ProjectId).HasColumnName("project_id");
            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(4000)
                .HasColumnName("title");
            builder.Property(e => e.Type)
                .HasMaxLength(4000)
                .HasColumnName("type");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");

        }
    }

}
