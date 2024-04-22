using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration
{
    public static class AuditConfiguration
    {
        public static void Apply<T>(EntityTypeBuilder<T> builder) where T : IAuditable
        {
            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.UpdatedByUserId)
                .IsRequired(false);
        }
    }
}
