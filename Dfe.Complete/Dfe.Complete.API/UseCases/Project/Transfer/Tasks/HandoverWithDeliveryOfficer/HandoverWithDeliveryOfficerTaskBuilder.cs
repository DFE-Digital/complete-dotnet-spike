using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks.HandoverWithDeliveryOfficer
{
    public static class HandoverWithDeliveryOfficerTaskBuilder
    {
        public static HandoverWithDeliveryOfficerTask Execute(TransferTasksData task)
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
