using Dfe.Complete.API.Contracts.Project.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Conversion.Tasks
{
    public class UpdateConversionProjectByTaskRequest
    {
        public HandoverWithDeliveryOfficerTask HandoverWithDeliveryOfficer { get; set; }

        public ConversionStakeholderKickoffTask StakeholderKickoff { get; set; }

        public ConversionLandQuestionnaireTask LandQuestionnaire { get; set;}

        public ConversionLandRegistryTask LandRegistry { get; set; }

        public ConversionSupplementalFundingAgreementTask SupplementalFundingAgreement { get; set; }
    }
}
