using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration
{
    internal class RiskAppraisalMeetingTaskConfiguration : IEntityTypeConfiguration<RiskAppraisalMeetingTask>
    {
        public void Configure(EntityTypeBuilder<RiskAppraisalMeetingTask> builder)
        {
            builder.ToTable("RiskAppraisalMeetingTask", "mfsp", e => e.IsTemporal());

            builder.HasKey(e => e.RID);

            builder.Property(e => e.RID).HasMaxLength(11);
            builder.Property(e => e.CommentOnDecision).HasMaxLength(100);
            builder.Property(e => e.ReasonNotApplicable).HasMaxLength(100);

            AuditConfiguration.Apply(builder);
        }
    }
}
