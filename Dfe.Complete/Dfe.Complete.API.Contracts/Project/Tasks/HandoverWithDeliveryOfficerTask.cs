namespace Dfe.Complete.API.Contracts.Project.Tasks
{
    public class HandoverWithDeliveryOfficerTask : TaskBase
    {
        public bool? ReviewProjectInformation { get; set; }
        public bool? MakeNotes { get; set; }
        public bool? AttendHandoverMeeting { get; set; }
    }
}
