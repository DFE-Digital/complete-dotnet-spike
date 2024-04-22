using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ArticlesOfAssociation
{
    public static class ArticlesOfAssociationTaskBuilder
    {
        public static ArticlesOfAssociationTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new ArticlesOfAssociationTask();
            }

            return new ArticlesOfAssociationTask()
            {
                CheckedSubmittedArticlesMatch = milestones.MAACheckedSubmittedArticlesMatch,
                ChairHaveSubmittedConfirmation = milestones.MAAChairHaveSubmittedConfirmation,
                ArrangementsMatchGovernancePlans = milestones.MAAArrangementsMatchGovernancePlans,
                ForecastDate = milestones.FsgPreOpeningMilestonesMaaForecastDate,
                ActualDate = milestones.FsgPreOpeningMilestonesMaaActualDateOfCompletion,
                CommentsOnDecision = milestones.FsgPreOpeningMilestonesMi56CommentsOnDecisionToApproveIfApplicable,
                SharepointLink = milestones.FsgPreOpeningMilestonesMi107LinkToSavedDocument
            };
        }
    }
}
