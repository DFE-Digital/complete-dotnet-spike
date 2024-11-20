using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Tasks.LandQuestionnaire;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandQuestionnaire
{
    public class ConversionLandQuestionnaireTaskBuilder
    {
        public static ConversionLandQuestionnaireTask Execute(ConversionTasksData task)
        {
            var updatedTask = LandQuestionnaireTaskBuilder.Execute(task);

            var result = new ConversionLandQuestionnaireTask()
            {
                Received = updatedTask.Received,
                Cleared = updatedTask.Cleared,
                Signed = updatedTask.Signed,
                Saved = updatedTask.Saved,
            };

            return result;
        }
    }
}
