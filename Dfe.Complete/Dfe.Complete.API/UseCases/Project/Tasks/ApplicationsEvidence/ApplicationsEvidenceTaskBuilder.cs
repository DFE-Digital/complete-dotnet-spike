using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ApplicationsEvidence
{
    public static class ApplicationsEvidenceTaskBuilder
    {
        public static ApplicationsEvidenceTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new ApplicationsEvidenceTask();
            }

            return new ApplicationsEvidenceTask()
            {
                ConfirmedPupilNumbers = milestones.FsgPreOpeningMilestonesApplicationsEvidenceConfirmedPupilNumbers,
                Comments = milestones.FsgPreOpeningMilestonesApplicationsEvidenceComments,
                BuildUpFormSavedToWorkplaces = milestones.FsgPreOpeningMilestonesApplicationsEvidenceBuildUpFormSavedToWorkplaces,
                UnderwritingAgreementSavedToWorkplaces = milestones.FsgPreOpeningMilestonesApplicationsEvidenceUnderwritingAgreementSavedToWorkplaces
            };
        }
    }
}
