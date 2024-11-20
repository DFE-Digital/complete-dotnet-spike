using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks.LandQuestionnaire
{
    public static class LandQuestionnaireTaskBuilder
    {
        public static ConversionLandQuestionnaireTask Execute(ConversionTasksData task)
        {
            return new ConversionLandQuestionnaireTask()
            {
                Received = task.LandQuestionnaireReceived,
                Cleared = task.LandQuestionnaireCleared,
                Signed = task.LandQuestionnaireSigned,
                Saved = task.LandQuestionnaireSaved,
            };
        }
    }
}
