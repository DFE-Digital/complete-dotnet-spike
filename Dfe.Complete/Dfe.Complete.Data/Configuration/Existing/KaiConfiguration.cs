using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class KaiConfiguration : IEntityTypeConfiguration< Kai>
	{
		public void Configure(EntityTypeBuilder<Kai> builder)
		{
            builder.HasKey(e => e.Rid);
            builder.ToTable("KAI", "dbo", e => e.IsTemporal());

            builder.Property(e => e.ApplicationDetailsAnyOtherFreedomsTheSchoolIntendsToUse)
                .IsUnicode(false)
                .HasColumnName("Application Details.Any other freedoms the school intends to use");
            builder.Property(e => e.ApplicationDetailsAreAnyMembersOfTheGroupAlsoInvolvedInOtherApplicationsToOpenFreeSchoolsInThisRound)
                .IsUnicode(false)
                .HasColumnName("Application Details.Are any members of the group also involved in other applications to open free schools in this round?");
            builder.Property(e => e.ApplicationDetailsAreThereAnyConnectionsWithOtherOrganisationsWithinTheUkOrOverseas)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Are there any connections with other organisations within the UK or overseas?");
            builder.Property(e => e.ApplicationDetailsAreThereAnyConnectionsWithReligiousOrganisationsOrInstitutions)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Are there any connections with religious organisations or institutions?");
            builder.Property(e => e.ApplicationDetailsCompanyAddress)
                .IsUnicode(false)
                .HasColumnName("Application Details.Company address");
            builder.Property(e => e.ApplicationDetailsCompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Company name");
            builder.Property(e => e.ApplicationDetailsCompanyRegistrationNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Company registration number");
            builder.Property(e => e.ApplicationDetailsDateLaDecisionExpected)
                .HasColumnType("date")
                .HasColumnName("Application Details.Date LA decision expected");
            builder.Property(e => e.ApplicationDetailsDateProposalsExpected)
                .HasColumnType("date")
                .HasColumnName("Application Details.Date proposals expected");
            builder.Property(e => e.ApplicationDetailsDateSpecificationIssuedByLa)
                .HasColumnType("date")
                .HasColumnName("Application Details.Date specification issued by LA");
            builder.Property(e => e.ApplicationDetailsDateWhenCompanyWasIncorporated)
                .HasColumnType("date")
                .HasColumnName("Application Details.Date when company was incorporated");
            builder.Property(e => e.ApplicationDetailsDetailsOfAnyConnectionsWithReligiousOrganisationsOrInstitutions)
                .IsUnicode(false)
                .HasColumnName("Application Details.Details of any connections with religious organisations or institutions");
            builder.Property(e => e.ApplicationDetailsDetailsOfConnectionsWithOrganisationsWithinTheUkOrOverseas)
                .IsUnicode(false)
                .HasColumnName("Application Details.Details of connections with organisations within the UK or overseas");
            builder.Property(e => e.ApplicationDetailsDidTheProposerGroupHaveHelpAndSupportFromAnotherCompanyOrOrganisation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Did the proposer group have help and support from another company or organisation?");
            builder.Property(e => e.ApplicationDetailsDidTheProposerGroupSeekHelpAndSupportFromTheNewSchoolsNetwork)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Did the proposer group seek help and support from the New Schools Network?");
            builder.Property(e => e.ApplicationDetailsDoesTheGroupRunASchoolInTheLocalArea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Does the group run a school in the local area?");
            builder.Property(e => e.ApplicationDetailsDoesTheGroupRunASchoolOfTheSamePhaseAndType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Does the group run a school of the same phase and type?");
            builder.Property(e => e.ApplicationDetailsForIndependentSchoolsLinkToTheMostRecentInspectionReport)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.For independent schools, link to the most recent inspection report");
            builder.Property(e => e.ApplicationDetailsForIndependentSchoolsNameRatingAndUniqueReferenceNumber)
                .IsUnicode(false)
                .HasColumnName("Application Details.For independent schools, name, rating and unique reference number");
            builder.Property(e => e.ApplicationDetailsHasTheGroupAppliedBeforeToOpenThisSchoolWhetherUnderTheCurrentNameOrAnotherName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Has the group  applied before to open this school, whether under the current name or another name?");
            builder.Property(e => e.ApplicationDetailsHasThePrincipalDesignateBeenIdentified)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Has the principal designate been identified?");
            builder.Property(e => e.ApplicationDetailsHasTheProposerGroupEstablishedATrustInAccordanceWithTheDfEModelArticlesOfAssociation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Has the proposer group established a trust in accordance with the DfE model articles of association?");
            builder.Property(e => e.ApplicationDetailsHowDoesTheProposerDescribeTheirGroup)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.How does the proposer describe their group?");
            builder.Property(e => e.ApplicationDetailsHowManyApplicationsIsTheProposerGroupSeekingToOpenInThisApplicationRound)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.How many applications is the proposer group seeking to open in this application round?");
            builder.Property(e => e.ApplicationDetailsIfANurseryIsProposedPleaseStatePupilCapacity)
                .IsUnicode(false)
                .HasColumnName("Application Details.If a nursery is proposed, please state pupil capacity");
            builder.Property(e => e.ApplicationDetailsIfANurseryIsProposedPleaseStateTheAgeRange)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.If a nursery is proposed, please state the age range");
            builder.Property(e => e.ApplicationDetailsIfANurseryIsProposedStateNurseryPupilCapacityAndAgeRange)
                .IsUnicode(false)
                .HasColumnName("Application Details.If a nursery is proposed, state nursery pupil capacity and age range");
            builder.Property(e => e.ApplicationDetailsIfASixthFormIsProposedPleaseStateTheSixthFormPupilCapacity)
                .IsUnicode(false)
                .HasColumnName("Application Details.If a sixth form is proposed, please state the sixth form pupil capacity");
            builder.Property(e => e.ApplicationDetailsIfTheTrustRunsAcademiesFreeSchoolsHasAnythingChangedInTheTrustWithinTheLastMonth)
                .IsUnicode(false)
                .HasColumnName("Application Details.If the trust runs academies/free schools, has anything changed in the trust within the last month?");
            builder.Property(e => e.ApplicationDetailsIfYesAndTheNameOfTheSchoolWasDifferentStateWhatTheOriginalNameWas)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.If yes and the name of the school was different, state what the original name was:");
            builder.Property(e => e.ApplicationDetailsIfYesStateTheNamesSOfTheOrganisationsSAndDescribeTheirRole)
                .IsUnicode(false)
                .HasColumnName("Application Details.If yes, state the names (s) of the organisations(s) and describe their role");
            builder.Property(e => e.ApplicationDetailsIfYesWhenDidTheGroupLastApply)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.If yes, when did the group last apply?");
            builder.Property(e => e.ApplicationDetailsInWhichLocalAuthorityDistrictIsYourPreferredLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.In which local authority district is your preferred location?");
            builder.Property(e => e.ApplicationDetailsIsAnyoneConnectedWithThisApplicationRelatedInAnyWay)
                .IsUnicode(false)
                .HasColumnName("Application Details.Is anyone connected with this application related in any way?");
            builder.Property(e => e.ApplicationDetailsIsTheProposalADirectResultOfARequestFromGroups)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Is the proposal a direct result of a request from groups");
            builder.Property(e => e.ApplicationDetailsIsTheProposerGroupPlanningToContractTheManagementOfTheSchoolToAnotherOrganisation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Is the proposer group planning to contract the management of the school to another organisation?");
            builder.Property(e => e.ApplicationDetailsLaClosingDateForReceiptOfProposals)
                .HasColumnType("date")
                .HasColumnName("Application Details.LA closing date for receipt of proposals");
            builder.Property(e => e.ApplicationDetailsLinkToPreRegistration)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Link to pre-registration");
            builder.Property(e => e.ApplicationDetailsLinkToSpecification)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Link to specification");
            builder.Property(e => e.ApplicationDetailsMaximumCapacityOfTheFreeSchoolIncluding1619SixthFormButNotIncludingNursery)
                .IsUnicode(false)
                .HasColumnName("Application Details.Maximum capacity of the free school (including 16-19/sixth form, but not including nursery)");
            builder.Property(e => e.ApplicationDetailsNamesAndUniqueReferenceNumberSForEachOfTheTrustSOpenSchools)
                .IsUnicode(false)
                .HasColumnName("Application Details.Names and unique reference number(s) for each of the trust's open schools");
            builder.Property(e => e.ApplicationDetailsNumberOfCompanyMembers)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Number of company members");
            builder.Property(e => e.ApplicationDetailsNumberOfTrustees)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Number of trustees");
            builder.Property(e => e.ApplicationDetailsProposalsReceived)
                .IsUnicode(false)
                .HasColumnName("Application Details.Proposals received");
            builder.Property(e => e.ApplicationDetailsProposedChairOfTrustees)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Proposed chair of trustees");
            builder.Property(e => e.ApplicationDetailsStateYearTheSchoolWillHaveTheOpeningAndPanNumber)
                .IsUnicode(false)
                .HasColumnName("Application Details.State year the school will have the opening and PAN number");
            builder.Property(e => e.ApplicationDetailsTimeDedicatedToFaithStudiesHoursPerWeek)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Time dedicated to faith studies (hours per week)");
            builder.Property(e => e.ApplicationDetailsTimeDedicatedToMinorityLanguageStudyHoursPerWeek)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Time dedicated to minority language study (hours per week)");
            builder.Property(e => e.ApplicationDetailsWillTheSchoolAdoptNonStandardTermsAndConditionsForTeachers)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Will the school adopt non-standard terms and conditions for teachers?");
            builder.Property(e => e.ApplicationDetailsWillTheSchoolAdoptTheNationalCurriculum)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Will the school adopt the national curriculum?");
            builder.Property(e => e.ApplicationDetailsWillTheSchoolEmployTeachersWithoutQualifiedTeacherStatusQts)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Will the school employ teachers without qualified teacher status (QTS)?");
            builder.Property(e => e.ApplicationDetailsWillTheSchoolHaveADistinctivePedagogyOrEducationalPhilosophyForExampleSteinerOrMontessori)
                .IsUnicode(false)
                .HasColumnName("Application Details.Will the school have a distinctive pedagogy or educational philosophy, for example Steiner or Montessori?");
            builder.Property(e => e.ApplicationDetailsWillTheSchoolOperateANonStandardSchoolDay)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Will the school operate a non-standard school day?");
            builder.Property(e => e.ApplicationDetailsWillTheSchoolOperateANonStandardSchoolYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Application Details.Will the school operate a non-standard school year?");
            builder.Property(e => e.AssessmentCriteriaAreYouRecommendingApprovalOfThe1619Element)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Criteria.Are you recommending approval of the 16-19 element?");
            builder.Property(e => e.AssessmentCriteriaConditions)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Assessment Criteria.Conditions");
            builder.Property(e => e.AssessmentCriteriaFinalRecommendation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Criteria.Final recommendation");
            builder.Property(e => e.AssessmentCriteriaFinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Criteria.Final Score");
            builder.Property(e => e.AssessmentCriteriaNurseryRecommendation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Criteria.Nursery recommendation");
            builder.Property(e => e.AssessmentCriteriaNurseryRecommendationCommentary)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Assessment Criteria.Nursery recommendation commentary");
            builder.Property(e => e.AssessmentCriteriaRecommendationCommentary)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Assessment Criteria.Recommendation commentary");
            builder.Property(e => e.AssessmentDetailsDateOfLaFsPresumptionAssessment)
                .HasColumnType("date")
                .HasColumnName("Assessment Details.Date of LA FS presumption assessment");
            builder.Property(e => e.AssessmentDetailsDateOfRscHtbPresumptionDecisionMeeting)
                .HasColumnType("date")
                .HasColumnName("Assessment Details.Date of RSC/HTB presumption decision meeting");
            builder.Property(e => e.AssessmentDetailsDfERepresentationOnFsPresumptionPanel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.DfE representation on FS presumption panel?");
            builder.Property(e => e.AssessmentDetailsEqualitiesImpactAssessment)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Equalities impact assessment");
            builder.Property(e => e.AssessmentDetailsInterviewAttendees)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Interview Attendees");
            builder.Property(e => e.AssessmentDetailsInterviewPanel)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Interview panel");
            builder.Property(e => e.AssessmentDetailsMinisterialPostInterviewDecision)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Ministerial post-interview decision");
            builder.Property(e => e.AssessmentDetailsMinisterialPostPaperDecision)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Ministerial post-paper decision");
            builder.Property(e => e.AssessmentDetailsNameOfDfEIndividualSOnFsPresumptionAssessmentPanel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Name of DfE individual(s) on FS presumption assessment panel");
            builder.Property(e => e.AssessmentDetailsPostInterviewRecommendationToTheMinister)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Post-interview recommendation to the Minister");
            builder.Property(e => e.AssessmentDetailsPostPaperRecommendationToTheMinister)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Post-paper recommendation to the Minister");
            builder.Property(e => e.AssessmentDetailsRscPaperBasedRecommendation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.RSC paper-based recommendation");
            builder.Property(e => e.AssessmentDetailsRscPostInterviewRecommendation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.RSC post-interview recommendation");
            builder.Property(e => e.AssessmentDetailsWasSuccessfulFsPresumptionSponsorRecommendedByTheLa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Assessment Details.Was successful FS presumption sponsor recommended by the LA?");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.SectionBNeedB11619ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Application assessment comments");
            builder.Property(e => e.SectionBNeedB11619ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Application assessment score");
            builder.Property(e => e.SectionBNeedB11619CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Characteristics (Old)");
            builder.Property(e => e.SectionBNeedB11619CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Characteristics (Wave 14)");
            builder.Property(e => e.SectionBNeedB11619FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Final score");
            builder.Property(e => e.SectionBNeedB11619Indicators)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Indicators");
            builder.Property(e => e.SectionBNeedB11619InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionBNeedB11619IsTheLocalAuthoritySupportiveOfTheSchool)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Is the Local Authority supportive of the school?");
            builder.Property(e => e.SectionBNeedB11619ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Score after interview");
            builder.Property(e => e.SectionBNeedB11619SiftAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Sift assessment comments");
            builder.Property(e => e.SectionBNeedB11619SiftAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1(16-19) Sift assessment score");
            builder.Property(e => e.SectionBNeedB11ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Application assessment comments");
            builder.Property(e => e.SectionBNeedB11ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Application assessment score");
            builder.Property(e => e.SectionBNeedB11CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Characteristics (Old)");
            builder.Property(e => e.SectionBNeedB11CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Characteristics (Wave 14)");
            builder.Property(e => e.SectionBNeedB11FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Final score");
            builder.Property(e => e.SectionBNeedB11IndicatorsContributory)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Indicators - Contributory");
            builder.Property(e => e.SectionBNeedB11IndicatorsCore)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Indicators - Core");
            builder.Property(e => e.SectionBNeedB11InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionBNeedB11IsTheLocalAuthoritySupportiveOfTheSchool)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Is the Local Authority supportive of the school?");
            builder.Property(e => e.SectionBNeedB11ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Score after interview");
            builder.Property(e => e.SectionBNeedB11SiftAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Sift assessment comments");
            builder.Property(e => e.SectionBNeedB11SiftAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.1 Sift assessment score");
            builder.Property(e => e.SectionBNeedB12ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.2 Application assessment comments");
            builder.Property(e => e.SectionBNeedB12ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.2 Application assessment score");
            builder.Property(e => e.SectionBNeedB12FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.2 Final score");
            builder.Property(e => e.SectionBNeedB12InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.2 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionBNeedB12ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.2 Score after interview");
            builder.Property(e => e.SectionBNeedB12SiftAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.2 Sift assessment comments");
            builder.Property(e => e.SectionBNeedB12SiftAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B1.2 Sift assessment score");
            builder.Property(e => e.SectionBNeedB21619ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Application assessment comments");
            builder.Property(e => e.SectionBNeedB21619ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Application assessment score");
            builder.Property(e => e.SectionBNeedB21619CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Characteristics (Old)");
            builder.Property(e => e.SectionBNeedB21619CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Characteristics (Wave 14)");
            builder.Property(e => e.SectionBNeedB21619FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Final score");
            builder.Property(e => e.SectionBNeedB21619IndicatorsContributory)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Indicators – Contributory");
            builder.Property(e => e.SectionBNeedB21619IndicatorsCore)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Indicators – Core");
            builder.Property(e => e.SectionBNeedB21619InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionBNeedB21619ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Score after interview");
            builder.Property(e => e.SectionBNeedB21619SiftAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Sift assessment comments");
            builder.Property(e => e.SectionBNeedB21619SiftAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2(16-19) Sift assessment score");
            builder.Property(e => e.SectionBNeedB2ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Application assessment comments");
            builder.Property(e => e.SectionBNeedB2ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Application assessment score");
            builder.Property(e => e.SectionBNeedB2CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Characteristics (Old)");
            builder.Property(e => e.SectionBNeedB2CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Characteristics (Wave 14)");
            builder.Property(e => e.SectionBNeedB2FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Final score");
            builder.Property(e => e.SectionBNeedB2IndicatorsContributory)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Indicators – Contributory");
            builder.Property(e => e.SectionBNeedB2IndicatorsCore)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Indicators - Core");
            builder.Property(e => e.SectionBNeedB2InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionBNeedB2ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Score after interview");
            builder.Property(e => e.SectionBNeedB2SiftAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Sift assessment comments");
            builder.Property(e => e.SectionBNeedB2SiftAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B2 Sift assessment score");
            builder.Property(e => e.SectionBNeedBNAfterInterviewNurseryNeedSummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B(N) After interview nursery need summary comments");
            builder.Property(e => e.SectionBNeedBNEngagementWithTheLocalAuthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B(N) Engagement with the local authority");
            builder.Property(e => e.SectionBNeedBNNurseryNeedInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B(N) Nursery need interview prompts");
            builder.Property(e => e.SectionBNeedBNNurseryNeedSummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.B(N) Nursery need summary comments");
            builder.Property(e => e.SectionBNeedFinalTotalPercentageScoreForSectionB)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.Final total percentage score for Section B");
            builder.Property(e => e.SectionBNeedNeedApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.Need application assessment score");
            builder.Property(e => e.SectionBNeedNeedCommentaryAndInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.Need commentary and interview prompts");
            builder.Property(e => e.SectionBNeedNeedSummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.Need summary comments");
            builder.Property(e => e.SectionBNeedPostcode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.Postcode");
            builder.Property(e => e.SectionBNeedWillWeContinueToAssess1619)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section B - Need.Will we continue to assess 16-19?");
            builder.Property(e => e.SectionCVisionC1ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C1 Application assessment comments");
            builder.Property(e => e.SectionCVisionC1ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C1 Application assessment score");
            builder.Property(e => e.SectionCVisionC1CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C1 Characteristics (Old)");
            builder.Property(e => e.SectionCVisionC1CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C1 Characteristics (Wave 14)");
            builder.Property(e => e.SectionCVisionC1FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C1 Final score");
            builder.Property(e => e.SectionCVisionC1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C1 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionCVisionC1ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C1 Score after interview");
            builder.Property(e => e.SectionCVisionCNAfterInterviewSummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C(N) After interview summary comments");
            builder.Property(e => e.SectionCVisionCNAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C(N) Assessment");
            builder.Property(e => e.SectionCVisionCNAssessmentAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C(N) Assessment after interview");
            builder.Property(e => e.SectionCVisionCNAssessmentSummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C(N) Assessment summary comments");
            builder.Property(e => e.SectionCVisionCNNurseryVisionInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.C(N) Nursery vision interview prompts");
            builder.Property(e => e.SectionCVisionFinalTotalPercentageScoreForSectionC)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.Final total percentage score for section C");
            builder.Property(e => e.SectionCVisionVisionApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.Vision application assessment score");
            builder.Property(e => e.SectionCVisionVisionInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.Vision interview prompts");
            builder.Property(e => e.SectionCVisionVisionSummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section C - Vision.Vision summary comments");
            builder.Property(e => e.SectionDEngagementCharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.Characteristics (Old)");
            builder.Property(e => e.SectionDEngagementCharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.Characteristics (Wave 14)");
            builder.Property(e => e.SectionDEngagementD1ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.D1 Application assessment comments");
            builder.Property(e => e.SectionDEngagementD1ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.D1 Application assessment score");
            builder.Property(e => e.SectionDEngagementD1FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.D1 Final score");
            builder.Property(e => e.SectionDEngagementD1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.D1 Interview comments - evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionDEngagementD1ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.D1 Score after interview");
            builder.Property(e => e.SectionDEngagementEngagementWithParentsAndTheLocalCommunityApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.Engagement with parents and the local community application assessment score");
            builder.Property(e => e.SectionDEngagementEngagementWithParentsAndTheLocalCommunityInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.Engagement with parents and the local community interview prompts");
            builder.Property(e => e.SectionDEngagementEngagementWithParentsAndTheLocalCommunitySummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.Engagement with parents and the local community summary comments");
            builder.Property(e => e.SectionDEngagementFinalTotalPercentageScoreForSectionD)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section D - Engagement.Final total percentage score for section D");
            builder.Property(e => e.SectionEEducationPlanE1ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E1 Application assessment comments");
            builder.Property(e => e.SectionEEducationPlanE1ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E1 Application assessment score");
            builder.Property(e => e.SectionEEducationPlanE1CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E1 Characteristics (Old)");
            builder.Property(e => e.SectionEEducationPlanE1CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E1 Characteristics (Wave 14)");
            builder.Property(e => e.SectionEEducationPlanE1FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E1 Final score");
            builder.Property(e => e.SectionEEducationPlanE1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E1 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionEEducationPlanE1ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E1 Score after interview");
            builder.Property(e => e.SectionEEducationPlanE2ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E2 Application assessment comments");
            builder.Property(e => e.SectionEEducationPlanE2ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E2 Application assessment score");
            builder.Property(e => e.SectionEEducationPlanE2CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E2 Characteristics (Old)");
            builder.Property(e => e.SectionEEducationPlanE2CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E2 Characteristics (Wave 14)");
            builder.Property(e => e.SectionEEducationPlanE2FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E2 Final score");
            builder.Property(e => e.SectionEEducationPlanE2InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E2 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionEEducationPlanE2ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E2 Score after interview");
            builder.Property(e => e.SectionEEducationPlanE3ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E3 Application assessment comments");
            builder.Property(e => e.SectionEEducationPlanE3ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E3 Application assessment score");
            builder.Property(e => e.SectionEEducationPlanE3CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E3 Characteristics (Old)");
            builder.Property(e => e.SectionEEducationPlanE3CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E3 Characteristics (Wave 14)");
            builder.Property(e => e.SectionEEducationPlanE3FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E3 Final score");
            builder.Property(e => e.SectionEEducationPlanE3InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E3 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionEEducationPlanE3ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E3 Score after interview");
            builder.Property(e => e.SectionEEducationPlanE4ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E4 Application assessment comments");
            builder.Property(e => e.SectionEEducationPlanE4ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E4 Application assessment score");
            builder.Property(e => e.SectionEEducationPlanE4CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E4 Characteristics (Old)");
            builder.Property(e => e.SectionEEducationPlanE4CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E4 Characteristics (Wave 14)");
            builder.Property(e => e.SectionEEducationPlanE4FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E4 Final score");
            builder.Property(e => e.SectionEEducationPlanE4InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E4 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionEEducationPlanE4ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E4 Score after interview");
            builder.Property(e => e.SectionEEducationPlanENAfterInterviewModelAndViabilitySummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E(N) After interview model and viability summary comments");
            builder.Property(e => e.SectionEEducationPlanENModelType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E(N) Model type");
            builder.Property(e => e.SectionEEducationPlanENNurseryModelAndViabilityInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E(N) Nursery model and viability interview prompts");
            builder.Property(e => e.SectionEEducationPlanENNurseryModelAndViabilitySummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.E(N) Nursery model and viability summary comments");
            builder.Property(e => e.SectionEEducationPlanEducationAdviserAssessment)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.Education adviser assessment");
            builder.Property(e => e.SectionEEducationPlanEducationPlanApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.Education plan application assessment score");
            builder.Property(e => e.SectionEEducationPlanEducationPlanInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.Education plan interview prompts");
            builder.Property(e => e.SectionEEducationPlanEducationPlanSummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.Education plan summary comments");
            builder.Property(e => e.SectionEEducationPlanFinalTotalPercentageScoreForSectionE)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.Final total percentage score for section E");
            builder.Property(e => e.SectionEEducationPlanIoDResidentialRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.IoD Residential RAG");
            builder.Property(e => e.SectionEEducationPlanIoDSchoolBasedRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.IoD School Based RAG");
            builder.Property(e => e.SectionEEducationPlanRagCommentaryBox)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section E - Education Plan.RAG commentary box");
            builder.Property(e => e.SectionFCapacityAndCapabilityCapacityAndCapabilityApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Capacity and capability application assessment score");
            builder.Property(e => e.SectionFCapacityAndCapabilityCapacityAndCapabilityInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Capacity and capability interview prompts");
            builder.Property(e => e.SectionFCapacityAndCapabilityCapacityAndCapabilitySummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Capacity and capability summary comments");
            builder.Property(e => e.SectionFCapacityAndCapabilityDoesTheProposerGroupHaveAnyOpenSchools)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Does the proposer group have any open schools?");
            builder.Property(e => e.SectionFCapacityAndCapabilityDoesTheProposerGroupRunAnyOpenStateFundedSchools)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Does the proposer group run any open state funded schools?");
            builder.Property(e => e.SectionFCapacityAndCapabilityExistingProviderSummary)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Existing provider summary");
            builder.Property(e => e.SectionFCapacityAndCapabilityF1ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F1 Application assessment comments");
            builder.Property(e => e.SectionFCapacityAndCapabilityF1ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F1 Application assessment score");
            builder.Property(e => e.SectionFCapacityAndCapabilityF1CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F1 Characteristics (Old)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF1CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F1 Characteristics (Wave 14)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF1FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F1 Final score");
            builder.Property(e => e.SectionFCapacityAndCapabilityF1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F1 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF1ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F1 Score after interview");
            builder.Property(e => e.SectionFCapacityAndCapabilityF2ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F2 Application assessment comments");
            builder.Property(e => e.SectionFCapacityAndCapabilityF2ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F2 Application assessment score");
            builder.Property(e => e.SectionFCapacityAndCapabilityF2CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F2 Characteristics (Old)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF2CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F2 Characteristics (Wave 14)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF2FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F2 Final score");
            builder.Property(e => e.SectionFCapacityAndCapabilityF2InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F2 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF2ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F2 Score after interview");
            builder.Property(e => e.SectionFCapacityAndCapabilityF3ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F3 Application assessment comments");
            builder.Property(e => e.SectionFCapacityAndCapabilityF3ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F3 Application assessment score");
            builder.Property(e => e.SectionFCapacityAndCapabilityF3CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F3 Characteristics (Old)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF3CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F3 Characteristics (Wave 14)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF3FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F3 Final score");
            builder.Property(e => e.SectionFCapacityAndCapabilityF3InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F3 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionFCapacityAndCapabilityF3ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F3 Score after interview");
            builder.Property(e => e.SectionFCapacityAndCapabilityFNAfterInterviewCapacityAndCapabilitySummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F(N) After interview capacity and capability summary comments");
            builder.Property(e => e.SectionFCapacityAndCapabilityFNNurseryCapacityAndCapabilityInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F(N) Nursery capacity and capability interview prompts");
            builder.Property(e => e.SectionFCapacityAndCapabilityFNNurseryCapacityAndCapabilitySummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F(N) Nursery capacity and capability summary comments");
            builder.Property(e => e.SectionFCapacityAndCapabilityFNTrustSNurseryExperience)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.F(N) Trust's nursery experience");
            builder.Property(e => e.SectionFCapacityAndCapabilityFinalTotalPercentageScoreForSectionF)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Final total percentage score for section F");
            builder.Property(e => e.SectionFCapacityAndCapabilityMatReview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.MAT Review");
            builder.Property(e => e.SectionFCapacityAndCapabilityMembersNamesExperienceAndExpertise)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Members' names, experience and expertise");
            builder.Property(e => e.SectionFCapacityAndCapabilitySingleList)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Single list");
            builder.Property(e => e.SectionFCapacityAndCapabilityTrusteesNamesExperienceAndExpertise)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section F - Capacity and capability.Trustees' names, experience and expertise");
            builder.Property(e => e.SectionGFinancialViabilityFinalTotalPercentageScoreForSectionG)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.Final total percentage score for section G");
            builder.Property(e => e.SectionGFinancialViabilityFinancialViabilityApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.Financial viability application assessment score");
            builder.Property(e => e.SectionGFinancialViabilityFinancialViabilityInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.Financial viability interview prompts");
            builder.Property(e => e.SectionGFinancialViabilityFinancialViabilitySummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.Financial viability summary comments");
            builder.Property(e => e.SectionGFinancialViabilityG1ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G1 Application assessment comments");
            builder.Property(e => e.SectionGFinancialViabilityG1ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G1 Application assessment score");
            builder.Property(e => e.SectionGFinancialViabilityG1CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G1 Characteristics (Old)");
            builder.Property(e => e.SectionGFinancialViabilityG1CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G1 Characteristics (Wave 14)");
            builder.Property(e => e.SectionGFinancialViabilityG1FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G1 Final score");
            builder.Property(e => e.SectionGFinancialViabilityG1InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G1 Interview comments - evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionGFinancialViabilityG1ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G1 Score after interview");
            builder.Property(e => e.SectionGFinancialViabilityG2ApplicationAssessmentComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G2 Application assessment comments");
            builder.Property(e => e.SectionGFinancialViabilityG2ApplicationAssessmentScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G2 Application assessment score");
            builder.Property(e => e.SectionGFinancialViabilityG2CharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G2 Characteristics (Old)");
            builder.Property(e => e.SectionGFinancialViabilityG2CharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G2 Characteristics (Wave 14)");
            builder.Property(e => e.SectionGFinancialViabilityG2FinalScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G2 Final score");
            builder.Property(e => e.SectionGFinancialViabilityG2InterviewCommentsEvidenceThatLedToAScoreChangeIfApplicable)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G2 Interview comments – evidence that led to a score change (if applicable)");
            builder.Property(e => e.SectionGFinancialViabilityG2ScoreAfterInterview)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section G - Financial viability.G2 Score after interview");
            builder.Property(e => e.SectionHTheProposedSiteAddress)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Address");
            builder.Property(e => e.SectionHTheProposedSiteCostTier)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Cost Tier");
            builder.Property(e => e.SectionHTheProposedSiteHasASiteBeenIdentified)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Has a site been identified?");
            builder.Property(e => e.SectionHTheProposedSiteHighCostOutlier)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.High cost outlier");
            builder.Property(e => e.SectionHTheProposedSiteHighCostOutlierCommentaryBox)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.High cost outlier commentary box");
            builder.Property(e => e.SectionHTheProposedSitePlanningPermissionCharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Planning permission characteristics (Old)");
            builder.Property(e => e.SectionHTheProposedSitePlanningPermissionCharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Planning permission characteristics (Wave 14)");
            builder.Property(e => e.SectionHTheProposedSitePlanningRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Planning RAG");
            builder.Property(e => e.SectionHTheProposedSitePlanningRagComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Planning RAG comments");
            builder.Property(e => e.SectionHTheProposedSitePlanningRagConfidence)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Planning RAG confidence");
            builder.Property(e => e.SectionHTheProposedSitePostcode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Postcode");
            builder.Property(e => e.SectionHTheProposedSitePropertyRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Property RAG");
            builder.Property(e => e.SectionHTheProposedSitePropertyRagComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Property RAG comments");
            builder.Property(e => e.SectionHTheProposedSitePropertyRagConfidence)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Property RAG confidence");
            builder.Property(e => e.SectionHTheProposedSiteProposedSiteInterviewPrompts)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Proposed site interview prompts");
            builder.Property(e => e.SectionHTheProposedSiteSiteAvailabilityComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Site availability comments");
            builder.Property(e => e.SectionHTheProposedSiteSiteAvailabilityConfidence)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Site availability confidence");
            builder.Property(e => e.SectionHTheProposedSiteSiteAvailabilityRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Site availability RAG");
            builder.Property(e => e.SectionHTheProposedSiteSiteSummaryComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Site summary comments");
            builder.Property(e => e.SectionHTheProposedSiteTenureCharacteristicsOld)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Tenure characteristics (Old)");
            builder.Property(e => e.SectionHTheProposedSiteTenureCharacteristicsWave14)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Section H - The proposed site.Tenure characteristics (Wave 14)");
            builder.Property(e => e.SectionIDueDiligenceComments)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Comments");
            builder.Property(e => e.SectionIDueDiligenceDateOfChecks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Date of checks");
            builder.Property(e => e.SectionIDueDiligenceDidDdcedReportAnythingOfConcernOrInterest)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Did DDCED report anything of concern or interest?");
            builder.Property(e => e.SectionIDueDiligenceHasFsdEngagedWithOtherAreasOfTheDepartmentArddOtherUnitsWithinFsd)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Has FSD engaged with other areas of the department? (ARDD, other units within FSD)");
            builder.Property(e => e.SectionIDueDiligenceHaveDueDiligenceChecksBeenUndertakenByFsd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Have due diligence checks been undertaken by FSD?");
            builder.Property(e => e.SectionIDueDiligenceHavePotentialRisksBeenEscalatedAndActionsIdentified)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Have potential risks been escalated and actions identified?");
            builder.Property(e => e.SectionIDueDiligenceIsADdcedRepresentativeRequiredToSitOnTheInterviewPanel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Is a DDCED representative required to sit on the interview panel?");
            builder.Property(e => e.SectionIDueDiligenceIsThereAnythingOfConcernOrInterest)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Is there anything of concern or interest?");
            builder.Property(e => e.SectionIDueDiligenceLinkToDueDiligenceChecklist)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Link to due diligence checklist");
            builder.Property(e => e.SectionIDueDiligencePleaseProvideDetailsAndSuggestedActionsRemedies)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Please provide details and suggested actions/remedies");
            builder.Property(e => e.SectionIDueDiligencePleaseProvideDetailsAndSuggestedActionsRemediesDdced)
                .HasMaxLength(4799)
                .IsUnicode(false)
                .HasColumnName("Section I - Due Diligence.Please provide details and suggested actions/remedies (DDCED)");

            AuditConfiguration.Apply(builder);
        }
	}

}
