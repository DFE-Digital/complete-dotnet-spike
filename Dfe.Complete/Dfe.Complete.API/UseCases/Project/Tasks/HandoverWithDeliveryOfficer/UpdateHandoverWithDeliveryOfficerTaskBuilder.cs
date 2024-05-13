using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer
{
    public static class UpdateHandoverWithDeliveryOfficerTaskBuilder
    {
        public static void Execute(HandoverWithDeliveryOfficerTask task, IProjectTasksData dbTask)
        {
            dbTask.HandoverReview = task.ReviewProjectInformation;
            dbTask.HandoverNotes = task.MakeNotes;
            dbTask.HandoverMeeting = task.AttendHandoverMeeting;
            dbTask.HandoverNotApplicable = task.NotApplicable;
        }
    }
}
