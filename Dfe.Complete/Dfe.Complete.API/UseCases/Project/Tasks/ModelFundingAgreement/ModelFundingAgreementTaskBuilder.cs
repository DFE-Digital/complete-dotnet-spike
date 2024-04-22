using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ModelFundingAgreement
{
	public static class ModelFundingAgreementTaskBuilder
	{
		public static ModelFundingAgreementTask Build(Milestones milestones)
		{
			if (milestones == null)
			{
				return new ModelFundingAgreementTask();
			}

			return new ModelFundingAgreementTask()
			{
				TrustAgreesWithModelFA = milestones.FsgPreOpeningMilestonesMfadTrustAgreesWithModelFa,
				DraftedFAHealthCheck = milestones.FsgPreOpeningMilestonesMfadDraftedFaHealthCheck,
				DateTrustAgreesWithModelFA = milestones.FsgPreOpeningMilestonesMfadActualDateOfCompletion,
				Comments = milestones.FsgPreOpeningMilestonesMi58CommentsOnDecisionToApproveIfApplicable,
				SavedFADocumentsInWorkplacesFolder = milestones.FsgPreOpeningMilestonesMfadSavedFaDocumentsInWorkspacesFolder,
				TailoredAModelFundingAgreement = milestones.FsgPreOpeningMilestonesMfadTailoredAModelFundingAgreement,
				SharedFAWithTheTrust = milestones.FsgPreOpeningMilestonesMfadSharedFaWithTheTrust,
			};
		}
	}
}
