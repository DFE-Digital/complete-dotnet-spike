namespace Dfe.Complete.Constants
{
    public static class RouteConstants
    {
        public const string ProjectsInProgress = "/projects/all/in-progress/all";

        // Project
        public const string Project = "/projects/{0}";
        public const string CreateNewProject = "/projects/CreateNewProject";
        
        public const string ProjectViewNotes = Project + "/notes";
        public const string ProjectAddNote = ProjectViewNotes + "/edit";
        public const string ProjectEditNote = ProjectViewNotes + "/{1}/edit";

        // Conversion
        public const string ConversionProject = "/conversion-projects/{0}";
        public const string CreateNewConversionProject = "/projects/conversion-projects/new";
        public const string ConversionProjectTaskList = ConversionProject + "/tasks";
        public const string ConversionProjectAbout = ConversionProject + "/information";

        public const string ConversionViewHandoverWithDeliveryOfficerTask = ConversionProjectTaskList + "/handover";
        public const string ConversionEditHandoverWithDeliveryOfficerTask = ConversionViewHandoverWithDeliveryOfficerTask + "/edit";

        public const string ConversionStakeholderKickoffTask = ConversionProjectTaskList + "/stakeholder-kickoff";
        public const string ConversionEditStakeholderKickoffTask = ConversionStakeholderKickoffTask + "/edit";

        public const string ConversionLandQuestionnaireTask = ConversionProjectTaskList + "/land-questionnaire";
        public const string ConversionEditLandQuestionnaireTask = ConversionLandQuestionnaireTask + "/edit";

        public const string ConversionLandRegistryTask = ConversionProjectTaskList + "/land-registry";
        public const string ConversionEditLandRegistryTask = ConversionLandRegistryTask + "/edit";

        public const string ConversionSupplementalFundingAgreementTask = ConversionProjectTaskList + "/supplemental-funding-agreement";
        public const string ConversionEditSupplementalFundingAgreementTask = ConversionSupplementalFundingAgreementTask + "/edit";

        // Transfer
        public const string TransferProject = "/transfer-projects/{0}";
        public const string TransferProjectTaskList = TransferProject + "/tasks";
        public const string TransferProjectAbout = TransferProject + "/information";
        public const string TransferProjectEditAbout = TransferProjectAbout + "/edit";

        public const string TransferViewHandoverWithDeliveryOfficerTask = TransferProjectTaskList + "/handover";
        public const string TransferEditHandoverWithDeliveryOfficerTask = TransferViewHandoverWithDeliveryOfficerTask + "/edit";

        public const string TransferViewStakeholderKickoffTask = TransferProjectTaskList + "/stakeholder-kickoff";
        public const string TransferEditStakeholderKickoffTask = TransferViewStakeholderKickoffTask + "/edit";
    }
}