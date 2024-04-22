using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EducationBrief
{
    public static class EducationBriefTaskBuilder
    {
        public static EducationBriefTask Build(Milestones milestones)
        {
            return new EducationBriefTask()
            {
                EducationPlanInEducationBrief = milestones?.FSGPreOpeningMilestonesEducationPlanInBrief,
                EducationPolicesInEducationBrief = milestones?.FSGPreOpeningMilestonesEducationPolicesInBrief,
                PupilAssessmentAndTrackingHistoryInPlace = milestones?.FSGPreOpeningMilestonesEducationBriefPupilAssessmentAndTrackingHistory,
                EducationBriefSavedToWorkplaces = milestones?.FSGPreOpeningMilestonesEducationBriefSavedToWorkplaces
            };
        }
    }
}