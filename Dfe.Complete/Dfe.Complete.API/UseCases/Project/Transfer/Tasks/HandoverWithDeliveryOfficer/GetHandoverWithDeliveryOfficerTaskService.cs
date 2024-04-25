using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks.HandoverWithDeliveryOfficer
{
    public class GetHandoverWithDeliveryOfficerTaskService
    {
        public HandoverWithDeliveryOfficerTask Execute(GetTransferTaskServiceParameters parameters)
        {
            var task = parameters.TransferTasksData;

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
