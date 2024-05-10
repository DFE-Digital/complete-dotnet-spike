using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public interface IUpdateConversionProjectByTaskService
    {
        public Task Execute(Guid projectId, UpdateConversionProjectByTaskRequest request);
    }

    public class UpdateConversionProjectByTaskService : IUpdateConversionProjectByTaskService
    {
        private readonly CompleteContext _context;

        public UpdateConversionProjectByTaskService(
            CompleteContext context)
        {
            _context = context;
        }

        public async Task Execute(Guid projectId, UpdateConversionProjectByTaskRequest request)
        {
            var queryResult = await _context.GetConversionProjects(projectId).FirstOrDefaultAsync();

            if (queryResult == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var transferTaskData = await _context.ConversionTasksData.FirstOrDefaultAsync(t => t.Id == queryResult.Project.TasksDataId);

            if (transferTaskData == null)
            {
                throw new UnprocessableContentException($"Project with id {projectId} does not have any conversion tasks data");
            }

            var updateTaskParameters = new UpdateConversionTaskServiceParameters
            {
                Request = request,
                ConversionTasksData = transferTaskData
            };

            UpdateHandoverWithDeliveryOfficerTaskBuilder.Execute(updateTaskParameters);

            await _context.SaveChangesAsync();
        }
    }
}
