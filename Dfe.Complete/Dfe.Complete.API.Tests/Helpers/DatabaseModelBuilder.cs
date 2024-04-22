using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using System;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Helpers
{
    public class DatabaseModelBuilder
    {
        private static Fixture _fixture = new();

        public static Kpi BuildProject()
        {
            var result = BuildProjectMandatoryFieldsOnly();

            result.ProjectStatusProjectId = CreateProjectId();
            result.ProjectStatusCurrentFreeSchoolName = _fixture.Create<string>();
            result.TrustName = _fixture.Create<string>();
            result.ProjectStatusProjectStatus = _fixture.Create<string>();
            result.ProjectStatusFreeSchoolsApplicationNumber = _fixture.Create<string>().Substring(0, 9);
            result.ProjectStatusUrnWhenGivenOne = _fixture.Create<string>();
            result.ProjectStatusFreeSchoolApplicationWave = _fixture.Create<string>();
            result.ProjectStatusRealisticYearOfOpening = _fixture.Create<string>();
            result.ProjectStatusDateOfEntryIntoPreOpening = _fixture.Create<DateTime>();
            result.ProjectStatusProvisionalOpeningDateAgreedWithTrust = _fixture.Create<DateTime>();
            result.ProjectStatusActualOpeningDate = _fixture.Create<DateTime>();
            result.ProjectStatusTrustsPreferredYearOfOpening = _fixture.Create<string>();
            result.ProjectStatusFreeSchoolPenPortrait = _fixture.Create<string>();
            result.ProjectStatusDateClosed = _fixture.Create<DateTime>();

            result.LocalAuthority = _fixture.Create<string>();
            result.SchoolDetailsGeographicalRegion = _fixture.Create<string>();
            result.SchoolDetailsConstituency = _fixture.Create<string>();
            result.SchoolDetailsConstituencyMp = _fixture.Create<string>();
            result.SchoolDetailsNumberOfFormsOfEntry = _fixture.Create<string>();
            result.SchoolDetailsSchoolTypeMainstreamApEtc = _fixture.Create<string>();
            result.SchoolDetailsSchoolPhasePrimarySecondary = _fixture.Create<string>();
            result.SchoolDetailsAgeRange = _fixture.Create<string>();
            result.SchoolDetailsGender = _fixture.Create<string>();
            result.SchoolDetailsNursery = _fixture.Create<string>();
            result.SchoolDetailsSixthForm = _fixture.Create<string>();
            result.SchoolDetailsAlternativeProvision = _fixture.Create<string>();
            result.SchoolDetailsSpecialEducationNeeds = _fixture.Create<string>();
            result.SchoolDetailsIndependentConverter = _fixture.Create<string>();
            result.SchoolDetailsSpecialistResourceProvision = _fixture.Create<string>();
            result.SchoolDetailsFaithStatus = _fixture.Create<string>();
            result.SchoolDetailsFaithType = _fixture.Create<string>();
            result.SchoolDetailsTrustId = _fixture.Create<string>().Substring(0, 4);
            result.SchoolDetailsTrustName = _fixture.Create<string>();
            result.SchoolDetailsLaestabWhenGivenOne = _fixture.Create<string>();
            result.SchoolDetailsDetailsOfResidentialBoardingProvision = _fixture.Create<string>();
            result.SchoolDetailsResidentialOrBoardingProvision = _fixture.Create<string>();
            result.SchoolDetailsSixthFormType = _fixture.Create<string>();
            result.SchoolDetailsPleaseSpecifyOtherFaithType = _fixture.Create<string>();
            result.SchoolDetailsSpecialism = _fixture.Create<string>();
            result.SchoolDetailsRscRegion = _fixture.Create<string>();

            result.KeyContactsFsgTeamLeader = _fixture.Create<string>();
            result.KeyContactsFsgGrade6 = _fixture.Create<string>();
            result.KeyContactsEsfaCapitalProjectManager = _fixture.Create<string>();
            result.KeyContactsEsfaCapitalProjectDirector = _fixture.Create<string>();
            result.SchoolDetailsTrustType = _fixture.Create<string>();
            result.KeyContactsFsgLeadContact = _fixture.Create<string>();
            result.KeyContactsChairOfGovernorsEmail = _fixture.Create<string>();
            result.KeyContactsChairOfGovernorsName = _fixture.Create<string>();
            result.KeyContactsChairOfGovernorsMatEmail = _fixture.Create<string>();
            result.KeyContactsChairOfGovernorsMat = _fixture.Create<string>();
            result.KeyContactsSchoolAddress = _fixture.Create<string>();
            result.KeyContactsPostcode = _fixture.Create<string>();

            return result;
        }

        public static Kpi BuildProjectMandatoryFieldsOnly()
        {
            var result = new Kpi
            {
                Rid = _fixture.Create<string>().Substring(0, 10),
                AprilIndicator = _fixture.Create<string>().Substring(0, 9),
                Wave = CreateProjectWave(),
                UpperStatus = _fixture.Create<string>().Substring(0, 10),
                FsType = _fixture.Create<string>().Substring(0, 13),
                FsType1 = _fixture.Create<string>().Substring(0, 15),
                MatUnitProjects = _fixture.Create<string>().Substring(0, 31),
                SponsorUnitProjects = _fixture.Create<string>()
            };

            return result;
        }

        public static Trust BuildTrust()
        {
            var result = new Trust
            {
                Rid = _fixture.Create<string>().Substring(0, 10),
                TrustRef = _fixture.Create<string>().Substring(0, 7),
                TrustsTrustRef = _fixture.Create<string>().Substring(0, 5),
                TrustsTrustName = _fixture.Create<string>(),
                TrustsTrustType = _fixture.Create<string>()
            };

            return result;
        }

        public static Property BuildProperty()
        {
            var result = new Property
            {
                Rid = _fixture.Create<string>().Substring(0, 10),
                SiteNameOfSite = _fixture.Create<string>(),
                SitePostcodeOfSite = _fixture.Create<string>(),
                Tos = _fixture.Create<string>().Substring(0, 8),
            };

            return result;
        }

        public static string CreateProjectId()
        {
            return _fixture.Create<string>().Substring(0, 24);
        }

        public static string CreateProjectWave()
        {
            return _fixture.Create<string>().Substring(0, 15);
        }

        public static RiskAppraisalMeetingTask BuildRiskAppraisalMeetingTask(string rid)
        {
            var result = new RiskAppraisalMeetingTask();

            result.RID = rid;

            return result;
        }

        public static Milestones BuildMilestone(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.MAACheckedSubmittedArticlesMatch = false;
            result.MAAChairHaveSubmittedConfirmation = false;
            result.MAAArrangementsMatchGovernancePlans = false;
            result.FsgPreOpeningMilestonesMaaForecastDate = new DateTime(2030, 3, 1);
            result.FsgPreOpeningMilestonesMaaActualDateOfCompletion = new DateTime(2030, 3, 1);
            result.FsgPreOpeningMilestonesMi107LinkToSavedDocument = "No comments";
            result.FsgPreOpeningMilestonesMi56CommentsOnDecisionToApproveIfApplicable = "https://www.test.com/";
            result.FsgPreOpeningMilestonesKickOffMeetingHeldActualDate = _fixture.Create<DateTime>();
            result.FsgPreOpeningMilestonesFaActualDateOfCompletion = _fixture.Create<DateTime>();
            result.FsgPreOpeningMilestonesFaForecastDate = _fixture.Create<DateTime>();

            return result;
        }
        
        public static Milestones BuildKickOffMeetingTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesMi141LinkToSavedDocument = "https://www.test.com";
            result.FsgPreOpeningMilestonesFundingArrangementAgreedBetweenLaAndSponsor = false;

            return result;
        }

        public static Milestones BuildStatutoryConsultationTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesScrForecastDate = new DateTime().AddDays(9);
            result.FsgPreOpeningMilestonesScrReceived = null;
            result.FsgPreOpeningMilestonesScrActualDateOfCompletion = null;
            result.FsgPreOpeningMilestonesScrFulfilsSection10StatutoryDuty = null;
            result.FsgPreOpeningMilestonesMi80CommentsOnDecisionToApproveIfApplicable = "";
            result.FsgPreOpeningMilestonesScrSavedFindingsInWorkplacesFolder = null;

            return result;
        }

        public static Milestones BuildModelFundingAgreementTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesMfadForecastDate = DateTime.Now;

            return result;
        }

        public static Milestones BuildFundingAgreementHealthCheckTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesMfadDraftedFaHealthCheck = true;
            result.FsgPreOpeningMilestonesMfadRegionalDirectorSignedOffFaHealthCheck = false;
            result.FsgPreOpeningMilestonesMfadMinisterSignedOffFaHealthCheck = false;
            result.FsgPreOpeningMilestonesMfadSavedFaHealthCheckInWorkplacesFolder = false;

            return result;
        }

        public static Milestones BuildFinalFinancePlanTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesFfpConfirmedTrustHasProvidedFinalPlan = true;
            result.FsgPreOpeningMilestonesFfpGrade6SignedOffFinalPlanDate = DateTime.Now;
            result.FsgPreOpeningMilestonesFfpSentFinalPlanToRevenueFundingMailbox = false;
            result.FsgPreOpeningMilestonesFfpSavedFinalPlanInWorkplacesFolder = false;

            return result;
        }

        public static Milestones BuildGiasTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FSGPreOpeningMilestonesGIASApplicationFormSent = true;
            result.FSGPreOpeningMilestonesGIASCheckedTrustInformation = true;
            result.FSGPreOpeningMilestonesGIASSavedToWorkspaces = true;
            result.FSGPreOpeningMilestonesGIASURNSent = true;
            

            return result;
        }
        
        public static Milestones BuildEducationBriefTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FSGPreOpeningMilestonesEducationPlanInBrief = true;
            result.FSGPreOpeningMilestonesEducationPolicesInBrief = true;
            result.FSGPreOpeningMilestonesEducationBriefPupilAssessmentAndTrackingHistory = true;
            result.FSGPreOpeningMilestonesEducationBriefSavedToWorkplaces = true;
            

            return result;
        }
        
        public static Milestones BuildAdmissionsArrangementsTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesAdmissionsArrangementsRecommendedTemplate = true;
            result.FsgPreOpeningMilestonesAdmissionsArrangementsComplyWithPolicies = true;
            result.FsgPreOpeningMilestonesSapActualDateOfCompletion = new DateTime().AddDays(1);
            result.FSGPreOpeningMilestonesEducationBriefSavedToWorkplaces = true;
            

            return result;
        }
        
        public static Milestones BuildImpactAssessmentTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesImpactAssessmentDone = true;
            result.FsgPreOpeningMilestonesImpactAssessmentSavedToWorkplaces = true;
            return result;
        }
        
        public static Milestones EvidenceOfAcceptedOffersTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesSeenEvidenceOfAcceptedOffers = false;
            result.FsgPreOpeningMilestonesAcceptedOffersComments = "First Comments";
            result.FsgPreOpeningMilestonesAcceptedOffersEmailSavedToWorkplaces = false;
            return result;
        }
        
        public static Milestones OfstedInspectionTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesProcessDetailsProvided = true;
            result.FsgPreOpeningMilestonesDocumentsAndG6SavedToWorkplaces = true;
            result.FsgPreOpeningMilestonesBlockAndContentDetailsToOpenersSpreadSheet = true;
            result.FsgPreOpeningMilestonesInspectionConditionsMet = "Yes";
            
            return result;
        }
        
        public static Milestones ApplicationsEvidenceTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.FsgPreOpeningMilestonesApplicationsEvidenceConfirmedPupilNumbers = false;
            result.FsgPreOpeningMilestonesApplicationsEvidenceComments = "first test comments";
            result.FsgPreOpeningMilestonesApplicationsEvidenceBuildUpFormSavedToWorkplaces = false;
            result.FsgPreOpeningMilestonesApplicationsEvidenceUnderwritingAgreementSavedToWorkplaces = false;
            
            return result;
        }
        
        public static Po PupilNumbersAndCapacity(string rid)
        {
            var result = new Po()
            {
                Rid = rid,
                PupilNumbersAndCapacityTotalOfCapacityTotals = _fixture.Create<int>().ToString()
            };

            return result;
        }

        public static Milestones BuildEqualitiesAssessmentTask(string rid)
        {
            var result = new Milestones();

            result.Rid = rid;

            result.EqualitiesAssessmentCompletedEPR = null;
            result.EqualitiesAssessmentSavedEPRInWorkplacesFolder = null;

            return result;
        }

        public static Po BuildPaymentScheduleTask(string rid)
        {
            var result = new Po()
            {
                Rid = rid,
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime().AddDays(1),
                ProjectDevelopmentGrantFundingAmountOf1stPayment = _fixture.Create<decimal>().ToString(),
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = _fixture.Create<decimal>().ToString(),
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime().AddDays(2),
            };

            return result;
        }

        public static Po BuildTrustLetterTask(string rid)
        {
            var result = new Po()
            {
                Rid = rid,
                PdgGrantLetterLinkSavedToWorkplaces = false,
                ProjectDevelopmentGrantFundingPdgGrantLetterDate = new DateTime().AddDays(1),
            };

            return result;
        }

        public static Po BuildStopPaymentTask(string rid)
        {
            var result = new Po()
            {
                Rid = rid,
                ProjectDevelopmentGrantFundingPaymentsStopped = "No",
                ProjectDevelopmentGrantFundingDatePaymentsStopped = new DateTime().AddDays(1),
            };

            return result;
        }

        public static Po BuildRefundsTask(string rid)
        {
            var result = new Po()
            {
                Rid = rid,
                ProjectDevelopmentGrantFundingAmountOf1stRefund = "888",
                ProjectDevelopmentGrantFundingDateOf1stRefund = new DateTime().AddDays(1),
            };

            return result;
        }

        internal static Po BuildWriteOffTask(string rid)
        {
            var result = new Po()
            {
                Rid = rid,
                ProjectDevelopmentGrantFundingDateOf1stWriteOff = new DateTime().AddDays(1),
                ProjectDevelopmentGrantFundingAmountApprovedFor1stWriteOff = "100",
                ProjectDevelopmentGrantFundingReasonFor1stWriteOff = "29525",
                ProjectDevelopmentGrantFundingFinanceBusinessPartnerApprovalReceivedFrom = "asgaas",
                ProjectDevelopmentGrantFundingDateWriteOffApprovedByFinanceBusinessPartners = new DateTime().AddDays(2),
            };

            return result;
        }
    }
}
