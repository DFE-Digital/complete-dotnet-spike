using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__users__3213E83FDA9FBF89");
            builder.ToTable("users", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.ActiveDirectoryUserGroupIds)
                .HasMaxLength(4000)
                .HasColumnName("active_directory_user_group_ids");
            builder.Property(e => e.ActiveDirectoryUserId)
                .HasMaxLength(4000)
                .HasColumnName("active_directory_user_id");
            builder.Property(e => e.AddNewProject).HasColumnName("add_new_project");
            builder.Property(e => e.AssignToProject)
                .HasDefaultValueSql("((0))")
                .HasColumnName("assign_to_project");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.DeactivatedAt)
                .HasPrecision(6)
                .HasColumnName("deactivated_at");
            builder.Property(e => e.Email)
                .HasMaxLength(4000)
                .HasColumnName("email");
            builder.Property(e => e.FirstName)
                .HasMaxLength(4000)
                .HasColumnName("first_name");
            builder.Property(e => e.LastName)
                .HasMaxLength(4000)
                .HasColumnName("last_name");
            builder.Property(e => e.LatestSession)
                .HasPrecision(6)
                .HasColumnName("latest_session");
            builder.Property(e => e.ManageConversionUrns)
                .HasDefaultValueSql("((0))")
                .HasColumnName("manage_conversion_urns");
            builder.Property(e => e.ManageLocalAuthorities)
                .HasDefaultValueSql("((0))")
                .HasColumnName("manage_local_authorities");
            builder.Property(e => e.ManageTeam)
                .HasDefaultValueSql("((0))")
                .HasColumnName("manage_team");
            builder.Property(e => e.ManageUserAccounts)
                .HasDefaultValueSql("((0))")
                .HasColumnName("manage_user_accounts");
            builder.Property(e => e.Team)
                .HasMaxLength(4000)
                .HasColumnName("team");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");

        }
    }

}
