using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Tasks.SupplementalFundingAgreement;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.SupplementalFundingAgreement
{
    public class ConversionSupplementalFundingAgreementTaskBuilder
    {
        public static ConversionSupplementalFundingAgreementTask Execute(ConversionTasksData task)
        {
            var updatedTask = SupplementalFundingAgreementTaskBuilder.Execute(task);

            var result = new ConversionSupplementalFundingAgreementTask()
            {
                Received = updatedTask.Received,
                Cleared = updatedTask.Cleared,
                Signed = updatedTask.Signed,
                Saved = updatedTask.Saved,
                Sent = updatedTask.Sent,
                SignedSecretaryState = updatedTask.SignedSecretaryState,
            };

            return result;
        }
    }
}
