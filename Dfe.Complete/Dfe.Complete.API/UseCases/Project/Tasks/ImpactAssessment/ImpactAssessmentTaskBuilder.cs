using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ImpactAssessment
{
    public static class ImpactAssessmentTaskBuilder
    {
        public static ImpactAssessmentTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new ImpactAssessmentTask();
            }

            return new ImpactAssessmentTask()
            {
                ImpactAssessment = milestones.FsgPreOpeningMilestonesImpactAssessmentDone,
                SavedToWorkplaces = milestones.FsgPreOpeningMilestonesImpactAssessmentSavedToWorkplaces
            };
        }
    }
}