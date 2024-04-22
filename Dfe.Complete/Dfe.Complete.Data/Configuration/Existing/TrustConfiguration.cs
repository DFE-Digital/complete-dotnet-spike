using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class TrustConfiguration : IEntityTypeConfiguration< Trust>
	{
		public void Configure(EntityTypeBuilder<Trust> builder)
		{
            builder.HasKey(e => e.Rid);

            builder.ToTable("Trust", "dbo", e => e.IsTemporal());

            builder.Property(e => e.LeadSponsor)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lead Sponsor");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.TrustRef)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Trust ref");
            builder.Property(e => e.TrustsLeadSponsorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Trusts.Lead sponsor id");
            builder.Property(e => e.TrustsLeadSponsorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Trusts.Lead sponsor name");
            builder.Property(e => e.TrustsTrustName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Trusts.Trust name");
            builder.Property(e => e.TrustsTrustRef)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Trusts.Trust ref");
            builder.Property(e => e.TrustsTrustType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Trusts.Trust type");

		}
	}

}
