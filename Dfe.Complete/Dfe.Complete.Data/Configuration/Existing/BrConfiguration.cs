using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class BrConfiguration : IEntityTypeConfiguration< Br>
	{
		public void Configure(EntityTypeBuilder<Br> builder)
		{
            builder.ToTable("BR", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.BudgetRecordsAcquisitionCostVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Acquisition cost VAT");
            builder.Property(e => e.BudgetRecordsAcquisitionManualOverride).HasColumnName("Budget Records.Acquisition manual override");
            builder.Property(e => e.BudgetRecordsAqusitionRevenue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Aqusition Revenue");
            builder.Property(e => e.BudgetRecordsBroadband)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Broadband");
            builder.Property(e => e.BudgetRecordsBudgetApprovalProcess)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Budget approval process");
            builder.Property(e => e.BudgetRecordsBudgetId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Budget ID");
            builder.Property(e => e.BudgetRecordsBudgetStage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Budget stage");
            builder.Property(e => e.BudgetRecordsBudgetStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Budget status");
            builder.Property(e => e.BudgetRecordsCcfPropertyBudgetUplift)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.CCF property budget uplift");
            builder.Property(e => e.BudgetRecordsConstructionAmountIncludingSurveys)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Construction amount , including surveys");
            builder.Property(e => e.BudgetRecordsConstructionAmountIncludingSurveysVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Construction amount , including surveys VAT");
            builder.Property(e => e.BudgetRecordsConstructionManualOverride).HasColumnName("Budget Records.Construction manual override");
            builder.Property(e => e.BudgetRecordsConstructionRevenue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Construction revenue");
            builder.Property(e => e.BudgetRecordsCostOfReInstatementOfTemporaryAccommodation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Cost of re-instatement of temporary accommodation");
            builder.Property(e => e.BudgetRecordsCostPerPupil)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Cost Per Pupil");
            builder.Property(e => e.BudgetRecordsEfaCapitalRegionalDdApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.EFA Capital Regional DD (approval status)");
            builder.Property(e => e.BudgetRecordsEfaCapitalRegionalDdApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.EFA Capital Regional DD (approver name)");
            builder.Property(e => e.BudgetRecordsEfaCapitalRegionalDdDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.EFA Capital Regional DD (decision date)");
            builder.Property(e => e.BudgetRecordsFfEManualOverride).HasColumnName("Budget Records.FF&E manual override");
            builder.Property(e => e.BudgetRecordsFinalCarCcfFormLink)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Final CAR / CCF Form link");
            builder.Property(e => e.BudgetRecordsFinalPropertyModelLink)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Final property model link");
            builder.Property(e => e.BudgetRecordsFinalTechnicalFundingAllocationModelLink)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Final technical funding allocation model link");
            builder.Property(e => e.BudgetRecordsFixturesFurnitureAndEquipment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Fixtures, Furniture, and Equipment");
            builder.Property(e => e.BudgetRecordsFixturesFurnitureAndEquipmentVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Fixtures, Furniture, and Equipment VAT");
            builder.Property(e => e.BudgetRecordsFpmuApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.FPMU (approval status)");
            builder.Property(e => e.BudgetRecordsFpmuApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.FPMU (approver name)");
            builder.Property(e => e.BudgetRecordsFpmuDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.FPMU (decision date)");
            builder.Property(e => e.BudgetRecordsFscDivisionalDirectorApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.FSC Divisional Director (approval status)");
            builder.Property(e => e.BudgetRecordsFscDivisionalDirectorApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.FSC Divisional Director (approver name)");
            builder.Property(e => e.BudgetRecordsFscDivisionalDirectorDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.FSC Divisional Director (decision date)");
            builder.Property(e => e.BudgetRecordsFscHeadOfFinanceApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.FSC Head of Finance (approval status)");
            builder.Property(e => e.BudgetRecordsFscHeadOfFinanceApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.FSC Head of Finance (approver name)");
            builder.Property(e => e.BudgetRecordsFscHeadOfFinanceDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.FSC Head of Finance (decision date)");
            builder.Property(e => e.BudgetRecordsIctActives)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.ICT actives");
            builder.Property(e => e.BudgetRecordsIctBudgetManualOverride).HasColumnName("Budget Records.ICT budget manual override");
            builder.Property(e => e.BudgetRecordsIctDecantCost)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.ICT decant cost");
            builder.Property(e => e.BudgetRecordsIctEquipmentHardware)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.ICT equipment/hardware");
            builder.Property(e => e.BudgetRecordsIctPassives)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.ICT passives");
            builder.Property(e => e.BudgetRecordsIndependentFinanceReviewerApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Independent Finance Reviewer (approval status)");
            builder.Property(e => e.BudgetRecordsIndependentFinanceReviewerApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Independent Finance Reviewer (approver name)");
            builder.Property(e => e.BudgetRecordsIndependentFinanceReviewerDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.Independent Finance Reviewer (decision date)");
            builder.Property(e => e.BudgetRecordsIndependentPropertyReviewerApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Independent Property Reviewer (approval status)");
            builder.Property(e => e.BudgetRecordsIndependentPropertyReviewerApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Independent Property Reviewer (approver name)");
            builder.Property(e => e.BudgetRecordsIndependentPropertyReviewerDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.Independent Property Reviewer (decision date)");
            builder.Property(e => e.BudgetRecordsIndependentTechnicalCostQsApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Independent Technical & Cost QS (approval status)");
            builder.Property(e => e.BudgetRecordsIndependentTechnicalCostQsApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Independent Technical & Cost QS (approver name)");
            builder.Property(e => e.BudgetRecordsIndependentTechnicalCostQsDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.Independent Technical & Cost QS (decision date)");
            builder.Property(e => e.BudgetRecordsInflationBaseDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.Inflation base date");
            builder.Property(e => e.BudgetRecordsLegalFeesConstructionAdviceIncVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Legal fees - construction advice (Inc VAT)");
            builder.Property(e => e.BudgetRecordsLiveBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Live budget");
            builder.Property(e => e.BudgetRecordsLocatedInvestmentCommitteeApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Located Investment Committee (approval status)");
            builder.Property(e => e.BudgetRecordsLocatedInvestmentCommitteeApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Located Investment Committee (approver name)");
            builder.Property(e => e.BudgetRecordsLocatedInvestmentCommitteeDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.Located Investment Committee (decision date)");
            builder.Property(e => e.BudgetRecordsMinisterApprovalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Minister (approval status)");
            builder.Property(e => e.BudgetRecordsMinisterApproverName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Minister (approver name)");
            builder.Property(e => e.BudgetRecordsMinisterDecisionDate)
                .HasColumnType("date")
                .HasColumnName("Budget Records.Minister (decision date)");
            builder.Property(e => e.BudgetRecordsNumberOfPupils)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Number of pupils");
            builder.Property(e => e.BudgetRecordsProjectCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Project code");
            builder.Property(e => e.BudgetRecordsProjectName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Project name");
            builder.Property(e => e.BudgetRecordsPropertyManagementCosts)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Property management costs");
            builder.Property(e => e.BudgetRecordsRevenueManualOverride).HasColumnName("Budget Records.Revenue manual override");
            builder.Property(e => e.BudgetRecordsTechnicalFeesIncVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Technical fees (inc VAT)");
            builder.Property(e => e.BudgetRecordsTechnicalFeesSurveysIncVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Technical fees - surveys (inc VAT)");
            builder.Property(e => e.BudgetRecordsTemporaryConstructionIncludingSurveys)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Temporary construction, including surveys");
            builder.Property(e => e.BudgetRecordsTemporaryConstructionIncludingSurveysVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Temporary construction, including surveys - VAT");
            builder.Property(e => e.BudgetRecordsTemporarySiteIctPassives)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Temporary site ICT passives");
            builder.Property(e => e.BudgetRecordsTemporarySiteManualOverride).HasColumnName("Budget Records.Temporary site manual override");
            builder.Property(e => e.BudgetRecordsTemporarySitesLegalFeesConstructionAdviceIncVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Temporary sites - legal fees construction advice (inc VAT)");
            builder.Property(e => e.BudgetRecordsTemporarySitesTechnicalFeesIncVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Temporary sites - technical fees (inc VAT)");
            builder.Property(e => e.BudgetRecordsTemporarySitesTechnicalFeesSurveysIncVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Temporary sites - technical fees surveys (inc VAT)");
            builder.Property(e => e.BudgetRecordsThirdPartyContributions)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Third party contributions");
            builder.Property(e => e.BudgetRecordsTotalAcquisitionCostExcVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total acquisition cost ( exc VAT )");
            builder.Property(e => e.BudgetRecordsTotalAcquisitionLegalFees)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total acquisition legal fees");
            builder.Property(e => e.BudgetRecordsTotalCapitalBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total capital budget");
            builder.Property(e => e.BudgetRecordsTotalConstructionBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total construction budget");
            builder.Property(e => e.BudgetRecordsTotalFfEBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total FF&E budget");
            builder.Property(e => e.BudgetRecordsTotalIctBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total ICT budget");
            builder.Property(e => e.BudgetRecordsTotalManualOverride).HasColumnName("Budget Records.Total manual override");
            builder.Property(e => e.BudgetRecordsTotalPropertyBudgetInclVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total property budget ( incl VAT)");
            builder.Property(e => e.BudgetRecordsTotalPropertyFees)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total property fees");
            builder.Property(e => e.BudgetRecordsTotalRevenue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total revenue");
            builder.Property(e => e.BudgetRecordsTotalTemporarySitesBudget)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.Total temporary sites budget");
            builder.Property(e => e.BudgetRecordsVatOnFees)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.VAT on fees");
            builder.Property(e => e.BudgetRecordsWipNotes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Budget Records.WIP notes");
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
