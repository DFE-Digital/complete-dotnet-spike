using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FinalFinancePlan
{
    public static class FinalFinancePlanTaskBuilder
    {
        public static FinalFinancePlanTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new FinalFinancePlanTask();
            }

            return new FinalFinancePlanTask()
            {
                ConfirmedTrustHasProvidedFinalPlan = milestones.FsgPreOpeningMilestonesFfpConfirmedTrustHasProvidedFinalPlan,
                Grade6SignedOffFinalPlanDate = milestones.FsgPreOpeningMilestonesFfpGrade6SignedOffFinalPlanDate,
                SentFinalPlanToRevenueFundingMailbox = milestones.FsgPreOpeningMilestonesFfpSentFinalPlanToRevenueFundingMailbox,
                SavedFinalPlanInWorkplacesFolder = milestones.FsgPreOpeningMilestonesFfpSavedFinalPlanInWorkplacesFolder
            };
        }

    }
}
