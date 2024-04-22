using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Gias
{
	public static class GiasTaskBuilder
	{
		public static GiasTask Build(Milestones milestones)
		{
			if (milestones == null)
			{
				return new GiasTask();
			}

			return new GiasTask()
			{
				CheckedTrustInformation = milestones.FSGPreOpeningMilestonesGIASCheckedTrustInformation,
				ApplicationFormSent = milestones.FSGPreOpeningMilestonesGIASApplicationFormSent,
				SavedToWorkspaces = milestones.FSGPreOpeningMilestonesGIASSavedToWorkspaces,
				UrnSent = milestones.FSGPreOpeningMilestonesGIASURNSent
			};
		}
	}
}
