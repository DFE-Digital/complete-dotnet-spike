using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EvidenceOfAcceptedOffers
{
    public static class EvidenceOfAcceptedOffersTaskBuilder
    {
        public static EvidenceOfAcceptedOffersTask Build(Milestones milestones)
        {
            if (milestones == null)
            {
                return new EvidenceOfAcceptedOffersTask();
            }

            return new EvidenceOfAcceptedOffersTask()
            {
                EvidenceOfAcceptedOffers = milestones.FsgPreOpeningMilestonesSeenEvidenceOfAcceptedOffers,
                Comments = milestones.FsgPreOpeningMilestonesAcceptedOffersComments,
                SavedToWorkplaces = milestones.FsgPreOpeningMilestonesAcceptedOffersEmailSavedToWorkplaces
            };
        }
    }
}
