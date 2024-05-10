using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public record UpdateConversionTaskServiceParameters
    {
        public UpdateConversionProjectByTaskRequest Request { get; set; }

        public ConversionTasksData ConversionTasksData { get; set; }
    }
}
