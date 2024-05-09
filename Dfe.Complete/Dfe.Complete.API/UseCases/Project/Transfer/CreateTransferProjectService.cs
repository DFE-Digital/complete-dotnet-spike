using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Transfer
{
    public interface ICreateTransferProjectService
    {
        public Task<CreateTransferProjectResponse> Execute(CreateTransferProjectRequest request);
    }

    public class CreateTransferProjectService : ICreateTransferProjectService
    {
        private readonly CompleteContext _context;

        public CreateTransferProjectService(CompleteContext context)
        {
            _context = context;
        }

        public async Task<CreateTransferProjectResponse> Execute(CreateTransferProjectRequest request)
        {
            var projectId = Guid.NewGuid();
            var taskId = Guid.NewGuid();

            var project = new Data.Entities.Project
            {
                Id = projectId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                TasksDataType = TaskType.Transfer,
                Type = ProjectType.Transfer,
                TasksDataId = taskId,
            };

            var task = new TransferTasksData
            {
                Id = taskId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.TransferTasksData.Add(task);
            _context.Projects.Add(project);

            await _context.SaveChangesAsync();

            return new CreateTransferProjectResponse
            {
                Id = project.Id,
            };
        }
    }
}
