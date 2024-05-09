using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.Data;

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
            var project = new Data.Entities.Project
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return new CreateTransferProjectResponse
            {
                Id = project.Id,
            };
        }
    }
}
