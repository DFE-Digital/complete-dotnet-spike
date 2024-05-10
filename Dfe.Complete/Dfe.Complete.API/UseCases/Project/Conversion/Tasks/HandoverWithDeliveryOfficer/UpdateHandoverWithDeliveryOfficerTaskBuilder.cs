using Dfe.Complete.API.UseCases.Project.Transfer.Tasks;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.HandoverWithDeliveryOfficer
{
    public static class UpdateHandoverWithDeliveryOfficerTaskBuilder
    {
        public static void Execute(UpdateConversionTaskServiceParameters parameters)
        {
            var task = parameters.Request.HandoverWithDeliveryOfficer;
            var dbTransferTask = parameters.ConversionTasksData;

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
