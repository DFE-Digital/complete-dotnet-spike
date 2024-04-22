using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class WfaConfiguration : IEntityTypeConfiguration< Wfa>
	{
		public void Configure(EntityTypeBuilder<Wfa> builder)
		{
            builder.HasKey(e => e.Rid);

           builder.ToTable("WFA", "dbo", e => e.IsTemporal());

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.WorksFundingAgreementsWfaId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Works Funding Agreements.WFA ID");
            builder.Property(e => e.WorksFundingAgreementsWorkFundingAgreementIssuedDate)
                .HasColumnType("date")
                .HasColumnName("Works Funding Agreements.Work Funding Agreement issued date");
            builder.Property(e => e.WorksFundingAgreementsWorkFundingAgreementTotalValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Works Funding Agreements.Work Funding Agreement total value");

		}
	}

}
