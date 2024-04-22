using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FundingAgreementHealthCheck
{
    public static class FundingAgreementHealthCheckTaskBuilder
    {
        public static FundingAgreementHealthCheckTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new FundingAgreementHealthCheckTask();
            }

            return new FundingAgreementHealthCheckTask()
            {
                DraftedFundingAgreementHealthCheck = milestones.FsgPreOpeningMilestonesMfadDraftedFaHealthCheck,
                RegionalDirectorSignedOffFundingAgreementHealthCheck = milestones.FsgPreOpeningMilestonesMfadRegionalDirectorSignedOffFaHealthCheck,
                MinisterSignedOffFundingAgreementHealthCheck = milestones.FsgPreOpeningMilestonesMfadMinisterSignedOffFaHealthCheck,
                SavedFundingAgreementHealthCheckInWorkplacesFolder = milestones.FsgPreOpeningMilestonesMfadSavedFaHealthCheckInWorkplacesFolder
            };

        }
    }
}
