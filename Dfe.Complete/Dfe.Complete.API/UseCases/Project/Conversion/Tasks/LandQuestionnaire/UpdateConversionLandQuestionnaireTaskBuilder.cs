using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandQuestionnaire
{
    public static class UpdateConversionLandQuestionnaireTaskBuilder
    {
        public static void Execute(ConversionLandQuestionnaireTask task, ConversionTasksData dbTask)
        {
            dbTask.LandQuestionnaireReceived = task.Received;
            dbTask.LandQuestionnaireCleared = task.Cleared;
            dbTask.LandQuestionnaireSigned = task.Signed;
            dbTask.LandQuestionnaireSaved = task.Saved;
        }
    }
}
