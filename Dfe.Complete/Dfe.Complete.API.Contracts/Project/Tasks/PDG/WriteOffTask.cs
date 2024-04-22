namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG
{
    public class WriteOffTask
    {
        public string WriteOffReason { get; set; }
        public decimal? WriteOffAmount { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public string FinanceBusinessPartnerApprovalReceivedFrom { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }
}
