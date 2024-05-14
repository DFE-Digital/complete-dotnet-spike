using Dfe.Complete.API.Contracts.Project.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Transfer.Tasks
{
    public class GetTransferProjectByTaskSummaryResponse
    {
        public ProjectDetails ProjectDetails { get; set; }
        public TaskSummaryResponse HandoverWithDeliveryOfficer { get; set; } = new();
        public TaskSummaryResponse StakeholderKickoff { get; set; } = new();
    }
}
