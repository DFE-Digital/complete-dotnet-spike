using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG
{
    public class PDGDashboard
    {
        public decimal? PaymentScheduleAmount{ get; set; }
        public DateTime? PaymentScheduleDate { get; set; }
        public decimal? PaymentActualAmount { get; set; }
        public DateTime? PaymentActualDate { get; set; }
        public DateTime? TrustSignedPDGLetterDate { get; set; }
        public bool? PDGLetterSavedInWorkspaces { get; set; }
        public string PaymentStopped { get; set; }
        public DateTime? LatestRefundDate { get; set; }
        public decimal? RefundsTotalAmount { get; set; }
        public string WriteOffReason { get; set; }
        public decimal? WriteOffAmount { get; set; }
    }
}
