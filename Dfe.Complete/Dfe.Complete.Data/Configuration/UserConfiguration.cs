using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "mfsp", e => e.IsTemporal());
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(e => e.Email).HasMaxLength(80);
            builder
                .HasMany(e => e.Projects)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);
        }
    }
}
