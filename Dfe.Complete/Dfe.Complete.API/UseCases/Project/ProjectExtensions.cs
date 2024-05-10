using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project
{
    public static class ProjectExtensions
    {
        public static IQueryable<ProjectWithEstablishment> GetTransferProjects(this CompleteContext context, Guid projectId)
        {
            var result = (from project in context.Projects
                          join establishment in context.GiasEstablishments on project.AcademyUrn equals establishment.Urn into joinedEstablishment
                          from establishment in joinedEstablishment.DefaultIfEmpty()
                          where project.Id == projectId && project.Type == ProjectType.Transfer
                          select new ProjectWithEstablishment
                          {
                              Project = project,
                              Establishment = establishment
                          });

            return result;
        }

        public static IQueryable<ProjectWithEstablishment> GetConversionProjects(this CompleteContext context, Guid projectId)
        {
            var result = (from project in context.Projects
                          join establishment in context.GiasEstablishments on project.AcademyUrn equals establishment.Urn into joinedEstablishment
                          from establishment in joinedEstablishment.DefaultIfEmpty()
                          where project.Id == projectId && project.Type == ProjectType.Conversion
                          select new ProjectWithEstablishment
                          {
                              Project = project,
                              Establishment = establishment
                          });

            return result;
        }
    }
}
