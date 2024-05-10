using Dfe.Complete.API.Contracts.Project.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Conversion.Tasks
{
    public record GetConversionProjectByTaskResponse : ProjectBaseResponse
    {
        public HandoverWithDeliveryOfficerTask HandoverWithDeliveryOfficer { get; set; }
    }
}
