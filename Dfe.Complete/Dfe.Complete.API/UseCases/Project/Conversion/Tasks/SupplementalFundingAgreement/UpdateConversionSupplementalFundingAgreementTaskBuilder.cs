using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.SupplementalFundingAgreement
{
    public static class UpdateConversionSupplementalFundingAgreementTaskBuilder
    {
        public static void Execute(ConversionSupplementalFundingAgreementTask task, ConversionTasksData dbTask)
        {
            dbTask.SupplementalFundingAgreementReceived = task.Received;
            dbTask.SupplementalFundingAgreementCleared = task.Cleared;
            dbTask.SupplementalFundingAgreementSigned = task.Signed;
            dbTask.SupplementalFundingAgreementSent = task.Sent;
            dbTask.SupplementalFundingAgreementSaved = task.Saved;
            dbTask.SupplementalFundingAgreementSignedSecretaryState = task.SignedSecretaryState;
        }
    }
}