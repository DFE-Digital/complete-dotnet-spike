using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public interface IGetConversionProjectByTaskService
    {
        public Task<GetConversionProjectByTaskResponse> Execute(Guid projectId, ConversionProjectTaskName taskName);
    }

    public class GetConversionProjectByTaskService : IGetConversionProjectByTaskService
    {
        private readonly CompleteContext _context;
        private readonly ISetProjectSchoolNameService _setProjectSchoolNameService;

        public GetConversionProjectByTaskService(
            CompleteContext context,
            ISetProjectSchoolNameService setProjectSchoolNameService)
        {
            _context = context;
            _setProjectSchoolNameService = setProjectSchoolNameService;
        }

        public async Task<GetConversionProjectByTaskResponse> Execute(Guid projectId, ConversionProjectTaskName taskName)
        {
            var queryResult = await _context.GetConversionProjects(projectId).FirstOrDefaultAsync();

            if (queryResult == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var conversionTaskData = await _context.ConversionTasksData.FirstOrDefaultAsync(t => t.Id == queryResult.Project.TasksDataId);

            if (conversionTaskData == null)
            {
                conversionTaskData = new Data.Entities.ConversionTasksData();
            }

            GetConversionProjectByTaskResponse response = new GetConversionProjectByTaskResponse()
            {
                Urn = queryResult.Project.Urn,
                SchoolName = queryResult.Establishment?.Name,
            };

            await _setProjectSchoolNameService.Execute(response);

            switch (taskName)
            {
                case ConversionProjectTaskName.HandoverWithDeliveryOfficer:
                    response.HandoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(conversionTaskData);
                    break;

                default:
                    throw new ArgumentException($"Unknown project transfer task name {taskName}");
            }

            return response;
        }
    }
}
