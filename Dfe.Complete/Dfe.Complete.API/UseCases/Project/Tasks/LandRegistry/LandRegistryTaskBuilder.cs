using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks.LandRegistry
{
    public static class LandRegistryTaskBuilder
    {
        public static ConversionLandRegistryTask Execute(ConversionTasksData task)
        {
            return new ConversionLandRegistryTask()
            {
                Received = task.LandRegistryReceived,
                Cleared = task.LandRegistryCleared,
                Saved = task.LandRegistrySaved,
            };
        }
    }
}
