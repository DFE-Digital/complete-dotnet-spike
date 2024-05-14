using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.Data;

namespace Dfe.Complete.API.UseCases.Project
{
    public static class ProjectExtensions
    {
        public static IQueryable<Data.Entities.Project> GetTransferProjects(this CompleteContext context, Guid projectId)
        {
            var result = context.Projects.Where(p => p.Id == projectId && p.Type == ProjectType.Transfer);

            return result;
        }

        public static IQueryable<Data.Entities.Project> GetConversionProjects(this CompleteContext context, Guid projectId)
        {
            var result = context.Projects.Where(p => p.Id == projectId && p.Type == ProjectType.Conversion);

            return result;
        }
    }
}
