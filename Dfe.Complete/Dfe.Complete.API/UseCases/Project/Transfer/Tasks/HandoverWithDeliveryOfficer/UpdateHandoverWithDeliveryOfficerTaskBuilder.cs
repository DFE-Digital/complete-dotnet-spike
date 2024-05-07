using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks.HandoverWithDeliveryOfficer
{
    public static class UpdateHandoverWithDeliveryOfficerTaskBuilder
    {
        public static void Execute(UpdateTransferTaskServiceParameters parameters)
        {
            var task = parameters.Request.HandoverWithDeliveryOfficer;
            var dbTransferTask = parameters.TransferTasksData;

            if (task == null)
            {
                return;
            }

            dbTransferTask.HandoverReview = task.ReviewProjectInformation;
            dbTransferTask.HandoverNotes = task.MakeNotes;
            dbTransferTask.HandoverMeeting = task.AttendHandoverMeeting;
            dbTransferTask.HandoverNotApplicable = task.NotApplicable;
        }
    }
}
