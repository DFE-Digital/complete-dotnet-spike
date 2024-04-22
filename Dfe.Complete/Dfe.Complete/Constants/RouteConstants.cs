namespace Dfe.ManageFreeSchoolProjects.Constants
{
    public static class RouteConstants
    {
        public const string ProjectOverview = "/projects/{0}/overview";
        public const string TaskList = "/projects/{0}/tasks";
        public const string CreateProject = "/project/create";

        public const string ViewSiteInformation = "/projects/{0}/site-information";
        public const string EditPermanentSiteInformation = "/projects/{0}/site-information/permanent/edit";
        public const string EditTemporarySiteInformation = "/projects/{0}/site-information/temporary/edit";

        public const string ViewSchoolTask = TaskList + "/school";
        public const string EditSchoolTask = ViewSchoolTask + "/edit";

        public const string ViewDatesTask = TaskList + "/dates";
        public const string EditDatesTask = ViewDatesTask + "/edit";

        public const string ViewTrustTask = TaskList + "/trust";
        public const string SearchTrustTask = ViewTrustTask + "/search";
        public const string EditTrustTask = ViewTrustTask + "/edit/{1}";

        public const string ViewConstituency = TaskList + "/constituency";
        public const string SearchConstituency = ViewConstituency + "/search";
        public const string EditConstituency = ViewConstituency + "/edit?search={1}";

        public const string ViewRegionAndLocalAuthorityTask = TaskList + "/region-and-localauthority";
        public const string EditRegion = ViewRegionAndLocalAuthorityTask + "/region/edit";
        public const string EditLocalAuthority = ViewRegionAndLocalAuthorityTask + "/localauthority/edit?region={1}";

        public const string ViewKickOffMeeting = TaskList + "/kickoffmeeting";
        public const string EditKickOffMeeting= ViewKickOffMeeting + "/edit";

        public const string ViewModelFundingAgreement = TaskList + "/Modelfundingagreement";
        public const string EditModelFundingAgreement = ViewModelFundingAgreement + "/edit";

        public const string ViewStatutoryConsultation = TaskList + "/statutoryconsultation";
        public const string EditStatutoryConsultation = ViewStatutoryConsultation + "/edit";

        public const string ViewArticlesOfAssociation = TaskList + "/articlesofassociation";
        public const string EditArticlesOfAssociation = ViewArticlesOfAssociation + "/edit";

        public const string ViewRiskAppraisalMeetingTask = TaskList + "/risk-appraisal-meeting";
        public const string EditRiskAppraisalMeetingTask = ViewRiskAppraisalMeetingTask + "/edit";

        public const string ViewFinancePlanTask = TaskList + "/finance-plan";
        public const string EditFinancePlanTask = ViewFinancePlanTask + "/edit";

        public const string ViewDraftGovernancePlanTask = TaskList + "/draft-governance-plan";
        public const string EditDraftGovernancePlanTask = ViewDraftGovernancePlanTask + "/edit";
        
        public const string ViewGiasTask = TaskList + "/gias";
        public const string EditGiasTask = ViewGiasTask + "/edit";
        
        public const string ViewEducationBriefTask = TaskList + "/education-brief";
        public const string EditEducationBriefTask = ViewEducationBriefTask + "/edit";

        public const string ViewAdmissionsArrangementsTask = TaskList + "/admissions-arrangements";
        public const string EditAdmissionsArrangementsTask = ViewAdmissionsArrangementsTask + "/edit";

        public const string ViewEqualitiesAssessmentTask = TaskList + "/equalitiesassessment";
        public const string EditEqualitiesAssessmentTask = ViewEqualitiesAssessmentTask + "/edit";
        
        public const string ViewImpactAssessmentTask = TaskList + "/impact-assessment";
        public const string EditImpactAssessmentTask = ViewImpactAssessmentTask + "/edit";
        
        public const string ViewAcceptedOffersEvidenceTask = TaskList + "/accepted-offers-evidence";
        public const string EditAcceptedOffersEvidenceTask = ViewAcceptedOffersEvidenceTask + "/edit";
        
        public const string ViewOfstedPreRegistrationTask = TaskList + "/ofsted-pre-registration";
        public const string EditBeforeOfstedInspectionTask = ViewOfstedPreRegistrationTask  + "/edit-before-inspection";
        public const string EditAfterOfstedInspectionTask = ViewOfstedPreRegistrationTask  + "/edit-after-inspection";
        
        public const string ViewApplicationsEvidenceTask = TaskList + "/applications-evidence";
        public const string EditApplicationsEvidenceTask = ViewApplicationsEvidenceTask + "/edit";

        public const string ViewFundingAgreementHealthCheckTask = TaskList + "/funding-agreement-health-check";
        public const string EditFundingAgreementHealthCheckTask = ViewFundingAgreementHealthCheckTask + "/edit";

        public const string ViewFinalFinancePlanTask = TaskList + "/final-finance-plan";
        public const string EditFinalFinancePlanTask = ViewFinalFinancePlanTask + "/edit";

        public const string CreateProjectMethod = CreateProject + "/method";
        public const string CreateProjectId = CreateProject + "/projectid";
        public const string CreateProjectSchool = CreateProject + "/school";
        public const string CreateProjectSchoolPhase = CreateProject + "/schoolphase";
        public const string CreateProjectRegion = CreateProject + "/region";
        public const string CreateProjectLocalAuthority = CreateProject + "/localauthority";
        public const string CreateProjectCheckYourAnswers = CreateProject + "/checkyouranswers";
        public const string CreateProjectConfirmation = CreateProject + "/confirmation";
        public const string CreateProjectSchoolType = CreateProject + "/school-type";
        public const string CreateProjectSearchTrust = CreateProject + "/trust/search";
        public const string CreateProjectAgeRange = CreateProject + "/age-range";
        public const string CreateProjectConfirmTrust = CreateProject + "/trust/confirm/{0}";
        public const string CreateProjectCapacity = CreateProject + "/capacity";
        public const string CreateProjectLead = CreateProject + "/projectlead";
        public const string CreateClassType = CreateProject + "/class-type";
        public const string CreateFormsOfEntry = CreateProject + "/forms-of-entry";
        public const string CreateProjectProvisionalOpeningDate = CreateProject + "/provisional-opening-date";

        public const string ProjectRiskSummary = "/projects/{0}/risk/summary";
        public const string ProjectRiskReview = "/projects/{0}/risk/add/review";
        public const string ProjectRiskConfirmation = "/projects/{0}/risk/add/confirmation?schoolName={1}";
        public const string CreateFaithStatus = CreateProject + "/faith-status";
        public const string CreateFaithType = CreateProject + "/faith-type";
        
        public const string ViewContacts = "/projects/{0}/contacts/other-info-contacts-landing-page";
        public const string ViewTrustChairContact = "/projects/{0}/contacts/other-info-contacts-multi-academy-trust-chair-of-governors-edit";
        public const string ViewSchoolChairContact = "/projects/{0}/contacts/other-info-contacts-school-chair-of-governors-edit";

        public const string ViewPDG = TaskList + "/pdg";
        public const string EditPDGPaymentSchedule = ViewPDG + "/edit-payment-schedule/";
        public const string EditPDGTrustLetter = ViewPDG + "/edit-trust-letter/";
        public const string EditStopPayment = ViewPDG + "/edit-stop-payment/";
        public const string EditRefunds = ViewPDG + "/edit-refunds/";
        public const string EditWriteOff = ViewPDG + "/edit-write-off/";

        public const string ViewPupilNumbers = "/projects/{0}/pupil-numbers";
        public const string EditCapacityWhenFull = ViewPupilNumbers + "/capacity-when-full/edit";
        public const string EditPre16PublishedAdmissionNumber = ViewPupilNumbers + "/pre16-published-admission-number/edit";
        public const string EditPost16PublishedAdmissionNumber = ViewPupilNumbers + "/post16-published-admission-number/edit";
        public const string EditRecruitmentAndViability = ViewPupilNumbers + "/recruitment-and-viability/edit";
        public const string EditPre16CapacityBuildup = ViewPupilNumbers + "/pre16-capacity-buildup/edit";
        public const string EditPost16CapacityBuildup = ViewPupilNumbers + "/post16-capacity-buildup/edit";
    }
}