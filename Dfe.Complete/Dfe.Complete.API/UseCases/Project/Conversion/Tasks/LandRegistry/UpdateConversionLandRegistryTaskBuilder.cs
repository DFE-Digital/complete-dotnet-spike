using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandQuestionnaire
{
    public static class UpdateConversionLandRegistryTaskBuilder
    {
        public static void Execute(ConversionLandRegistryTask task, ConversionTasksData dbTask)
        {
            dbTask.LandRegistryReceived = task.Received;
            dbTask.LandRegistryCleared = task.Cleared;
            dbTask.LandRegistrySaved = task.Saved;
        }
    }
}
