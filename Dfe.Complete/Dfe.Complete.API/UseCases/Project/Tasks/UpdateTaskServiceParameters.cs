using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks
{
    public class UpdateTaskServiceParameters
    {
        public UpdateConversionProjectByTaskRequest Request { get; set; }

        public ConversionTasksData ConversionTasksData { get; set; }
    }
}
