using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Fal> Fal { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Fal
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string FundingApprovalLettersId { get; set; }

        public DateTime? FundingApprovalLettersFundingApprovalLetterIssuedDate { get; set; }

        public string FundingApprovalLettersLinkToFundingApprovalLetter { get; set; }

        public string FundingApprovalLettersFundingApprovalLetterRecipient { get; set; }

        public string FundingApprovalLettersTotalConstruction { get; set; }

        public string FundingApprovalLettersTotalFfEBudget { get; set; }

        public string FundingApprovalLettersTotalIctBudget { get; set; }

        public string FundingApprovalLettersTotalTemporarySiteBudget { get; set; }

        public string FundingApprovalLettersFundingApprovalLetterTotalValue { get; set; }
    }
}