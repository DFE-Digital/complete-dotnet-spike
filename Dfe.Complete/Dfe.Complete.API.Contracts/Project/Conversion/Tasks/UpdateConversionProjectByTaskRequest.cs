using Dfe.Complete.API.Contracts.Project.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Conversion.Tasks
{
    public class UpdateConversionProjectByTaskRequest
    {
        public HandoverWithDeliveryOfficerTask HandoverWithDeliveryOfficer { get; set; }

        public ConversionStakeholderKickoffTask StakeholderKickoff { get; set; }
    }
}
