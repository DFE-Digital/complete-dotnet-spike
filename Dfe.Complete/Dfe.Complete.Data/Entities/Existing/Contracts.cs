using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Contracts> Contracts { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Contracts
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string ContractIsThisThePrincipalConstructionContractForThePermanentSchoolBuilding { get; set; }

        public string ContractContractId { get; set; }

        public string ContractId { get; set; }

        public string ContractContractReference { get; set; }

        public string ContractContractType { get; set; }

        public string ContractContractCategory { get; set; }

        public string ContractSiteId { get; set; }

        public string ContractNameOfSite { get; set; }

        public string ContractAddressOfSite { get; set; }

        public string ContractPostcodeOfSite { get; set; }

        public string ContractContractProcurementStatus { get; set; }

        public DateTime? ContractDateOfClosedContractStatus { get; set; }

        public string ContractReasonForClosedContractStatus { get; set; }

        public string ContractDeliveryParty { get; set; }

        public string ContractNameOfDeliveryParty { get; set; }

        public DateTime? ContractDateOfSdbcSubmission { get; set; }

        public DateTime? ContractDateOfSdbcApproval { get; set; }

        public string ContractLinkToApprovedBc { get; set; }

        public DateTime? ContractDateDevelopmentAgreementSigned { get; set; }

        public string ContractLinkToDevelopmentAgreement { get; set; }

        public string ContractDeliveryPartyIfOther { get; set; }

        public string ContractContractingParty { get; set; }

        public string ContractGifaForActualContractM2 { get; set; }

        public string ContractTypeOfWorks { get; set; }

        public string ContractProportionOfNewBuild { get; set; }

        public string ContractProcurementRoute { get; set; }

        public string ContractProcurementOption { get; set; }

        public string ContractAwardOption { get; set; }

        public DateTime? ContractSiteVisit { get; set; }

        public DateTime? ContractBiddersDay { get; set; }

        public string ContractModular { get; set; }

        public string ContractIsBimRequiredForTheProject { get; set; }

        public string ContractHaveTheEirsBeenIssued { get; set; }

        public string ContractHaveTheAirsBeenIssued { get; set; }

        public string ContractHasTheBepBeenReceivedFromTheContractor { get; set; }

        public string ContractContractorWorkingToBepEirsThroughoutDesignConstructionHandover { get; set; }

        public string ContractContractor { get; set; }

        public string ContractTypeOfContractorAppointment { get; set; }

        public string ContractTypeOfContractorAppointmentIfOther { get; set; }

        public string ContractEarlyWorksCostsExclVat { get; set; }

        public string ContractContractBudgetValueExclVat { get; set; }

        public string ContractContractAwardValueExclVat { get; set; }

        public string ContractLatestContractValueExclVat { get; set; }

        public string ContractFinalContractValueExclVat { get; set; }

        public string ContractPrincipalDesigner { get; set; }

        public string ContractRagRating { get; set; }

        public DateTime? ContractPlannedProgrammeSetWithTa { get; set; }

        public string ContractContractNotes { get; set; }

        public DateTime? ContractExternalTechnicalAdviserAppointedActual { get; set; }

        public DateTime? ContractFeasibiltyReportStarted { get; set; }

        public DateTime? ContractFeasibilityReportSubmittedToEsfaActual { get; set; }

        public DateTime? ContractFeasibilityReportApprovedByEsfaActual { get; set; }

        public string ContractFeasibilityReportLink { get; set; }

        public DateTime? ContractProcurementStartTenderIssuedForecast { get; set; }

        public DateTime? ContractProcurementStartTenderIssuedActual { get; set; }

        public DateTime? ContractTenderReportSubmittedToEfaForecast { get; set; }

        public DateTime? ContractTenderReportSubmittedToEfaActual { get; set; }

        public DateTime? ContractTenderReportApprovedByEfaForecast { get; set; }

        public DateTime? ContractTenderReportApprovedByEfaActual { get; set; }

        public string ContractTenderReportLink { get; set; }

        public DateTime? ContractContractorAppointedSpmPcsaEwaOtherForecast { get; set; }

        public DateTime? ContractContractorAppointedSpmPcsaEwaOtherActual { get; set; }

        public string ContractPlanningApplicationId { get; set; }

        public DateTime? ContractPlanningApplicationSubmittedForecast { get; set; }

        public DateTime? ContractPlanningApplicationSubmittedActual { get; set; }

        public DateTime? ContractPlanningDecisionGrantedForecast { get; set; }

        public DateTime? ContractPlanningDecisionGrantedActual { get; set; }

        public DateTime? ContractContractorSProposalsSubmittedForecast { get; set; }

        public DateTime? ContractContractorSProposalsSubmittedActual { get; set; }

        public DateTime? ContractContractorSProposalsApprovedForecast { get; set; }

        public DateTime? ContractContractorSProposalsApprovedActual { get; set; }

        public DateTime? ContractEnterIntoMainContractForecast { get; set; }

        public DateTime? ContractEnterIntoMainContractActual { get; set; }

        public DateTime? ContractHseF10NotificationOfConstructionProjectFormSubmittedActual { get; set; }

        public DateTime? ContractStartOnSiteForecast { get; set; }

        public DateTime? ContractStartOnSiteActual { get; set; }

        public string ContractConstructionSiteOpen { get; set; }

        public DateTime? Contract1stSectionalCompletionForecast { get; set; }

        public DateTime? Contract1stSectionalCompletionActual { get; set; }

        public DateTime? Contract2ndSectionalCompletionForecast { get; set; }

        public DateTime? Contract2ndSectionalCompletionActual { get; set; }

        public DateTime? Contract3rdSectionalCompletionForecast { get; set; }

        public DateTime? Contract3rdSectionalCompletionActual { get; set; }

        public string ContractSectionalCompletionCertificatesLink { get; set; }

        public DateTime? ContractAllWorksCompleteInclStatutoryCertificationIssuedForecast { get; set; }

        public DateTime? ContractAllWorksCompleteInclStatutoryCertificationIssuedActual { get; set; }

        public DateTime? ContractPracticalCompletionCertificateIssuedForecast { get; set; }

        public DateTime? ContractPracticalCompletionCertificateIssuedActual { get; set; }

        public string ContractPracticalCompletionCertificateLink { get; set; }

        public DateTime? ContractFinalAccountsAgreedForecast { get; set; }

        public DateTime? ContractFinalAccountsAgreedActual { get; set; }

        public DateTime? ContractMakingGoodDefectsReinstatementWorksCompleteForecast { get; set; }

        public DateTime? ContractMakingGoodDefectsReinstatementWorksCompleteActual { get; set; }

        public string ContractEndOfDefectsLiabilityCertificatesLink { get; set; }
    }
}