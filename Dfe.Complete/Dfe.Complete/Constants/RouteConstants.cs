namespace Dfe.Complete.Constants
{
    public static class RouteConstants
    {
        public const string ProjectsInProgress = "/projects/all/in-progress/all";

        // Conversion
        public const string ConversionProject = "/conversion-projects/{0}";
        public const string ConversionProjectTaskList = "/conversion-projects/{0}/tasks";
        public const string ConversionProjectAbout = "/conversion-projects/{0}/information";

        public const string ConversionViewHandoverWithDeliveryOfficerTask = ConversionProjectTaskList + "/handover";
        public const string ConversionEditHandoverWithDeliveryOfficerTask = ConversionViewHandoverWithDeliveryOfficerTask + "/edit";

        // Transfer
        public const string TransferProject = "/transfer-projects/{0}";
        public const string TransferProjectTaskList = TransferProject + "/tasks";
        public const string AboutTransferProject = TransferProject + "/information";
        public const string EditAboutTransferProject = AboutTransferProject + "/edit";

        public const string TransferViewHandoverWithDeliveryOfficerTask = TransferProjectTaskList + "/handover";
        public const string TransferEditHandoverWithDeliveryOfficerTask = TransferViewHandoverWithDeliveryOfficerTask + "/edit";

        public const string TransferViewStakeholderKickoffTask = TransferProjectTaskList + "/stakeholder-kickoff";
        public const string TransferEditStakeholderKickoffTask = TransferViewStakeholderKickoffTask + "/edit";
    }
}