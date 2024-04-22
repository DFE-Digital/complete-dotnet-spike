using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.StatutoryConsultation
{
    public static class StatutoryConsultationTaskBuilder
    {
        public static StatutoryConsultationTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new StatutoryConsultationTask();
            }

            return new StatutoryConsultationTask()
            {
                ExpectedDateForReceivingFindingsFromTrust = milestones.FsgPreOpeningMilestonesScrForecastDate,
                DateReceived = milestones.FsgPreOpeningMilestonesScrActualDateOfCompletion,
                Comments = milestones.FsgPreOpeningMilestonesMi80CommentsOnDecisionToApproveIfApplicable,
                ReceivedConsultationFindingsFromTrust = milestones.FsgPreOpeningMilestonesScrReceived,
                ConsultationFulfilsTrustSection10StatutoryDuty = milestones.FsgPreOpeningMilestonesScrFulfilsSection10StatutoryDuty,
                SavedFindingsInWorkplacesFolder = milestones.FsgPreOpeningMilestonesScrSavedFindingsInWorkplacesFolder,
            };
        }
    }
}