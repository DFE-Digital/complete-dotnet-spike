using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Tasks.LandRegistry;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.LandRegistry
{
    public class ConversionLandRegistryTaskBuilder
    {
        public static ConversionLandRegistryTask Execute(ConversionTasksData task)
        {
            var updatedTask = LandRegistryTaskBuilder.Execute(task);

            var result = new ConversionLandRegistryTask()
            {
                Received = updatedTask.Received,
                Cleared = updatedTask.Cleared,
                Saved = updatedTask.Saved,
            };

            return result;
        }
    }
}
