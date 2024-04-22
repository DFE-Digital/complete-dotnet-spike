using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class BsConfiguration : IEntityTypeConfiguration< Bs>
	{
		public void Configure(EntityTypeBuilder<Bs> builder)
		{
            builder.ToTable("BS", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.BudgetSummaryAcquisitionBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Acquisition budget");
            builder.Property(e => e.BudgetSummaryBudgetApprovalDate)
                .HasColumnType("date")
                .HasColumnName("Budget summary.Budget approval date");
            builder.Property(e => e.BudgetSummaryBudgetApprovalProcess)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Budget approval process");
            builder.Property(e => e.BudgetSummaryBudgetStageSummary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Budget stage summary");
            builder.Property(e => e.BudgetSummaryCapitalCostTier)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Capital cost tier");
            builder.Property(e => e.BudgetSummaryConstructionBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Construction budget");
            builder.Property(e => e.BudgetSummaryCostPlan1Approved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Cost Plan 1 approved");
            builder.Property(e => e.BudgetSummaryCostPlan2Approved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Cost Plan 2 approved");
            builder.Property(e => e.BudgetSummaryCostsAtPracticalCompletionApproved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Costs at practical completion approved");
            builder.Property(e => e.BudgetSummaryFfEBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.FF&E budget");
            builder.Property(e => e.BudgetSummaryFinalAccountsAgreed)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Final accounts agreed");
            builder.Property(e => e.BudgetSummaryIctBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.ICT budget");
            builder.Property(e => e.BudgetSummaryIsTheLaMakingAFinancialContributionTowardsThisProject)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Is the LA making a financial contribution towards this project?");
            builder.Property(e => e.BudgetSummaryLaContributionType)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Budget summary.LA Contribution type");
            builder.Property(e => e.BudgetSummaryOtherContributionType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Other contribution type");
            builder.Property(e => e.BudgetSummaryPreCarFundingApproved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Pre CAR funding approved");
            builder.Property(e => e.BudgetSummaryPreCarFundingRequired)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Pre CAR funding required");
            builder.Property(e => e.BudgetSummaryStoreBudgetRecordName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Store budget record name");
            builder.Property(e => e.BudgetSummaryTemporarySiteBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Temporary Site budget");
            builder.Property(e => e.BudgetSummaryTotalCapitalBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Total capital budget");
            builder.Property(e => e.BudgetSummaryTotalRevenue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget summary.Total Revenue");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

            AuditConfiguration.Apply(builder);
        }
	}

}
