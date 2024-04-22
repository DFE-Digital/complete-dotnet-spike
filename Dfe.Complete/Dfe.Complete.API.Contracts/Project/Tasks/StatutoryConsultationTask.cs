namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public class StatutoryConsultationTask
    {
        public DateTime? ExpectedDateForReceivingFindingsFromTrust { get; set; }

        public bool? ReceivedConsultationFindingsFromTrust { get; set; }

        public DateTime? DateReceived { get; set; }

        public bool? ConsultationFulfilsTrustSection10StatutoryDuty {  get; set; }

        public string Comments { get; set; }

        public bool? SavedFindingsInWorkplacesFolder { get; set; }
    }
}
