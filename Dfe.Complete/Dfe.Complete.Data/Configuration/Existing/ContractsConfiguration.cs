using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class ContractsConfiguration : IEntityTypeConfiguration< Contracts>
	{
		public void Configure(EntityTypeBuilder<Contracts> builder)
		{
            builder.HasKey(e => e.Rid);

            builder.ToTable("Contracts", "dbo", e => e.IsTemporal());

            builder.Property(e => e.Contract1stSectionalCompletionActual)
                .HasColumnType("date")
                .HasColumnName("Contract.1st sectional completion (actual)");
            builder.Property(e => e.Contract1stSectionalCompletionForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.1st sectional completion (forecast)");
            builder.Property(e => e.Contract2ndSectionalCompletionActual)
                .HasColumnType("date")
                .HasColumnName("Contract.2nd sectional completion (actual)");
            builder.Property(e => e.Contract2ndSectionalCompletionForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.2nd sectional completion (forecast)");
            builder.Property(e => e.Contract3rdSectionalCompletionActual)
                .HasColumnType("date")
                .HasColumnName("Contract.3rd sectional completion (actual)");
            builder.Property(e => e.Contract3rdSectionalCompletionForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.3rd sectional completion (forecast)");
            builder.Property(e => e.ContractAddressOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Address of site");
            builder.Property(e => e.ContractAllWorksCompleteInclStatutoryCertificationIssuedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.All works complete (incl statutory certification issued) (actual)");
            builder.Property(e => e.ContractAllWorksCompleteInclStatutoryCertificationIssuedForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.All works complete (incl statutory certification issued) (forecast)");
            builder.Property(e => e.ContractAwardOption)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Award Option");
            builder.Property(e => e.ContractBiddersDay)
                .HasColumnType("date")
                .HasColumnName("Contract.Bidders Day");
            builder.Property(e => e.ContractConstructionSiteOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Construction Site Open");
            builder.Property(e => e.ContractContractAwardValueExclVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contract Award value (excl VAT)");
            builder.Property(e => e.ContractContractBudgetValueExclVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contract budget value (excl VAT)");
            builder.Property(e => e.ContractContractCategory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contract Category");
            builder.Property(e => e.ContractContractId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contract ID");
            builder.Property(e => e.ContractContractNotes)
                .IsUnicode(false)
                .HasColumnName("Contract.Contract notes");
            builder.Property(e => e.ContractContractProcurementStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contract Procurement Status");
            builder.Property(e => e.ContractContractReference)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contract reference");
            builder.Property(e => e.ContractContractType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contract Type");
            builder.Property(e => e.ContractContractingParty)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contracting party");
            builder.Property(e => e.ContractContractor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contractor");
            builder.Property(e => e.ContractContractorAppointedSpmPcsaEwaOtherActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Contractor appointed (SPM / PCSA / EWA / Other) (actual)");
            builder.Property(e => e.ContractContractorAppointedSpmPcsaEwaOtherForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Contractor appointed (SPM / PCSA / EWA / Other) (forecast)");
            builder.Property(e => e.ContractContractorSProposalsApprovedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Contractor’s proposals approved (actual)");
            builder.Property(e => e.ContractContractorSProposalsApprovedForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Contractor’s proposals approved (forecast)");
            builder.Property(e => e.ContractContractorSProposalsSubmittedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Contractor’s proposals submitted (actual)");
            builder.Property(e => e.ContractContractorSProposalsSubmittedForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Contractor’s proposals submitted (forecast)");
            builder.Property(e => e.ContractContractorWorkingToBepEirsThroughoutDesignConstructionHandover)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Contractor working to BEP & EIRs throughout design, construction & handover?");
            builder.Property(e => e.ContractDateDevelopmentAgreementSigned)
                .HasColumnType("date")
                .HasColumnName("Contract.Date Development agreement signed");
            builder.Property(e => e.ContractDateOfClosedContractStatus)
                .HasColumnType("date")
                .HasColumnName("Contract.Date of Closed contract status");
            builder.Property(e => e.ContractDateOfSdbcApproval)
                .HasColumnType("date")
                .HasColumnName("Contract.Date of SDBC approval");
            builder.Property(e => e.ContractDateOfSdbcSubmission)
                .HasColumnType("date")
                .HasColumnName("Contract.Date of SDBC submission");
            builder.Property(e => e.ContractDeliveryParty)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Delivery party");
            builder.Property(e => e.ContractDeliveryPartyIfOther)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Delivery party - if other");
            builder.Property(e => e.ContractEarlyWorksCostsExclVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Early works costs (excl VAT)");
            builder.Property(e => e.ContractEndOfDefectsLiabilityCertificatesLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.End of defects liability certificates link");
            builder.Property(e => e.ContractEnterIntoMainContractActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Enter into main contract (actual)");
            builder.Property(e => e.ContractEnterIntoMainContractForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Enter into main contract (forecast)");
            builder.Property(e => e.ContractExternalTechnicalAdviserAppointedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.External Technical Adviser appointed (actual)");
            builder.Property(e => e.ContractFeasibilityReportApprovedByEsfaActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Feasibility report approved by ESFA (actual)");
            builder.Property(e => e.ContractFeasibilityReportLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Feasibility report link");
            builder.Property(e => e.ContractFeasibilityReportSubmittedToEsfaActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Feasibility report submitted to ESFA (actual)");
            builder.Property(e => e.ContractFeasibiltyReportStarted)
                .HasColumnType("date")
                .HasColumnName("Contract.Feasibilty report started");
            builder.Property(e => e.ContractFinalAccountsAgreedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Final accounts agreed (actual)");
            builder.Property(e => e.ContractFinalAccountsAgreedForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Final accounts agreed (forecast)");
            builder.Property(e => e.ContractFinalContractValueExclVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Final contract value (excl VAT)");
            builder.Property(e => e.ContractGifaForActualContractM2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.GIFA for actual contract (m2)");
            builder.Property(e => e.ContractHasTheBepBeenReceivedFromTheContractor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Has the BEP been received from the contractor?");
            builder.Property(e => e.ContractHaveTheAirsBeenIssued)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Have the AIRs been issued?");
            builder.Property(e => e.ContractHaveTheEirsBeenIssued)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Have the EIRs been issued?");
            builder.Property(e => e.ContractHseF10NotificationOfConstructionProjectFormSubmittedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.HSE F10 notification of construction project form submitted (actual)");
            builder.Property(e => e.ContractId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ContractID");
            builder.Property(e => e.ContractIsBimRequiredForTheProject)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Is BIM required for the project?");
            builder.Property(e => e.ContractIsThisThePrincipalConstructionContractForThePermanentSchoolBuilding)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Is this the principal construction contract for the permanent school building?");
            builder.Property(e => e.ContractLatestContractValueExclVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Latest contract value (excl VAT)");
            builder.Property(e => e.ContractLinkToApprovedBc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Link to Approved BC");
            builder.Property(e => e.ContractLinkToDevelopmentAgreement)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Link to Development agreement");
            builder.Property(e => e.ContractMakingGoodDefectsReinstatementWorksCompleteActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Making good defects / reinstatement works complete (actual)");
            builder.Property(e => e.ContractMakingGoodDefectsReinstatementWorksCompleteForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Making good defects / reinstatement works complete (forecast)");
            builder.Property(e => e.ContractModular)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Modular");
            builder.Property(e => e.ContractNameOfDeliveryParty)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Name of Delivery Party");
            builder.Property(e => e.ContractNameOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Name of site");
            builder.Property(e => e.ContractPlannedProgrammeSetWithTa)
                .HasColumnType("date")
                .HasColumnName("Contract.Planned programme set with TA");
            builder.Property(e => e.ContractPlanningApplicationId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Planning application ID");
            builder.Property(e => e.ContractPlanningApplicationSubmittedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Planning application submitted (actual)");
            builder.Property(e => e.ContractPlanningApplicationSubmittedForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Planning application submitted (forecast)");
            builder.Property(e => e.ContractPlanningDecisionGrantedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Planning decision granted (actual)");
            builder.Property(e => e.ContractPlanningDecisionGrantedForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Planning decision granted (forecast)");
            builder.Property(e => e.ContractPostcodeOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Postcode of site");
            builder.Property(e => e.ContractPracticalCompletionCertificateIssuedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Practical completion certificate issued (actual)");
            builder.Property(e => e.ContractPracticalCompletionCertificateIssuedForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Practical completion certificate issued (forecast)");
            builder.Property(e => e.ContractPracticalCompletionCertificateLink)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Contract.Practical completion certificate link");
            builder.Property(e => e.ContractPrincipalDesigner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Principal designer");
            builder.Property(e => e.ContractProcurementOption)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Procurement Option");
            builder.Property(e => e.ContractProcurementRoute)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Procurement route");
            builder.Property(e => e.ContractProcurementStartTenderIssuedActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Procurement start / Tender Issued (actual)");
            builder.Property(e => e.ContractProcurementStartTenderIssuedForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Procurement start / Tender Issued (forecast)");
            builder.Property(e => e.ContractProportionOfNewBuild)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Proportion of New Build");
            builder.Property(e => e.ContractRagRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.RAG rating");
            builder.Property(e => e.ContractReasonForClosedContractStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Reason for Closed contract status");
            builder.Property(e => e.ContractSectionalCompletionCertificatesLink)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Contract.Sectional completion certificates link");
            builder.Property(e => e.ContractSiteId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Site ID");
            builder.Property(e => e.ContractSiteVisit)
                .HasColumnType("date")
                .HasColumnName("Contract.Site Visit");
            builder.Property(e => e.ContractStartOnSiteActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Start on site (actual)");
            builder.Property(e => e.ContractStartOnSiteForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Start on site (forecast)");
            builder.Property(e => e.ContractTenderReportApprovedByEfaActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Tender report approved by EFA (actual)");
            builder.Property(e => e.ContractTenderReportApprovedByEfaForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Tender report approved by EFA (forecast)");
            builder.Property(e => e.ContractTenderReportLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Tender report link");
            builder.Property(e => e.ContractTenderReportSubmittedToEfaActual)
                .HasColumnType("date")
                .HasColumnName("Contract.Tender report submitted to EFA (actual)");
            builder.Property(e => e.ContractTenderReportSubmittedToEfaForecast)
                .HasColumnType("date")
                .HasColumnName("Contract.Tender report submitted to EFA (forecast)");
            builder.Property(e => e.ContractTypeOfContractorAppointment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Type of contractor appointment");
            builder.Property(e => e.ContractTypeOfContractorAppointmentIfOther)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Type of contractor appointment if other");
            builder.Property(e => e.ContractTypeOfWorks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contract.Type of works");
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
