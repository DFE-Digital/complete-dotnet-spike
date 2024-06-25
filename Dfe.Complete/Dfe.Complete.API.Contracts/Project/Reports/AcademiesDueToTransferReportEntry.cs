using System.ComponentModel;

namespace Dfe.Complete.API.Contracts.Project.Reports
{
    public class AcademiesDueToTransferReportEntry
    {
        [DisplayName("School name")]
        public string SchoolName { get; set; }

        [DisplayName("School URN")]
        public string SchoolUrn { get; set; }

        [DisplayName("School phase")]
        public string SchoolPhase { get; set; }

        [DisplayName("School age range")]
        public string SchoolAgeRange { get; set; }

        [DisplayName("Local authority")]
        public string LocalAuthority { get; set; }

        [DisplayName("Transfer type")]
        public string TransferType { get; set; }

        [DisplayName("Outgoing trust name")]
        public string OutgoingTrustName { get; set; }

        [DisplayName("Outgoing trust companies house number")]
        public string OutgoingTrustCompaniesHouseNumber { get; set; }

        [DisplayName("Outgoing trust UKPRN")]
        public string OutgoingTrustUkprn { get; set; }

        [DisplayName("Incoming trust name")]
        public string IncomingTrustName { get; set; }

        [DisplayName("Incoming trust companies house number")]
        public string IncomingTrustCompaniesHouseNumber { get; set; }

        [DisplayName("Incoming trust UKPRN")]
        public string IncomingTrustUkprn { get; set; }

        [DisplayName("2RI (Two requires improvement)")]
        public string TwoRequiresImprovement { get; set; }

        [DisplayName("Transfer due to inadequate")]
        public string TransferDueToInadequate { get; set; }

        [DisplayName("Transfer due to financial safeguarding or governance")]
        public string TransferDueToIssues { get; set; }

        [DisplayName("Outgoing trust to close")]
        public string OutgoingTrustToClose { get; set; }

        [DisplayName("New URN/record requested")]
        public string NewUrnRequested { get; set; }

        [DisplayName("Bank details changing")]
        public string BankDetailsChanging { get; set; }

        [DisplayName("Region")]
        public string Region { get; set; }

        [DisplayName("Assigned to email")]
        public string AssignedToEmail { get; set; }

        [DisplayName("Team managing the project")]
        public string TeamManagingTheProject { get; set; }

        [DisplayName("Provisional transfer date")]
        public string ProvisionalTransferDate { get; set; }

        [DisplayName("Confirmed transfer date")]
        public string ConfirmedTransferDate { get; set; }

        [DisplayName("Authority to proceed")]
        public string AuthorityToProceed { get; set; }

        [DisplayName("Main contact name")]
        public string MainContactName { get; set; }

        [DisplayName("Main contact email")]
        public string MainContactEmail { get; set; }

        [DisplayName("Main contact role")]
        public string MainContactRole { get; set; }
    }
}
