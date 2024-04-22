using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class FalConfiguration : IEntityTypeConfiguration< Fal>
	{
		public void Configure(EntityTypeBuilder<Fal> builder)
		{
            builder.ToTable("FAL", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.FundingApprovalLettersFundingApprovalLetterIssuedDate)
                .HasColumnType("date")
                .HasColumnName("Funding Approval Letters.Funding approval letter issued date");
            builder.Property(e => e.FundingApprovalLettersFundingApprovalLetterRecipient)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Funding Approval Letters.Funding approval letter recipient");
            builder.Property(e => e.FundingApprovalLettersFundingApprovalLetterTotalValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Funding Approval Letters.Funding approval letter Total value");
            builder.Property(e => e.FundingApprovalLettersId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Funding Approval Letters.ID");
            builder.Property(e => e.FundingApprovalLettersLinkToFundingApprovalLetter)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Funding Approval Letters.Link to funding approval letter");
            builder.Property(e => e.FundingApprovalLettersTotalConstruction)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Funding Approval Letters.Total construction");
            builder.Property(e => e.FundingApprovalLettersTotalFfEBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Funding Approval Letters.Total FF&E budget");
            builder.Property(e => e.FundingApprovalLettersTotalIctBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Funding Approval Letters.Total ICT budget");
            builder.Property(e => e.FundingApprovalLettersTotalTemporarySiteBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Funding Approval Letters.Total temporary site budget");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

		}
	}

}
