using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public class FundingAgreementHealthCheckTask
    {
        public bool? DraftedFundingAgreementHealthCheck { get; set; }
        public bool? RegionalDirectorSignedOffFundingAgreementHealthCheck { get; set; }
        public bool? MinisterSignedOffFundingAgreementHealthCheck { get; set; }
        public bool? SavedFundingAgreementHealthCheckInWorkplacesFolder { get; set; }
    }
}
