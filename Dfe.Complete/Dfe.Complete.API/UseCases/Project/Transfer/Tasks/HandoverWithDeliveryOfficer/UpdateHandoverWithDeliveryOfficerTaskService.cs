using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks.HandoverWithDeliveryOfficer
{
    public class UpdateHandoverWithDeliveryOfficerTaskService : IUpdateTransferTaskService
    {
        private readonly CompleteContext _context;

        public UpdateHandoverWithDeliveryOfficerTaskService(CompleteContext context)
        {
            _context = context;
        }

        public void Execute(UpdateTransferTaskServiceParameters parameters)
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
