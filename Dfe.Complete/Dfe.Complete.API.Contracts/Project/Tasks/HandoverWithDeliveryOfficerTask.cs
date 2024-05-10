namespace Dfe.Complete.API.Contracts.Project.Tasks
{
    public class HandoverWithDeliveryOfficerTask : INotApplicableTask
    {
        public bool? ReviewProjectInformation { get; set; }
        public bool? MakeNotes { get; set; }
        public bool? AttendHandoverMeeting { get; set; }
        public bool? NotApplicable { get; set; }

    }
}
