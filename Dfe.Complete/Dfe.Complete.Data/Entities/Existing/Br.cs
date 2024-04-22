using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Br> Br { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Br
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string BudgetRecordsProjectCode { get; set; }

        public string BudgetRecordsNumberOfPupils { get; set; }

        public string BudgetRecordsProjectName { get; set; }

        public string BudgetRecordsBudgetId { get; set; }

        public string BudgetRecordsBudgetStage { get; set; }

        public string BudgetRecordsBudgetApprovalProcess { get; set; }

        public string BudgetRecordsBudgetStatus { get; set; }

        public string BudgetRecordsLiveBudget { get; set; }

        public DateTime? BudgetRecordsInflationBaseDate { get; set; }

        public string BudgetRecordsCostPerPupil { get; set; }

        public string BudgetRecordsTotalAcquisitionCostExcVat { get; set; }

        public string BudgetRecordsVatOnFees { get; set; }

        public string BudgetRecordsAcquisitionCostVat { get; set; }

        public string BudgetRecordsPropertyManagementCosts { get; set; }

        public string BudgetRecordsTotalPropertyFees { get; set; }

        public string BudgetRecordsTotalAcquisitionLegalFees { get; set; }

        public string BudgetRecordsCcfPropertyBudgetUplift { get; set; }

        public string BudgetRecordsTotalPropertyBudgetInclVat { get; set; }

        public bool? BudgetRecordsAcquisitionManualOverride { get; set; }

        public string BudgetRecordsFinalPropertyModelLink { get; set; }

        public string BudgetRecordsConstructionAmountIncludingSurveys { get; set; }

        public string BudgetRecordsIctPassives { get; set; }

        public string BudgetRecordsConstructionAmountIncludingSurveysVat { get; set; }

        public string BudgetRecordsTechnicalFeesSurveysIncVat { get; set; }

        public string BudgetRecordsTechnicalFeesIncVat { get; set; }

        public string BudgetRecordsLegalFeesConstructionAdviceIncVat { get; set; }

        public string BudgetRecordsTotalConstructionBudget { get; set; }

        public bool? BudgetRecordsConstructionManualOverride { get; set; }

        public string BudgetRecordsFixturesFurnitureAndEquipment { get; set; }

        public string BudgetRecordsFixturesFurnitureAndEquipmentVat { get; set; }

        public string BudgetRecordsTotalFfEBudget { get; set; }

        public bool? BudgetRecordsFfEManualOverride { get; set; }

        public string BudgetRecordsIctEquipmentHardware { get; set; }

        public string BudgetRecordsIctActives { get; set; }

        public string BudgetRecordsBroadband { get; set; }

        public string BudgetRecordsTotalIctBudget { get; set; }

        public bool? BudgetRecordsIctBudgetManualOverride { get; set; }

        public string BudgetRecordsTemporaryConstructionIncludingSurveys { get; set; }

        public string BudgetRecordsTemporarySiteIctPassives { get; set; }

        public string BudgetRecordsTemporaryConstructionIncludingSurveysVat { get; set; }

        public string BudgetRecordsTemporarySitesTechnicalFeesIncVat { get; set; }

        public string BudgetRecordsIctDecantCost { get; set; }

        public string BudgetRecordsTemporarySitesTechnicalFeesSurveysIncVat { get; set; }

        public string BudgetRecordsTemporarySitesLegalFeesConstructionAdviceIncVat { get; set; }

        public string BudgetRecordsCostOfReInstatementOfTemporaryAccommodation { get; set; }

        public string BudgetRecordsTotalTemporarySitesBudget { get; set; }

        public bool? BudgetRecordsTemporarySiteManualOverride { get; set; }

        public string BudgetRecordsFinalTechnicalFundingAllocationModelLink { get; set; }

        public string BudgetRecordsThirdPartyContributions { get; set; }

        public string BudgetRecordsTotalCapitalBudget { get; set; }

        public bool? BudgetRecordsTotalManualOverride { get; set; }

        public string BudgetRecordsConstructionRevenue { get; set; }

        public string BudgetRecordsAqusitionRevenue { get; set; }

        public string BudgetRecordsTotalRevenue { get; set; }

        public bool? BudgetRecordsRevenueManualOverride { get; set; }

        public string BudgetRecordsFpmuApproverName { get; set; }

        public DateTime? BudgetRecordsFpmuDecisionDate { get; set; }

        public string BudgetRecordsFpmuApprovalStatus { get; set; }

        public string BudgetRecordsIndependentPropertyReviewerApproverName { get; set; }

        public DateTime? BudgetRecordsIndependentPropertyReviewerDecisionDate { get; set; }

        public string BudgetRecordsIndependentPropertyReviewerApprovalStatus { get; set; }

        public string BudgetRecordsIndependentTechnicalCostQsApproverName { get; set; }

        public DateTime? BudgetRecordsIndependentTechnicalCostQsDecisionDate { get; set; }

        public string BudgetRecordsIndependentTechnicalCostQsApprovalStatus { get; set; }

        public string BudgetRecordsEfaCapitalRegionalDdApproverName { get; set; }

        public DateTime? BudgetRecordsEfaCapitalRegionalDdDecisionDate { get; set; }

        public string BudgetRecordsEfaCapitalRegionalDdApprovalStatus { get; set; }

        public string BudgetRecordsIndependentFinanceReviewerApproverName { get; set; }

        public DateTime? BudgetRecordsIndependentFinanceReviewerDecisionDate { get; set; }

        public string BudgetRecordsIndependentFinanceReviewerApprovalStatus { get; set; }

        public string BudgetRecordsLocatedInvestmentCommitteeApproverName { get; set; }

        public DateTime? BudgetRecordsLocatedInvestmentCommitteeDecisionDate { get; set; }

        public string BudgetRecordsLocatedInvestmentCommitteeApprovalStatus { get; set; }

        public string BudgetRecordsFscHeadOfFinanceApproverName { get; set; }

        public DateTime? BudgetRecordsFscHeadOfFinanceDecisionDate { get; set; }

        public string BudgetRecordsFscHeadOfFinanceApprovalStatus { get; set; }

        public string BudgetRecordsFscDivisionalDirectorApproverName { get; set; }

        public DateTime? BudgetRecordsFscDivisionalDirectorDecisionDate { get; set; }

        public string BudgetRecordsFscDivisionalDirectorApprovalStatus { get; set; }

        public string BudgetRecordsMinisterApproverName { get; set; }

        public DateTime? BudgetRecordsMinisterDecisionDate { get; set; }

        public string BudgetRecordsMinisterApprovalStatus { get; set; }

        public string BudgetRecordsFinalCarCcfFormLink { get; set; }

        public string BudgetRecordsWipNotes { get; set; }
    }
}