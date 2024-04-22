using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EqualitiesAssessment
{
    public static class EqualitiesAssessmentTaskBuilder
    {
        public static EqualitiesAssessmentTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new EqualitiesAssessmentTask();
            }

            return new EqualitiesAssessmentTask()
            {
                CompletedEqualitiesProcessRecord = milestones.EqualitiesAssessmentCompletedEPR,
                SavedEPRInWorkplacesFolder = milestones.EqualitiesAssessmentSavedEPRInWorkplacesFolder
            };
        }
    }
}