using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Kpi> Kpi { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Kpi : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string ProjectStatusCurrentFreeSchoolName { get; set; }

        public string ProjectStatusHasTheFreeSchoolChangedItsName { get; set; }

        public string ProjectStatusPreviousFreeSchoolName { get; set; }

        public string ProjectStatusProjectStatus { get; set; }

        public string ProjectStatusFreeSchoolsApplicationNumber { get; set; }

        public string ProjectStatusProjectId { get; set; }

        public string ProjectStatusFreeSchoolApplicationWave { get; set; }

        public DateTime? ProjectStatusDateOfApplicationIfOutsideWave { get; set; }

        public string ProjectStatusRealisticYearOfOpening { get; set; }

        public DateTime? ProjectStatusDateOfEntryIntoPreOpening { get; set; }

        public string ProjectStatusTrustsPreferredYearOfOpening { get; set; }

        public DateTime? ProjectStatusProvisionalOpeningDateAgreedWithTrust { get; set; }

        public DateTime? ProjectStatusActualOpeningDate { get; set; }

        public DateTime? ProjectStatusPlannedMoveDateToPermanentSite { get; set; }

        public string ProjectStatusHasTheProjectBeenDeferred { get; set; }

        public DateTime? ProjectStatusDateOfFirstDeferral { get; set; }

        public string ProjectStatusPrimaryReasonForFirstDeferral { get; set; }

        public string ProjectStatusReasonForSiteDeferral { get; set; }

        public string ProjectStatusCommentaryForFirstDeferral { get; set; }

        public DateTime? ProjectStatusNewOpeningDateFollowingFirstDeferral { get; set; }

        public string ProjectStatusHasProjectBeenDeferredForASecondTime { get; set; }

        public DateTime? ProjectStatusDateOfSecondDeferral { get; set; }

        public string ProjectStatusPrimaryReasonForSecondDeferral { get; set; }

        public string ProjectStatusKp05ReasonForSiteDeferral { get; set; }

        public string ProjectStatusCommentaryForSecondDeferral { get; set; }

        public DateTime? ProjectStatusNewOpeningDateFollowingSecondDeferral { get; set; }

        public string ProjectStatusHasProjectBeenDeferredForAThirdTime { get; set; }

        public DateTime? ProjectStatusDateOfThirdDeferral { get; set; }

        public string ProjectStatusPrimaryReasonForThirdDeferral { get; set; }

        public string ProjectStatusKp06ReasonForSiteDeferral { get; set; }

        public string ProjectStatusCommentaryForThirdDeferral { get; set; }

        public DateTime? ProjectStatusNewOpeningDateFollowingThirdDeferral { get; set; }

        public string ProjectStatusHasProjectBeenWithdrawn { get; set; }

        public DateTime? ProjectStatusDateWithdrawn { get; set; }

        public string ProjectStatusPrimaryReasonForWithdrawal { get; set; }

        public string ProjectStatusReasonForSiteWithdrawal { get; set; }

        public string ProjectStatusCommentaryForWithdrawal { get; set; }

        public string ProjectStatusHasProjectBeenCancelled { get; set; }

        public DateTime? ProjectStatusDateCancelled { get; set; }

        public string ProjectStatusPrimaryReasonForCancellation { get; set; }

        public string ProjectStatusReasonForSiteCancellation { get; set; }

        public string ProjectStatusCommentaryForCancellation { get; set; }

        public DateTime? ProjectStatusDateClosed { get; set; }

        public DateTime? ProjectStatusActualDateOfOpeningInPermanentAccommodation { get; set; }

        public DateTime? ProjectStatusActualDateOfOpeningInTemporaryAccommodation { get; set; }

        public string ProjectStatusFreeSchoolPenPortrait { get; set; }

        public string ProjectStatusUrnWhenGivenOne { get; set; }

        public string ProjectStatusRebrokeredUrn { get; set; }

        public string SchoolDetailsLaestabWhenGivenOne { get; set; }

        public string SchoolDetailsLocalAuthority { get; set; }

        public string LocalAuthority { get; set; }

        public string SchoolDetailsLocalAuthorityControl { get; set; }

        public string SchoolDetailsDistrict { get; set; }

        public string SchoolDetailsAeaCatagory { get; set; }

        public DateTime? SchoolDetailsStartOfTermDate { get; set; }

        public string SchoolDetailsDeprivationDecline { get; set; }

        public string SchoolDetailsNeetInLa { get; set; }

        public string SchoolDetailsRscRegion { get; set; }

        public string SchoolDetailsGeographicalRegion { get; set; }

        public string SchoolDetailsEfaTerritory { get; set; }

        public string SchoolDetailsConstituency { get; set; }

        public string SchoolDetailsConstituencyMp { get; set; }

        public string SchoolDetailsPoliticalParty { get; set; }

        public string SchoolDetailsNumberOfFormsOfEntry { get; set; }

        public string SchoolDetailsSchoolTypeMainstreamApEtc { get; set; }

        public string SchoolDetailsSchoolPhasePrimarySecondary { get; set; }

        public string SchoolDetailsAgeRange { get; set; }

        public string SchoolDetailsGender { get; set; }

        public string SchoolDetailsResidentialOrBoardingProvision { get; set; }

        public string SchoolDetailsDetailsOfResidentialBoardingProvision { get; set; }

        public string SchoolDetailsNursery { get; set; }

        public string SchoolDetailsSixthForm { get; set; }

        public string SchoolDetailsSixthFormType { get; set; }

        public string SchoolDetailsIndependentConverter { get; set; }

        public string SchoolDetailsSpecialistResourceProvision { get; set; }

        public string SchoolDetailsSizeOfGoverningBody { get; set; }

        public string SchoolDetailsFaithStatus { get; set; }

        public string SchoolDetailsFaithType { get; set; }

        public string SchoolDetailsPleaseSpecifyOtherFaithType { get; set; }

        public string SchoolDetailsSpecialism { get; set; }

        public string SchoolDetailsDistinguishingFeatures { get; set; }

        public string SchoolDetailsEmployerSponsorsUtcsSsOnly { get; set; }

        public string SchoolDetailsUniversitySponsor { get; set; }

        public string SchoolDetailsEmployerPartners { get; set; }

        public string SchoolDetailsOtherPartners { get; set; }

        public string SchoolDetailsTypeOfProposerGroup { get; set; }

        public string SchoolDetailsPleaseSpecifyOtherTypeOfProposerGroup { get; set; }

        public string SchoolDetailsLeadSponsorId { get; set; }

        public string SchoolDetailsLeadSponsorName { get; set; }

        public string SchoolDetailsSponsorType { get; set; }

        public string SchoolDetailsTrustId { get; set; }

        public string SchoolDetailsTrustName { get; set; }

        public string SchoolDetailsTrustType { get; set; }

        public string BasicNeedSchoolInPlanningAreaOfBasicNeedAssessment { get; set; }

        public string BasicNeedKp02PlanningAreaCode { get; set; }

        public string BasicNeedSchoolInPlanningAreaOfBasicNeedSecondaryAssessment { get; set; }

        public string BasicNeedSchoolInLocalAreaWithAShortfallOfPlacesSecondaryAssessment { get; set; }

        public string BasicNeedYearOfProjectedNeedSecondaryAssessment { get; set; }

        public string BasicNeedPlanningAreaCodeSecondaryAssessment { get; set; }

        public string BasicNeedAdditionalEvidenceOfNeedSecondaryAssessment { get; set; }

        public string BasicNeedSchoolInPlanningAreaOfBasicNeed { get; set; }

        public string BasicNeedSchoolInLocalAreaWithAShortfallOfPlacesInLocalArea { get; set; }

        public string BasicNeedYearOfScapSurvey { get; set; }

        public string BasicNeedShortfallOfPlacesInLocalAreaAllYearGroupsInScapYear4 { get; set; }

        public string BasicNeedPercentageShortfallInLocalAreaAllYearGroupsInScapYear4 { get; set; }

        public string BasicNeedShortfallOfPlacesInLocalAreaYearOfOpeningAllYearGroups { get; set; }

        public string BasicNeedPercentageShortfallInLocalAreaYearOfOpeningAllYearGroups { get; set; }

        public string BasicNeedKp04PlanningAreaCode { get; set; }

        public string BasicNeedAdditionalEvidenceOfNeed { get; set; }

        public string BasicNeedSchoolInPlanningAreaOfBasicNeedSecondary { get; set; }

        public string BasicNeedSchoolInLocalAreaWithAShortfallOfPlacesInLocalAreaSecondary { get; set; }

        public string BasicNeedYearOfScapSurveySecondary { get; set; }

        public string BasicNeedShortfallOfPlacesInLocalAreaAllYearGroupsInScapYear4Secondary { get; set; }

        public string BasicNeedPercentageShortfallInLocalAreaAllYearGroupsInScapYear4Secondary { get; set; }

        public string BasicNeedShortfallOfPlacesInLocalAreaYearOfOpeningAllYearGroupsSecondary { get; set; }

        public string BasicNeedPercentageShortfallInLocalAreaYearOfOpeningAllYearGroupsSecondary { get; set; }

        public string BasicNeedPlanningAreaCodeSecondary { get; set; }

        public string BasicNeedAdditionalEvidenceOfNeedSecondary { get; set; }

        public string KeyContactsSchoolAddress { get; set; }

        public string KeyContactsPostcode { get; set; }

        public string KeyContactsPostCodeForMapping { get; set; }

        public string KeyContactsLeadProposerName { get; set; }

        public string KeyContactsLeadProposerPhone { get; set; }

        public string KeyContactsLeadProposerEmail { get; set; }

        public string KeyContactsAddressOfLeadProposer { get; set; }

        public string KeyContactsLocalAuthorityContactPresumptionProject { get; set; }

        public string KeyContactsPrincipalDesignateName { get; set; }

        public string KeyContactsPrincipalDesignatePhone { get; set; }

        public string KeyContactsPrincipalDesignateEmail { get; set; }

        public string KeyContactsSeniorExecutiveLeaderName { get; set; }

        public string KeyContactsSeniorExecutiveLeaderPhone { get; set; }

        public string KeyContactsSeniorExecutiveLeaderEmail { get; set; }

        public string KeyContactsChairOfGovernorsName { get; set; }

        public string KeyContactsChairOfGovernorsPhone { get; set; }

        public string KeyContactsChairOfGovernorsEmail { get; set; }

        public string KeyContactsChairOfGovernorsMat { get; set; }

        public string KeyContactsChairOfGovernorsMatPhone { get; set; }

        public string KeyContactsChairOfGovernorsMatEmail { get; set; }

        public string KeyContactsTrustSIctLeadContact { get; set; }

        public string KeyContactsTrustSIctLeadContactPhone { get; set; }

        public string KeyContactsTrustSIctLeadContactEmail { get; set; }

        public string KeyContactsFsgAssessmentLead { get; set; }

        public string KeyContactsAssessmentTeamLeader { get; set; }

        public string KeyContactsInterviewChair { get; set; }

        public string KeyContactsFsgLeadContact { get; set; }

        public string KeyContactsFsgTeamLeader { get; set; }

        public string KeyContactsFsgGrade6 { get; set; }

        public string KeyContactsEsfaCapitalProjectManager { get; set; }

        public string KeyContactsEsfaCapitalProjectManagerFirm { get; set; }

        public string KeyContactsEsfaCapitalProjectDirector { get; set; }

        public string KeyContactsEsfaCapitalHeadOfRegion { get; set; }

        public string KeyContactsEsfaAcademiesSeniorAdviser { get; set; }

        public string KeyContactsEsfaLinkOfficer { get; set; }

        public string KeyContactsEducationAdviserAssessment { get; set; }

        public string KeyContactsEducationAdviserPreOpening { get; set; }

        public string KeyContactsNamedContactOnceSchoolIsOpen { get; set; }

        public string KeyContactsEaOnceSchoolIsOpen { get; set; }

        public string KeyContactsIctAdviser { get; set; }

        public string KeyContactsEsfaPropertyLead { get; set; }

        public string KeyContactsLocatEdAcquisitionManager { get; set; }

        public string KeyContactsEsfaRegionalPropertyLead { get; set; }

        public string KeyContactsLegalManager { get; set; }

        public string KeyContactsCommercialManager { get; set; }

        public string KeyContactsPropertyFirmDealing { get; set; }

        public string KeyContactsPropertyAdviserAllocated { get; set; }

        public string KeyContactsAllocatedLawFirm { get; set; }

        public string KeyContactsFrameworkPlanningConsultant { get; set; }

        public string KeyContactsFrameworkPlanningFirm { get; set; }

        public string KeyContactsFrameworkPlanningFirmOther { get; set; }

        public string KeyContactsPlanningAdviser { get; set; }

        public string KeyContactsPropertyDocumentRepositoryLink { get; set; }

        public string KeyContactsEsfaTechnicalAdviser { get; set; }

        public string KeyContactsStrategicDesignAdviser { get; set; }

        public string KeyContactsTechnicalAdvisoryFirm { get; set; }

        public string KeyContactsLegalFirm { get; set; }

        public string CommunicationsMediaPenPortrait { get; set; }

        public string CommunicationsCurrentLinesToTake { get; set; }

        public string CommunicationsArchivedLinesToTake { get; set; }

        public string ContingencyPlanningRddSiteContingencyRag { get; set; }

        public string ContingencyPlanningRddRationale { get; set; }

        public string ContingencyPlanningIfOtherWhyForRAndAExplainAnythingBeingExploredOrNextSteps { get; set; }

        public string ContingencyPlanningEssentialThatItIsDeliveredForSeptemberOrCurrentScheduledDateInTheRealisticYearOfOpening { get; set; }

        public string ContingencyPlanningIfYesWhy { get; set; }

        public string ContingencyPlanningIfOtherWhy { get; set; }

        public string ContingencyPlanningBackUpField { get; set; }

        public string ContingencyPlanningFscDeliverabilityAssessment { get; set; }

        public string ContingencyPlanningFscDeliverabilityComment { get; set; }

        public string ContingencyPlanningSiteShutdown { get; set; }

        public string ContingencyPlanningCanTempsBeExtended { get; set; }

        public string ContingencyPlanningHowLongCanTempsBeExtended { get; set; }

        public string ContingencyPlanningCanCurrentCohortRemainInSchool { get; set; }

        public string ContingencyPlanningCanSchoolTakeOnAnotherCohort { get; set; }

        public string ContingencyPlanningHowManyStudentsWillNeedAlternativeArrangements { get; set; }

        public string ContingencyPlanningProjectedLengthOfDelayToProject { get; set; }

        public string ContingencyPlanningExtraInformation { get; set; }

        public string LeadSponsorId { get; set; }

        public string LeadSponsorName { get; set; }

        public string TrustId { get; set; }

        public string TrustName { get; set; }

        public string TrustType { get; set; }

        public string FsType { get; set; }

        public string FsType1 { get; set; }

        public string SponsorUnitProjects { get; set; }

        public string MatUnitProjects { get; set; }

        public DateTime? RatProvisionalOpeningDateAgreedWithTrust { get; set; }

        public string AprilIndicator { get; set; }

        public string Wave { get; set; }

        public string RyooWd { get; set; }

        public string UpperStatus { get; set; }
    }
}