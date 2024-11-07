using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks.SupplementalFundingAgreement
{
    public static class SupplementalFundingAgreementTaskBuilder
    {
        public static ConversionSupplementalFundingAgreementTask Execute(ConversionTasksData task)
        {
            return new ConversionSupplementalFundingAgreementTask()
            {
                Received = task.SupplementalFundingAgreementReceived,
                Cleared = task.SupplementalFundingAgreementCleared,
                Saved = task.SupplementalFundingAgreementSaved,
                Signed = task.SupplementalFundingAgreementSigned,
                Sent = task.SupplementalFundingAgreementSent,
                SignedSecretaryState = task.SupplementalFundingAgreementSignedSecretaryState,
            };
        }
    }
}
