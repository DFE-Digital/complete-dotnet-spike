using Dfe.Complete.API.Contracts.Project.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Transfer.Tasks
{
    public record GetTransferProjectByTaskResponse : ProjectBaseResponse
    {
        public HandoverWithDeliveryOfficerTask HandoverWithDeliveryOfficer { get; set; }

        public StakeholderKickoffTask StakeholderKickoff { get; set; }
    }
}
