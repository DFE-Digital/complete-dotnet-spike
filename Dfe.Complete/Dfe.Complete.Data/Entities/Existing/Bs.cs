using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Bs> Bs { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Bs : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string BudgetSummaryBudgetStageSummary { get; set; }

        public string BudgetSummaryPreCarFundingRequired { get; set; }

        public string BudgetSummaryPreCarFundingApproved { get; set; }

        public string BudgetSummaryCostPlan1Approved { get; set; }

        public string BudgetSummaryCostPlan2Approved { get; set; }

        public string BudgetSummaryCostsAtPracticalCompletionApproved { get; set; }

        public string BudgetSummaryFinalAccountsAgreed { get; set; }

        public string BudgetSummaryIsTheLaMakingAFinancialContributionTowardsThisProject { get; set; }

        public string BudgetSummaryLaContributionType { get; set; }

        public string BudgetSummaryOtherContributionType { get; set; }

        public string BudgetSummaryCapitalCostTier { get; set; }

        public string BudgetSummaryStoreBudgetRecordName { get; set; }

        public DateTime? BudgetSummaryBudgetApprovalDate { get; set; }

        public string BudgetSummaryBudgetApprovalProcess { get; set; }

        public string BudgetSummaryAcquisitionBudget { get; set; }

        public string BudgetSummaryConstructionBudget { get; set; }

        public string BudgetSummaryFfEBudget { get; set; }

        public string BudgetSummaryIctBudget { get; set; }

        public string BudgetSummaryTemporarySiteBudget { get; set; }

        public string BudgetSummaryTotalCapitalBudget { get; set; }

        public string BudgetSummaryTotalRevenue { get; set; }
    }
}