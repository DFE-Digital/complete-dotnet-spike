using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks
{
    public record GetTransferTaskServiceParameters
    {
        public TransferTasksData TransferTasksData { get; set; }
    }
}
