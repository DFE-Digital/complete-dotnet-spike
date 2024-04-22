using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FinancePlan
{
    public static class FinancePlanTaskBuilder
    {
        public static FinancePlanTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new FinancePlanTask();
            }

            return new FinancePlanTask()
            {
                FinancePlanAgreed = ConvertYesNo(milestones.FsgPreOpeningMilestonesBefpApplicable),
                DateAgreed = milestones.FsgPreOpeningMilestonesBefpActualDateOfCompletion,
                PlanSavedInWorksplacesFolder = milestones.FinancePlanSavedInWorkplacesFolder,
                LocalAuthorityAgreedPupilNumbers = milestones.LAAgreedPupilNumbers,
                Comments = milestones.FsgPreOpeningMilestonesMi72CommentsOnDecisionToApproveIfApplicable,
                TrustWillOptIntoRpa = milestones.TrustOptInRPA,
                RpaStartDate = milestones.RPAStartDate,
                RpaCoverType = milestones.RPACoverType
            };
        }

        private static YesNo? ConvertYesNo(string value)
        {
            return Enum.TryParse<YesNo>(value, true, out var result) ? result : null;
        }
    }
}
