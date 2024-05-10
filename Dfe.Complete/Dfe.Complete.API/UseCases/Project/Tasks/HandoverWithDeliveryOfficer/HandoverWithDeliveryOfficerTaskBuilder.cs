using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer
{
    public static class HandoverWithDeliveryOfficerTaskBuilder
    {
        public static HandoverWithDeliveryOfficerTask Execute(IProjectTasksData task)
        {
            return new HandoverWithDeliveryOfficerTask
            {
                ReviewProjectInformation = task.HandoverReview,
                MakeNotes = task.HandoverNotes,
                AttendHandoverMeeting = task.HandoverMeeting,
                NotApplicable = task.HandoverNotApplicable
            };
        }
    }
}
