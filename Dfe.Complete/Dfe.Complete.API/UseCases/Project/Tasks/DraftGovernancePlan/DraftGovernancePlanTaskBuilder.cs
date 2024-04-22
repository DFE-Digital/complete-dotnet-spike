using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.DraftGovernancePlan
{
	public static class DraftGovernancePlanTaskBuilder
	{
		public static DraftGovernancePlanTask Build(Milestones milestones)
		{
			if (milestones == null)
			{
				return new DraftGovernancePlanTask();
			}

			return new DraftGovernancePlanTask()
			{
				SavedDocumentsInWorkplacesFolder = milestones.DraftGovernancePlanDocumentsSavedInWorkplacesFolder,
				PlanAndAssessmentSharedWithEsfa = milestones.DraftGovernancePlanAndAssessmentSharedWithEsfa,
				PlanAndAssessmentSharedWithExpert = milestones.DraftGovernancePlanAndAssessmentSharedWithExpert,
				PlanAssessedUsingTemplate = milestones.DraftGovernancePlanAssessedUsingTemplate,
				PlanFedBackToTrust = milestones.DraftGovernancePlanFedBackToTrust,
				PlanReceivedFromTrust = milestones.DraftGovernancePlanReceivedFromTrust,
				DatePlanReceived = milestones.FsgPreOpeningMilestonesDgpActualDateOfCompletion,
				Comments = milestones.FsgPreOpeningMilestonesMi60CommentsOnDecisionToApproveIfApplicable,
			};
		}
	}
}
