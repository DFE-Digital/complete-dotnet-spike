using Dfe.Complete.API.Contracts.Project.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Conversion.Tasks
{
    public class ConversionStakeholderKickoffTask : StakeholderKickoffTask
    {
        public bool? LocalAuthorityProforma { get; set; }

        public bool? LocalAuthorityAbleToConvert { get; set; }
    }
}
