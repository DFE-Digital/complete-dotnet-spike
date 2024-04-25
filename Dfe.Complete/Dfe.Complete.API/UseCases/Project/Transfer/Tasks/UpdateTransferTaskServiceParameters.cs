using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks
{
    public record UpdateTransferTaskServiceParameters
    {
        public UpdateTransferProjectByTaskRequest Request { get; set; }

        public TransferTasksData TransferTasksData { get; set; }
    }
}
