using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PoConfiguration : IEntityTypeConfiguration< Po>
	{
		public void Configure(EntityTypeBuilder<Po> builder)
		{
            builder
                .ToTable("PO", "dbo", e => e.IsTemporal())
                .HasKey(e => e.Rid);

            builder.Property(e => e.FinancialPlanningOptInToRpa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Planning.Opt in to RPA");
            builder.Property(e => e.FinancialPlanningStartDateOfRpa)
                .HasColumnType("date")
                .HasColumnName("Financial Planning.Start date of RPA");
            builder.Property(e => e.FinancialPlanningTypeOfRpaCover)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Financial Planning.Type of RPA cover");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.ProjectDevelopmentGrantFunding1stPdgGrantVariationDate)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.1st PDG grant variation date");
            builder.Property(e => e.ProjectDevelopmentGrantFunding1stPdgGrantVariationLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.1st PDG grant variation link");
            builder.Property(e => e.ProjectDevelopmentGrantFunding1stWriteOffApprovedInFsgBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.1st write off approved in FSG by");
            builder.Property(e => e.ProjectDevelopmentGrantFunding2ndDateWriteOffApprovedByFinanceBusinessPartners)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.2nd Date write off approved by Finance Business Partners");
            builder.Property(e => e.ProjectDevelopmentGrantFunding2ndFinanceBusinessPartnerApprovalReceivedFrom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.2nd Finance Business Partner Approval received from");
            builder.Property(e => e.ProjectDevelopmentGrantFunding2ndLinkWriteOffPaperworkRepository)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.2nd Link write off paperwork repository");
            builder.Property(e => e.ProjectDevelopmentGrantFunding2ndPdgGrantVariationDate)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.2nd PDG grant variation date");
            builder.Property(e => e.ProjectDevelopmentGrantFunding2ndPdgGrantVariationLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.2nd PDG grant variation link");
            builder.Property(e => e.ProjectDevelopmentGrantFunding2ndWriteOffApprovedInFsgBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.2nd write off approved in FSG by");
            builder.Property(e => e.ProjectDevelopmentGrantFunding3rdDateWriteOffApprovedByFinanceBusinessPartners)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.3rd Date write off approved by Finance Business Partners");
            builder.Property(e => e.ProjectDevelopmentGrantFunding3rdFinanceBusinessPartnerApprovalReceivedFrom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.3rd Finance Business Partner Approval received from");
            builder.Property(e => e.ProjectDevelopmentGrantFunding3rdLinkWriteOffPaperworkRepository)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.3rd Link write off paperwork repository");
            builder.Property(e => e.ProjectDevelopmentGrantFunding3rdPdgGrantVariationDate)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.3rd PDG grant variation date");
            builder.Property(e => e.ProjectDevelopmentGrantFunding3rdPdgGrantVariationLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.3rd PDG grant variation link");
            builder.Property(e => e.ProjectDevelopmentGrantFunding3rdWriteOffApprovedInFsgBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.3rd write off approved in FSG by");
            builder.Property(e => e.ProjectDevelopmentGrantFunding4thPdgGrantVariationDate)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.4th PDG grant variation date");
            builder.Property(e => e.ProjectDevelopmentGrantFunding4thPdgGrantVariationLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.4th PDG grant variation link");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountApprovedFor1stWriteOff)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount approved for 1st write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountApprovedFor2ndWriteOff)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount approved for 2nd write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountApprovedFor3rdWriteOff)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount approved for 3rd write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountCleared)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount Cleared");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf10thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 10th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf10thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 10th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf11thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 11th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf11thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 11th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf12thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 12th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf12thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 12th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf1stPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 1st payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf1stPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 1st payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf1stRefund)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 1st refund ");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf2ndPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 2nd payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 2nd payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf2ndRefund)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 2nd refund ");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf3rdPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 3rd payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 3rd payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf3rdRefund)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 3rd refund");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf4thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 4th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf4thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 4th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf5thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 5th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf5thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 5th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf6thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 6th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf6thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 6th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf7thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 7th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf7thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 7th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf8thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 8th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf8thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 8th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf9thPayment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 9th payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountOf9thPaymentDue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount of 9th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountRealised)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount Realised");
            builder.Property(e => e.ProjectDevelopmentGrantFundingAmountToBeUnderwritten)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Amount to be Underwritten");
            builder.Property(e => e.ProjectDevelopmentGrantFundingContingencyClearedRealised)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Contingency Cleared / Realised");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateNextFinancialStatementBudgetProfileIsDueBack)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date next financial statement / budget profile is due back");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf10thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 10th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf10thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 10th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf11thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 11th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf11thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 11th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf12thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 12th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf12thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 12th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf1stActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 1st actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf1stPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 1st payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf1stRefund)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 1st refund");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf1stWriteOff)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 1st write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf2ndActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 2nd actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf2ndPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 2nd payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf2ndRefund)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 2nd refund");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf2ndWriteOff)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 2nd write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf3rdActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 3rd actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf3rdPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 3rd payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf3rdRefund)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 3rd refund");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf3rdWriteOff)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 3rd write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf4thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 4th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf4thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 4th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf5thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 5th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf5thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 5th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf6thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 6th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf6thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 6th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf7thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 7th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf7thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 7th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf8thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 8th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf8thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 8th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf9thActualPayment)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 9th actual payment");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateOf9thPaymentDue)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date of 9th payment due");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDatePaymentsStopped)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date payments stopped");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateSop7ActionTaken)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date SOP7 action Taken");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateUnderwriteApproved)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date underwrite approved");
            builder.Property(e => e.ProjectDevelopmentGrantFundingDateWriteOffApprovedByFinanceBusinessPartners)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.Date write off approved by Finance Business Partners");
            builder.Property(e => e.ProjectDevelopmentGrantFundingFinanceBusinessPartnerApprovalReceivedFrom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Finance Business Partner Approval received from");
            builder.Property(e => e.ProjectDevelopmentGrantFundingInitialGrantAllocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Initial grant allocation");
            builder.Property(e => e.ProjectDevelopmentGrantFundingLinkWriteOffPaperworkRepository)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Link write off paperwork repository");
            builder.Property(e => e.ProjectDevelopmentGrantFundingManuallyOverwrite).HasColumnName("Project Development Grant Funding.Manually overwrite?");
            builder.Property(e => e.ProjectDevelopmentGrantFundingPaymentAmountWrittenOff)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Payment amount written off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingPaymentsStopped)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Payments stopped");
            builder.Property(e => e.ProjectDevelopmentGrantFundingPdgGrantLetterDate)
                .HasColumnType("date")
                .HasColumnName("Project Development Grant Funding.PDG grant letter date");
            builder.Property(e => e.ProjectDevelopmentGrantFundingPdgGrantLetterLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.PDG grant letter link");
            builder.Property(e => e.ProjectDevelopmentGrantFundingPeriodOfUnderwrite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Period of Underwrite");
            builder.Property(e => e.ProjectDevelopmentGrantFundingPo01ManuallyOverwrite).HasColumnName("Project Development Grant Funding.PO01_Manually Overwrite");
            builder.Property(e => e.ProjectDevelopmentGrantFundingReasonFor1stWriteOff)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Reason for 1st write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingReasonFor2ndWriteOff)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Reason for 2nd write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingReasonFor3rdWriteOff)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Reason for 3rd write off");
            builder.Property(e => e.ProjectDevelopmentGrantFundingReasonForLiability)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Reason for Liability");
            builder.Property(e => e.ProjectDevelopmentGrantFundingRevisedGrantAllocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Revised grant allocation");
            builder.Property(e => e.ProjectDevelopmentGrantFundingSop7ActionTaken)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.SOP7 Action Taken");
            builder.Property(e => e.ProjectDevelopmentGrantFundingSopSupplierNumber)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.SOP Supplier Number");
            builder.Property(e => e.ProjectDevelopmentGrantFundingStoppedPaymentsAuthorisedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Stopped payments authorised by");
            builder.Property(e => e.ProjectDevelopmentGrantFundingTotalPaymentsMade)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Total payments made");
            builder.Property(e => e.ProjectDevelopmentGrantFundingUnderwriteApprovedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Development Grant Funding.Underwrite approved by");
            builder.Property(e => e.PupilNumbersAndCapacityAcademicYearFifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Academic year - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityAcademicYearFirstYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Academic year - First year");
            builder.Property(e => e.PupilNumbersAndCapacityAcademicYearFourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Academic year - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityAcademicYearSecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Academic year - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityAcademicYearSeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Academic year - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityAcademicYearSixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Academic year - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityAcademicYearThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Academic year- Third year");
            builder.Property(e => e.PupilNumbersAndCapacityAcceptedApplicationsVsPanY12Y14)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% accepted applications vs PAN Y12-Y14");
            builder.Property(e => e.PupilNumbersAndCapacityAcceptedApplicationsVsPanY7Y11)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% accepted applications vs PAN Y7-Y11");
            builder.Property(e => e.PupilNumbersAndCapacityAcceptedApplicationsVsPanYrY6)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% accepted applications vs PAN YR-Y6");
            builder.Property(e => e.PupilNumbersAndCapacityAcceptedApplicationsVsViabilityY12Y14)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% accepted applications vs viability Y12-Y14");
            builder.Property(e => e.PupilNumbersAndCapacityAcceptedApplicationsVsViabilityY7Y11)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% accepted applications vs viability Y7-Y11");
            builder.Property(e => e.PupilNumbersAndCapacityAcceptedApplicationsVsViabilityYrY6)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% accepted applications vs viability YR-Y6");
            builder.Property(e => e.PupilNumbersAndCapacityAdmissionsBody)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Admissions body");
            builder.Property(e => e.PupilNumbersAndCapacityCellA10Year8CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A10 Year 8 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA11Year9CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A11 Year 9 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA12Year10CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A12 Year 10 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA13Year11CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A13 Year 11 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA14Year12CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A14 Year 12 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA15Year13CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A15 Year 13 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA16Year14CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A16 Year 14 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA1NurseryCurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A1 Nursery - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA2ReceptionCurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A2 Reception - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA3Year1CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A3 Year 1 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA4Year2CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A4 Year 2 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA5Year3CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A5 Year 3 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA6Year4CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A6 Year 4 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA7Year5CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A7 Year 5 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA8Year6CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A8 Year 6 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellA9Year7CurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_A9 Year 7 - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellB10Year8FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B10 Year 8 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB11Year9FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B11 Year 9 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB12Year10FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B12 Year 10 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB13Year11FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B13 Year 11 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB14Year12FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B14 Year 12 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB15Year13FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B15 Year 13 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB16Year14FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B16 Year 14 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB1NurseryFirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B1 Nursery - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB2ReceptionFirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B2 Reception - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB3Year1FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B3 Year 1 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB4Year2FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B4 Year 2 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB5Year3FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B5 Year 3 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB6Year4FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B6 Year 4 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB7Year5FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B7 Year 5 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB8Year6FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B8 Year 6 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellB9Year7FirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_B9 Year 7 - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC10Year8SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C10 Year 8 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC11Year9SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C11 Year 9 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC12Year10SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C12 Year 10 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC13Year11SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C13 Year 11 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC14Year12SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C14 Year 12 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC15Year13SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C15 Year 13 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC16Year14SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C16 Year 14 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC1NurserySecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C1 Nursery - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC2ReceptionSecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C2 Reception - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC3Year1SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C3 Year 1 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC4Year2SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C4 Year 2 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC5Year3SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C5 Year 3 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC6Year4SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C6 Year 4 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC7Year5SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C7 Year 5 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC8Year6SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C8 Year 6 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellC9Year7SecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_C9 Year 7 - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD10Year8ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D10 Year 8 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD11Year9ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D11 Year 9 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD12Year10ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D12 Year 10 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD13Year11ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D13 Year 11 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD14Year12ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D14 Year 12 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD15Year13ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D15 Year 13 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD16Year14ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D16 Year 14 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD1NurseryThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D1 Nursery - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD2ReceptionThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D2 Reception - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD3Year1ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D3 Year 1 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD4Year2ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D4 Year 2 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD5Year3ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D5 Year 3 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD6Year4ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D6 Year 4 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD7Year5ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D7 Year 5 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD8Year6ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D8 Year 6 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellD9Year7ThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_D9 Year 7 - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE10Year8FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E10 Year 8 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE11Year9FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E11 Year 9 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE12Year10FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E12 Year 10 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE13Year11FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E13 Year 11 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE14Year12FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E14 Year 12 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE15Year13FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E15 Year 13 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE16Year14FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E16 Year 14 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE1NurseryFourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E1 Nursery - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE2ReceptionFourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E2 Reception - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE3Year1FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E3 Year 1 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE4Year2FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E4 Year 2 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE5Year3FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E5 Year 3 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE6Year4FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E6 Year 4 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE7Year5FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E7 Year 5 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE8Year6FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E8 Year 6 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellE9Year7FourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_E9 Year 7 - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF10Year8FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F10 Year 8 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF11Year9FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F11 Year 9 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF12Year10FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F12 Year 10 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF13Year11FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F13 Year 11 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF14Year12FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F14 Year 12 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF15Year13FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F15 Year 13 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF16Year14FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F16 Year 14 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF1NurseryFifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F1 Nursery - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF2ReceptionFifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F2 Reception - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF3Year1FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F3 Year 1 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF4Year2FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F4 Year 2 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF5Year3FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F5 Year 3 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF6Year4FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F6 Year 4 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF7Year5FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F7 Year 5 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF8Year6FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F8 Year 6 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellF9Year7FifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_F9 Year 7 - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG10Year8SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G10 Year 8 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG11Year9SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G11 Year 9 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG12Year10SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G12 Year 10 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG13Year11SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G13 Year 11 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG14Year12SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G14 Year 12 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG15Year13SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G15 Year 13 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG16Year14SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G16 Year 14 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG1NurserySixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G1 Nursery - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG2ReceptionSixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G2 Reception - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG3Year1SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G3 Year 1 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG4Year2SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G4 Year 2 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG5Year3SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G5 Year 3 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG6Year4SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G6 Year 4 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG7Year5SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G7 Year 5 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG8Year6SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G8 Year 6 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellG9Year7SixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_G9 Year 7 - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH10Year8SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H10 Year 8 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH11Year9SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H11 Year 9 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH12Year10SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H12 Year 10 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH13Year11SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H13 Year 11 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH14Year12SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H14 Year 12 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH15Year13SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H15 Year 13 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH16Year14SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H16 Year 14 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH1NurserySeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H1 Nursery - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH2ReceptionSeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H2 Reception - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH3Year1SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H3 Year 1 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH4Year2SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H4 Year 2 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH5Year3SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H5 Year 3 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH6Year4SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H6 Year 4 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH7Year5SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H7 Year 5 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH8Year6SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H8 Year 6 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellH9Year7SeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_H9 Year 7 - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityCellTotalATotalCurrentPupilNumbersIfAlreadyOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_TotalA Total - current pupil numbers (if already open)");
            builder.Property(e => e.PupilNumbersAndCapacityCellTotalBTotalFirstYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_TotalB Total - First year");
            builder.Property(e => e.PupilNumbersAndCapacityCellTotalCTotalSecondYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_TotalC Total - Second year");
            builder.Property(e => e.PupilNumbersAndCapacityCellTotalDTotalThirdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_TotalD Total - Third year");
            builder.Property(e => e.PupilNumbersAndCapacityCellTotalETotalFourthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_TotalE Total - Fourth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellTotalFTotalFifthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_TotalF Total - Fifth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellTotalGTotalSixthYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_TotalG Total - Sixth year");
            builder.Property(e => e.PupilNumbersAndCapacityCellTotalHTotalSeventhYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Cell_TotalH Total - Seventh year");
            builder.Property(e => e.PupilNumbersAndCapacityManualOverwrite).HasColumnName("Pupil numbers and capacity.Manual overwrite?");
            builder.Property(e => e.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityTotal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Minimum first year recruitment for viability Total");
            builder.Property(e => e.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityY12Y14)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Minimum first year recruitment for viability Y12-Y14");
            builder.Property(e => e.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityY7Y11)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Minimum first year recruitment for viability Y7-Y11");
            builder.Property(e => e.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityYrY6)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Minimum first year recruitment for viability YR-Y6");
            builder.Property(e => e.PupilNumbersAndCapacityNoApplicationsAcceptedTotal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.No. applications accepted Total");
            builder.Property(e => e.PupilNumbersAndCapacityNoApplicationsAcceptedY12Y14)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.No. applications accepted Y12-Y14");
            builder.Property(e => e.PupilNumbersAndCapacityNoApplicationsAcceptedY7Y11)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.No. applications accepted Y7-Y11");
            builder.Property(e => e.PupilNumbersAndCapacityNoApplicationsAcceptedYrY6)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.No. applications accepted YR-Y6");
            builder.Property(e => e.PupilNumbersAndCapacityNoApplicationsReceivedTotal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.No. applications received Total");
            builder.Property(e => e.PupilNumbersAndCapacityNoApplicationsReceivedY12Y14)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.No. applications received Y12-Y14");
            builder.Property(e => e.PupilNumbersAndCapacityNoApplicationsReceivedY7Y11)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.No. applications received Y7-Y11");
            builder.Property(e => e.PupilNumbersAndCapacityNoApplicationsReceivedYrY6)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.No. applications received YR-Y6");
            builder.Property(e => e.PupilNumbersAndCapacityNurseryUnder5s)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Nursery (under 5s)");
            builder.Property(e => e.PupilNumbersAndCapacityReceivedApplicationsVsPanY12Y14)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% received applications vs PAN Y12-Y14");
            builder.Property(e => e.PupilNumbersAndCapacityReceivedApplicationsVsPanY7Y11)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% received applications vs PAN Y7-Y11");
            builder.Property(e => e.PupilNumbersAndCapacityReceivedApplicationsVsPanYrY6)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% received applications vs PAN YR-Y6");
            builder.Property(e => e.PupilNumbersAndCapacityReceivedApplicationsVsViabilityY12Y14)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% received applications vs viability Y12-Y14");
            builder.Property(e => e.PupilNumbersAndCapacityReceivedApplicationsVsViabilityY7Y11)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% received applications vs viability Y7-Y11");
            builder.Property(e => e.PupilNumbersAndCapacityReceivedApplicationsVsViabilityYrY6)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.% received applications vs viability YR-Y6");
            builder.Property(e => e.PupilNumbersAndCapacitySpecialistResourceProvisionAp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Specialist Resource Provision - AP");
            builder.Property(e => e.PupilNumbersAndCapacitySpecialistResourceProvisionSpecial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Specialist Resource Provision - Special");
            builder.Property(e => e.PupilNumbersAndCapacityTotalOfCapacityTotals)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total of capacity totals");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPanPost16)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total PAN: post-16");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPanPre16)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total PAN: pre-16");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPost16A)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total post-16 A");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPost16B)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total post-16 B");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPost16C)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total post-16 C");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPost16D)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total post-16 D");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPost16E)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total post-16 E");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPost16F)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total post-16 F");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPost16G)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total post-16 G");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPost16H)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total post-16 H");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPre16A)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total pre-16 A");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPre16B)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total pre-16 B");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPre16C)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total pre-16 C");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPre16D)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total pre-16 D");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPre16E)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total pre-16 E");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPre16F)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total pre-16 F");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPre16G)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total pre-16 G");
            builder.Property(e => e.PupilNumbersAndCapacityTotalPre16H)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Total pre-16 H");
            builder.Property(e => e.PupilNumbersAndCapacityY10Pan)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Y10 PAN");
            builder.Property(e => e.PupilNumbersAndCapacityY12Pan)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Y12 PAN");
            builder.Property(e => e.PupilNumbersAndCapacityY12Y14Post16Capacity)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Y12-Y14 (post-16) capacity");
            builder.Property(e => e.PupilNumbersAndCapacityY7Pan)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Y7 PAN");
            builder.Property(e => e.PupilNumbersAndCapacityY7Y11Capacity)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Y7-Y11 capacity");
            builder.Property(e => e.PupilNumbersAndCapacityYOtherPanPost16)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Y other PAN post-16");
            builder.Property(e => e.PupilNumbersAndCapacityYOtherPanPre16)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.Y other PAN pre-16");
            builder.Property(e => e.PupilNumbersAndCapacityYrPan)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.YR PAN");
            builder.Property(e => e.PupilNumbersAndCapacityYrY11Pre16Capacity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.YR-Y11 (pre-16) capacity");
            builder.Property(e => e.PupilNumbersAndCapacityYrY6Capacity)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pupil numbers and capacity.YR-Y6 capacity");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.PdgGrantLetterLinkSavedToWorkplaces)
                .HasColumnType("bit")
                .HasColumnName("PdgGrantLetterLinkSavedToWorkplaces");

            AuditConfiguration.Apply(builder);
        }
	}

}
