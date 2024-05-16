using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Extensions;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion
{
    public interface ICreateConversionProjectService
    {
        public Task<CreateConversionProjectResponse> Execute(CreateConversionProjectRequest request);
    }

    public class CreateConversionProjectService : ICreateConversionProjectService
    {
        private readonly CompleteContext _context;

        public CreateConversionProjectService(CompleteContext context)
        {
            _context = context;
        }

        public async Task<CreateConversionProjectResponse> Execute(CreateConversionProjectRequest request)
        {
            var projectId = Guid.NewGuid();
            var taskId = Guid.NewGuid();

            var project = new Data.Entities.Project
            {
                Id = projectId,
                Urn = request.Urn.ToInt(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                TasksDataType = TaskType.Conversion,
                Type = ProjectType.Conversion,
                TasksDataId = taskId,
                SignificantDate = request.Date,
                SignificantDateProvisional = request.IsDateProvisional,
                IncomingTrustUkprn = request.IncomingTrustUkprn.ToInt(),
                Region = request.Region,
                TwoRequiresImprovement = request.IsIsDueTo2RI,
                DirectiveAcademyOrder = request.HasAcademyOrderBeenIssued,
                AdvisoryBoardDate = request.AdvisoryBoardDate,
                AdvisoryBoardConditions = request.AdvisoryBoardConditions,
                EstablishmentSharepointLink = request.EstablishmentSharePointLink,
                IncomingTrustSharepointLink = request.IncomingTrustSharePointLink,
            };

            var task = new ConversionTasksData
            {
                Id = taskId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.ConversionTasksData.Add(task);
            _context.Projects.Add(project);

            await _context.SaveChangesAsync();

            return new CreateConversionProjectResponse
            {
                Id = project.Id,
            };
        }
    }
}
