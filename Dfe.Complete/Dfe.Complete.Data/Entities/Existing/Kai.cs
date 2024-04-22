using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Kai> Kai { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Kai : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string ApplicationDetailsLinkToPreRegistration { get; set; }

        public string ApplicationDetailsHowDoesTheProposerDescribeTheirGroup { get; set; }

        public string ApplicationDetailsIsTheProposalADirectResultOfARequestFromGroups { get; set; }

        public string ApplicationDetailsHasTheGroupAppliedBeforeToOpenThisSchoolWhetherUnderTheCurrentNameOrAnotherName { get; set; }

        public string ApplicationDetailsIfYesAndTheNameOfTheSchoolWasDifferentStateWhatTheOriginalNameWas { get; set; }

        public string ApplicationDetailsIfYesWhenDidTheGroupLastApply { get; set; }

        public string ApplicationDetailsHasTheProposerGroupEstablishedATrustInAccordanceWithTheDfEModelArticlesOfAssociation { get; set; }

        public string ApplicationDetailsCompanyName { get; set; }

        public string ApplicationDetailsCompanyAddress { get; set; }

        public string ApplicationDetailsCompanyRegistrationNumber { get; set; }

        public DateTime? ApplicationDetailsDateWhenCompanyWasIncorporated { get; set; }

        public string ApplicationDetailsNumberOfCompanyMembers { get; set; }

        public string ApplicationDetailsNumberOfTrustees { get; set; }

        public string ApplicationDetailsProposedChairOfTrustees { get; set; }

        public string ApplicationDetailsIsAnyoneConnectedWithThisApplicationRelatedInAnyWay { get; set; }

        public string ApplicationDetailsIfTheTrustRunsAcademiesFreeSchoolsHasAnythingChangedInTheTrustWithinTheLastMonth { get; set; }

        public string ApplicationDetailsNamesAndUniqueReferenceNumberSForEachOfTheTrustSOpenSchools { get; set; }

        public string ApplicationDetailsForIndependentSchoolsNameRatingAndUniqueReferenceNumber { get; set; }

        public string ApplicationDetailsForIndependentSchoolsLinkToTheMostRecentInspectionReport { get; set; }

        public string ApplicationDetailsHowManyApplicationsIsTheProposerGroupSeekingToOpenInThisApplicationRound { get; set; }

        public string ApplicationDetailsDoesTheGroupRunASchoolOfTheSamePhaseAndType { get; set; }

        public string ApplicationDetailsDoesTheGroupRunASchoolInTheLocalArea { get; set; }

        public string ApplicationDetailsAreThereAnyConnectionsWithOtherOrganisationsWithinTheUkOrOverseas { get; set; }

        public string ApplicationDetailsDetailsOfConnectionsWithOrganisationsWithinTheUkOrOverseas { get; set; }

        public string ApplicationDetailsAreThereAnyConnectionsWithReligiousOrganisationsOrInstitutions { get; set; }

        public string ApplicationDetailsDetailsOfAnyConnectionsWithReligiousOrganisationsOrInstitutions { get; set; }

        public string ApplicationDetailsAreAnyMembersOfTheGroupAlsoInvolvedInOtherApplicationsToOpenFreeSchoolsInThisRound { get; set; }

        public string ApplicationDetailsDidTheProposerGroupSeekHelpAndSupportFromTheNewSchoolsNetwork { get; set; }

        public string ApplicationDetailsDidTheProposerGroupHaveHelpAndSupportFromAnotherCompanyOrOrganisation { get; set; }

        public string ApplicationDetailsIfYesStateTheNamesSOfTheOrganisationsSAndDescribeTheirRole { get; set; }

        public string ApplicationDetailsInWhichLocalAuthorityDistrictIsYourPreferredLocation { get; set; }

        public string ApplicationDetailsIfANurseryIsProposedStateNurseryPupilCapacityAndAgeRange { get; set; }

        public string ApplicationDetailsIfANurseryIsProposedPleaseStatePupilCapacity { get; set; }

        public string ApplicationDetailsIfANurseryIsProposedPleaseStateTheAgeRange { get; set; }

        public string ApplicationDetailsIfASixthFormIsProposedPleaseStateTheSixthFormPupilCapacity { get; set; }

        public string ApplicationDetailsMaximumCapacityOfTheFreeSchoolIncluding1619SixthFormButNotIncludingNursery { get; set; }

        public string ApplicationDetailsStateYearTheSchoolWillHaveTheOpeningAndPanNumber { get; set; }

        public string ApplicationDetailsWillTheSchoolHaveADistinctivePedagogyOrEducationalPhilosophyForExampleSteinerOrMontessori { get; set; }

        public string ApplicationDetailsIsTheProposerGroupPlanningToContractTheManagementOfTheSchoolToAnotherOrganisation { get; set; }

        public string ApplicationDetailsHasThePrincipalDesignateBeenIdentified { get; set; }

        public string ApplicationDetailsTimeDedicatedToFaithStudiesHoursPerWeek { get; set; }

        public string ApplicationDetailsTimeDedicatedToMinorityLanguageStudyHoursPerWeek { get; set; }

        public string ApplicationDetailsWillTheSchoolOperateANonStandardSchoolDay { get; set; }

        public string ApplicationDetailsWillTheSchoolOperateANonStandardSchoolYear { get; set; }

        public string ApplicationDetailsWillTheSchoolAdoptTheNationalCurriculum { get; set; }

        public string ApplicationDetailsWillTheSchoolAdoptNonStandardTermsAndConditionsForTeachers { get; set; }

        public string ApplicationDetailsWillTheSchoolEmployTeachersWithoutQualifiedTeacherStatusQts { get; set; }

        public string ApplicationDetailsAnyOtherFreedomsTheSchoolIntendsToUse { get; set; }

        public DateTime? ApplicationDetailsDateSpecificationIssuedByLa { get; set; }

        public string ApplicationDetailsLinkToSpecification { get; set; }

        public DateTime? ApplicationDetailsLaClosingDateForReceiptOfProposals { get; set; }

        public DateTime? ApplicationDetailsDateProposalsExpected { get; set; }

        public DateTime? ApplicationDetailsDateLaDecisionExpected { get; set; }

        public string ApplicationDetailsProposalsReceived { get; set; }

        public string AssessmentDetailsInterviewPanel { get; set; }

        public string AssessmentDetailsInterviewAttendees { get; set; }

        public string AssessmentDetailsPostPaperRecommendationToTheMinister { get; set; }

        public string AssessmentDetailsRscPaperBasedRecommendation { get; set; }

        public string AssessmentDetailsMinisterialPostPaperDecision { get; set; }

        public string AssessmentDetailsPostInterviewRecommendationToTheMinister { get; set; }

        public string AssessmentDetailsRscPostInterviewRecommendation { get; set; }

        public string AssessmentDetailsMinisterialPostInterviewDecision { get; set; }

        public string AssessmentDetailsEqualitiesImpactAssessment { get; set; }

        public DateTime? AssessmentDetailsDateOfLaFsPresumptionAssessment { get; set; }

        public string AssessmentDetailsDfERepresentationOnFsPresumptionPanel { get; set; }

        public string AssessmentDetailsNameOfDfEIndividualSOnFsPresumptionAssessmentPanel { get; set; }

        public DateTime? AssessmentDetailsDateOfRscHtbPresumptionDecisionMeeting { get; set; }

        public string AssessmentDetailsWasSuccessfulFsPresumptionSponsorRecommendedByTheLa { get; set; }

        public string AssessmentCriteriaFinalScore { get; set; }

        public string AssessmentCriteriaFinalRecommendation { get; set; }

        public string AssessmentCriteriaAreYouRecommendingApprovalOfThe1619Element { get; set; }

        public string AssessmentCriteriaRecommendationCommentary { get; set; }

        public string AssessmentCriteriaNurseryRecommendation { get; set; }

        public string AssessmentCriteriaNurseryRecommendationCommentary { get; set; }

        public string AssessmentCriteriaConditions { get; set; }

        public string SectionBNeedFinalTotalPercentageScoreForSectionB { get; set; }

        public string SectionBNeedNeedApplicationAssessmentScore { get; set; }

        public string SectionBNeedNeedSummaryComments { get; set; }

        public string SectionBNeedPostcode { get; set; }

        public string SectionBNeedB11SiftAssessmentScore { get; set; }

        public string SectionBNeedB11IndicatorsCore { get; set; }

        public string SectionBNeedB11IndicatorsContributory { get; set; }

        public string SectionBNeedB11SiftAssessmentComments { get; set; }

        public string SectionBNeedB11ApplicationAssessmentScore { get; set; }

        public string SectionBNeedB11IsTheLocalAuthoritySupportiveOfTheSchool { get; set; }

        public string SectionBNeedB11CharacteristicsOld { get; set; }

        public string SectionBNeedB11CharacteristicsWave14 { get; set; }

        public string SectionBNeedB11ApplicationAssessmentComments { get; set; }

        public string SectionBNeedB11ScoreAfterInterview { get; set; }

        public string SectionBNeedB11InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionBNeedB11FinalScore { get; set; }

        public string SectionBNeedB12SiftAssessmentScore { get; set; }

        public string SectionBNeedB12SiftAssessmentComments { get; set; }

        public string SectionBNeedB12ApplicationAssessmentScore { get; set; }

        public string SectionBNeedB12ApplicationAssessmentComments { get; set; }

        public string SectionBNeedB12ScoreAfterInterview { get; set; }

        public string SectionBNeedB12InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionBNeedB12FinalScore { get; set; }

        public string SectionBNeedB11619SiftAssessmentScore { get; set; }

        public string SectionBNeedB11619Indicators { get; set; }

        public string SectionBNeedB11619SiftAssessmentComments { get; set; }

        public string SectionBNeedB11619ApplicationAssessmentScore { get; set; }

        public string SectionBNeedB11619IsTheLocalAuthoritySupportiveOfTheSchool { get; set; }

        public string SectionBNeedB11619CharacteristicsOld { get; set; }

        public string SectionBNeedB11619CharacteristicsWave14 { get; set; }

        public string SectionBNeedB11619ApplicationAssessmentComments { get; set; }

        public string SectionBNeedB11619ScoreAfterInterview { get; set; }

        public string SectionBNeedB11619InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionBNeedB11619FinalScore { get; set; }

        public string SectionBNeedB2SiftAssessmentScore { get; set; }

        public string SectionBNeedB2IndicatorsCore { get; set; }

        public string SectionBNeedB2IndicatorsContributory { get; set; }

        public string SectionBNeedB2SiftAssessmentComments { get; set; }

        public string SectionBNeedB2ApplicationAssessmentScore { get; set; }

        public string SectionBNeedB2CharacteristicsOld { get; set; }

        public string SectionBNeedB2CharacteristicsWave14 { get; set; }

        public string SectionBNeedB2ApplicationAssessmentComments { get; set; }

        public string SectionBNeedB2ScoreAfterInterview { get; set; }

        public string SectionBNeedB2InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionBNeedB2FinalScore { get; set; }

        public string SectionBNeedB21619SiftAssessmentScore { get; set; }

        public string SectionBNeedB21619IndicatorsCore { get; set; }

        public string SectionBNeedB21619IndicatorsContributory { get; set; }

        public string SectionBNeedB21619SiftAssessmentComments { get; set; }

        public string SectionBNeedB21619ApplicationAssessmentScore { get; set; }

        public string SectionBNeedB21619CharacteristicsOld { get; set; }

        public string SectionBNeedB21619CharacteristicsWave14 { get; set; }

        public string SectionBNeedB21619ApplicationAssessmentComments { get; set; }

        public string SectionBNeedB21619ScoreAfterInterview { get; set; }

        public string SectionBNeedB21619InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionBNeedB21619FinalScore { get; set; }

        public string SectionBNeedWillWeContinueToAssess1619 { get; set; }

        public string SectionBNeedNeedCommentaryAndInterviewPrompts { get; set; }

        public string SectionBNeedBNEngagementWithTheLocalAuthority { get; set; }

        public string SectionBNeedBNNurseryNeedSummaryComments { get; set; }

        public string SectionBNeedBNNurseryNeedInterviewPrompts { get; set; }

        public string SectionBNeedBNAfterInterviewNurseryNeedSummaryComments { get; set; }

        public string SectionCVisionFinalTotalPercentageScoreForSectionC { get; set; }

        public string SectionCVisionVisionApplicationAssessmentScore { get; set; }

        public string SectionCVisionVisionSummaryComments { get; set; }

        public string SectionCVisionC1ApplicationAssessmentScore { get; set; }

        public string SectionCVisionC1CharacteristicsOld { get; set; }

        public string SectionCVisionC1CharacteristicsWave14 { get; set; }

        public string SectionCVisionC1ApplicationAssessmentComments { get; set; }

        public string SectionCVisionC1ScoreAfterInterview { get; set; }

        public string SectionCVisionC1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionCVisionC1FinalScore { get; set; }

        public string SectionCVisionVisionInterviewPrompts { get; set; }

        public string SectionCVisionCNAssessment { get; set; }

        public string SectionCVisionCNAssessmentSummaryComments { get; set; }

        public string SectionCVisionCNNurseryVisionInterviewPrompts { get; set; }

        public string SectionCVisionCNAssessmentAfterInterview { get; set; }

        public string SectionCVisionCNAfterInterviewSummaryComments { get; set; }

        public string SectionDEngagementFinalTotalPercentageScoreForSectionD { get; set; }

        public string SectionDEngagementEngagementWithParentsAndTheLocalCommunityApplicationAssessmentScore { get; set; }

        public string SectionDEngagementEngagementWithParentsAndTheLocalCommunitySummaryComments { get; set; }

        public string SectionDEngagementD1ApplicationAssessmentScore { get; set; }

        public string SectionDEngagementCharacteristicsOld { get; set; }

        public string SectionDEngagementCharacteristicsWave14 { get; set; }

        public string SectionDEngagementD1ApplicationAssessmentComments { get; set; }

        public string SectionDEngagementD1ScoreAfterInterview { get; set; }

        public string SectionDEngagementD1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionDEngagementD1FinalScore { get; set; }

        public string SectionDEngagementEngagementWithParentsAndTheLocalCommunityInterviewPrompts { get; set; }

        public string SectionEEducationPlanFinalTotalPercentageScoreForSectionE { get; set; }

        public string SectionEEducationPlanEducationPlanApplicationAssessmentScore { get; set; }

        public string SectionEEducationPlanEducationPlanSummaryComments { get; set; }

        public string SectionEEducationPlanEducationAdviserAssessment { get; set; }

        public string SectionEEducationPlanE1ApplicationAssessmentScore { get; set; }

        public string SectionEEducationPlanE1CharacteristicsOld { get; set; }

        public string SectionEEducationPlanE1CharacteristicsWave14 { get; set; }

        public string SectionEEducationPlanE1ApplicationAssessmentComments { get; set; }

        public string SectionEEducationPlanE1ScoreAfterInterview { get; set; }

        public string SectionEEducationPlanE1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionEEducationPlanE1FinalScore { get; set; }

        public string SectionEEducationPlanE2ApplicationAssessmentScore { get; set; }

        public string SectionEEducationPlanE2CharacteristicsOld { get; set; }

        public string SectionEEducationPlanE2CharacteristicsWave14 { get; set; }

        public string SectionEEducationPlanE2ApplicationAssessmentComments { get; set; }

        public string SectionEEducationPlanE2ScoreAfterInterview { get; set; }

        public string SectionEEducationPlanE2InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionEEducationPlanE2FinalScore { get; set; }

        public string SectionEEducationPlanE3ApplicationAssessmentScore { get; set; }

        public string SectionEEducationPlanE3CharacteristicsOld { get; set; }

        public string SectionEEducationPlanE3CharacteristicsWave14 { get; set; }

        public string SectionEEducationPlanE3ApplicationAssessmentComments { get; set; }

        public string SectionEEducationPlanE3ScoreAfterInterview { get; set; }

        public string SectionEEducationPlanE3InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionEEducationPlanE3FinalScore { get; set; }

        public string SectionEEducationPlanE4ApplicationAssessmentScore { get; set; }

        public string SectionEEducationPlanE4CharacteristicsOld { get; set; }

        public string SectionEEducationPlanE4CharacteristicsWave14 { get; set; }

        public string SectionEEducationPlanIoDResidentialRag { get; set; }

        public string SectionEEducationPlanIoDSchoolBasedRag { get; set; }

        public string SectionEEducationPlanRagCommentaryBox { get; set; }

        public string SectionEEducationPlanE4ApplicationAssessmentComments { get; set; }

        public string SectionEEducationPlanE4ScoreAfterInterview { get; set; }

        public string SectionEEducationPlanE4InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionEEducationPlanE4FinalScore { get; set; }

        public string SectionEEducationPlanEducationPlanInterviewPrompts { get; set; }

        public string SectionEEducationPlanENModelType { get; set; }

        public string SectionEEducationPlanENNurseryModelAndViabilitySummaryComments { get; set; }

        public string SectionEEducationPlanENNurseryModelAndViabilityInterviewPrompts { get; set; }

        public string SectionEEducationPlanENAfterInterviewModelAndViabilitySummaryComments { get; set; }

        public string SectionFCapacityAndCapabilityFinalTotalPercentageScoreForSectionF { get; set; }

        public string SectionFCapacityAndCapabilityCapacityAndCapabilityApplicationAssessmentScore { get; set; }

        public string SectionFCapacityAndCapabilityCapacityAndCapabilitySummaryComments { get; set; }

        public string SectionFCapacityAndCapabilityDoesTheProposerGroupHaveAnyOpenSchools { get; set; }

        public string SectionFCapacityAndCapabilityExistingProviderSummary { get; set; }

        public string SectionFCapacityAndCapabilityDoesTheProposerGroupRunAnyOpenStateFundedSchools { get; set; }

        public string SectionFCapacityAndCapabilityF1ApplicationAssessmentScore { get; set; }

        public string SectionFCapacityAndCapabilityF1CharacteristicsOld { get; set; }

        public string SectionFCapacityAndCapabilityF1CharacteristicsWave14 { get; set; }

        public string SectionFCapacityAndCapabilityMatReview { get; set; }

        public string SectionFCapacityAndCapabilitySingleList { get; set; }

        public string SectionFCapacityAndCapabilityF1ApplicationAssessmentComments { get; set; }

        public string SectionFCapacityAndCapabilityF1ScoreAfterInterview { get; set; }

        public string SectionFCapacityAndCapabilityF1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionFCapacityAndCapabilityF1FinalScore { get; set; }

        public string SectionFCapacityAndCapabilityF2ApplicationAssessmentScore { get; set; }

        public string SectionFCapacityAndCapabilityF2CharacteristicsOld { get; set; }

        public string SectionFCapacityAndCapabilityF2CharacteristicsWave14 { get; set; }

        public string SectionFCapacityAndCapabilityF2ApplicationAssessmentComments { get; set; }

        public string SectionFCapacityAndCapabilityF2ScoreAfterInterview { get; set; }

        public string SectionFCapacityAndCapabilityF2InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionFCapacityAndCapabilityF2FinalScore { get; set; }

        public string SectionFCapacityAndCapabilityF3ApplicationAssessmentScore { get; set; }

        public string SectionFCapacityAndCapabilityF3CharacteristicsOld { get; set; }

        public string SectionFCapacityAndCapabilityF3CharacteristicsWave14 { get; set; }

        public string SectionFCapacityAndCapabilityF3ApplicationAssessmentComments { get; set; }

        public string SectionFCapacityAndCapabilityF3ScoreAfterInterview { get; set; }

        public string SectionFCapacityAndCapabilityF3InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionFCapacityAndCapabilityF3FinalScore { get; set; }

        public string SectionFCapacityAndCapabilityMembersNamesExperienceAndExpertise { get; set; }

        public string SectionFCapacityAndCapabilityTrusteesNamesExperienceAndExpertise { get; set; }

        public string SectionFCapacityAndCapabilityCapacityAndCapabilityInterviewPrompts { get; set; }

        public string SectionFCapacityAndCapabilityFNTrustSNurseryExperience { get; set; }

        public string SectionFCapacityAndCapabilityFNNurseryCapacityAndCapabilitySummaryComments { get; set; }

        public string SectionFCapacityAndCapabilityFNNurseryCapacityAndCapabilityInterviewPrompts { get; set; }

        public string SectionFCapacityAndCapabilityFNAfterInterviewCapacityAndCapabilitySummaryComments { get; set; }

        public string SectionGFinancialViabilityFinalTotalPercentageScoreForSectionG { get; set; }

        public string SectionGFinancialViabilityFinancialViabilityApplicationAssessmentScore { get; set; }

        public string SectionGFinancialViabilityFinancialViabilitySummaryComments { get; set; }

        public string SectionGFinancialViabilityG1ApplicationAssessmentScore { get; set; }

        public string SectionGFinancialViabilityG1CharacteristicsOld { get; set; }

        public string SectionGFinancialViabilityG1CharacteristicsWave14 { get; set; }

        public string SectionGFinancialViabilityG1ApplicationAssessmentComments { get; set; }

        public string SectionGFinancialViabilityG1ScoreAfterInterview { get; set; }

        public string SectionGFinancialViabilityG1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionGFinancialViabilityG1FinalScore { get; set; }

        public string SectionGFinancialViabilityG2ApplicationAssessmentScore { get; set; }

        public string SectionGFinancialViabilityG2CharacteristicsOld { get; set; }

        public string SectionGFinancialViabilityG2CharacteristicsWave14 { get; set; }

        public string SectionGFinancialViabilityG2ApplicationAssessmentComments { get; set; }

        public string SectionGFinancialViabilityG2ScoreAfterInterview { get; set; }

        public string SectionGFinancialViabilityG2InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable { get; set; }

        public string SectionGFinancialViabilityG2FinalScore { get; set; }

        public string SectionGFinancialViabilityFinancialViabilityInterviewPrompts { get; set; }

        public string SectionHTheProposedSiteSiteSummaryComments { get; set; }

        public string SectionHTheProposedSiteSiteAvailabilityRag { get; set; }

        public string SectionHTheProposedSiteSiteAvailabilityConfidence { get; set; }

        public string SectionHTheProposedSiteSiteAvailabilityComments { get; set; }

        public string SectionHTheProposedSiteHasASiteBeenIdentified { get; set; }

        public string SectionHTheProposedSiteAddress { get; set; }

        public string SectionHTheProposedSitePostcode { get; set; }

        public string SectionHTheProposedSitePropertyRag { get; set; }

        public string SectionHTheProposedSitePropertyRagConfidence { get; set; }

        public string SectionHTheProposedSiteTenureCharacteristicsOld { get; set; }

        public string SectionHTheProposedSiteTenureCharacteristicsWave14 { get; set; }

        public string SectionHTheProposedSitePropertyRagComments { get; set; }

        public string SectionHTheProposedSitePlanningRag { get; set; }

        public string SectionHTheProposedSitePlanningRagConfidence { get; set; }

        public string SectionHTheProposedSitePlanningPermissionCharacteristicsOld { get; set; }

        public string SectionHTheProposedSitePlanningPermissionCharacteristicsWave14 { get; set; }

        public string SectionHTheProposedSitePlanningRagComments { get; set; }

        public string SectionHTheProposedSiteCostTier { get; set; }

        public string SectionHTheProposedSiteHighCostOutlier { get; set; }

        public string SectionHTheProposedSiteHighCostOutlierCommentaryBox { get; set; }

        public string SectionHTheProposedSiteProposedSiteInterviewPrompts { get; set; }

        public string SectionIDueDiligenceHaveDueDiligenceChecksBeenUndertakenByFsd { get; set; }

        public string SectionIDueDiligenceDateOfChecks { get; set; }

        public string SectionIDueDiligenceHasFsdEngagedWithOtherAreasOfTheDepartmentArddOtherUnitsWithinFsd { get; set; }

        public string SectionIDueDiligenceIsThereAnythingOfConcernOrInterest { get; set; }

        public string SectionIDueDiligencePleaseProvideDetailsAndSuggestedActionsRemedies { get; set; }

        public string SectionIDueDiligenceDidDdcedReportAnythingOfConcernOrInterest { get; set; }

        public string SectionIDueDiligencePleaseProvideDetailsAndSuggestedActionsRemediesDdced { get; set; }

        public string SectionIDueDiligenceHavePotentialRisksBeenEscalatedAndActionsIdentified { get; set; }

        public string SectionIDueDiligenceComments { get; set; }

        public string SectionIDueDiligenceIsADdcedRepresentativeRequiredToSitOnTheInterviewPanel { get; set; }

        public string SectionIDueDiligenceLinkToDueDiligenceChecklist { get; set; }
    }
}