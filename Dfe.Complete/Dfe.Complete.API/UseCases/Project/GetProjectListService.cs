using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Extensions;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project
{
    public interface IGetProjectListService
    {
        public Task<(List<ProjectListEntryResponse>, int)> Execute(GetProjectListServiceParameters parameters);
    }

    public record GetProjectListServiceParameters
    {
        public ProjectStatusQueryParameter? Status { get; set; }

        public Guid? UserId { get; set; }

        public int Page { get; set; }

        public int Count { get; set; }
    }

    public class GetProjectListService : IGetProjectListService
    {
        private readonly CompleteContext _context;
        private readonly IGetEstablishmentsBulkService _getEstablishmentBulkService;

        public GetProjectListService(
            CompleteContext context,
            IGetEstablishmentsBulkService getEstablishmentBulkService)
        {
            _context = context;
            _getEstablishmentBulkService = getEstablishmentBulkService;
        }

        public async Task<(List<ProjectListEntryResponse>, int)> Execute(GetProjectListServiceParameters parameters)
        {
            var filteredQuery = _context.Projects
                .Include(p => p.AssignedTo)
                .AsQueryable();

            filteredQuery = ApplyStatusFilter(filteredQuery, parameters.Status);
            filteredQuery = ApplyUserFilter(filteredQuery, parameters.UserId);

            var count = await filteredQuery.CountAsync();

            var queryResult = (from project in filteredQuery
                     join establishment in _context.GiasEstablishments on project.AcademyUrn equals establishment.Urn into joinedEstablishment
                     from establishment in joinedEstablishment.DefaultIfEmpty()
                     orderby project.SignificantDate
                     select new ProjectListEntryResponse()
                     {
                         Id = project.Id,
                         Urn = project.Urn,
                         ConversionOrTransferDate = project.SignificantDate,
                         ProjectType = project.Type,
                         AssignedTo = $"{project.AssignedTo.FirstName} {project.AssignedTo.LastName}",
                         SchoolOrAcademy = establishment.Name
                     }).AsQueryable();

            var result = await queryResult.Paginate(parameters.Page, parameters.Count).ToListAsync();

            var urns = result.Where(r => string.IsNullOrEmpty(r.SchoolOrAcademy)).Select(r => r.Urn).Distinct().ToArray();
            await SetEstablishmentName(result, urns);

            return (result, count);
        }

        private async Task SetEstablishmentName(List<ProjectListEntryResponse> result, int[] urns)
        {
            if (!urns.Any())
            {
                return;
            }

            var establishments = await _getEstablishmentBulkService.Execute(urns);

            var establishmentLookup = establishments.ToDictionary(e => e.Urn);

            foreach (var entry in result)
            {
                if (string.IsNullOrEmpty(entry.SchoolOrAcademy) && establishmentLookup.ContainsKey(entry.Urn.ToString()))
                {
                    entry.SchoolOrAcademy = establishmentLookup[entry.Urn.ToString()].Name;
                }
            }
        }

        private static IQueryable<Data.Entities.Project> ApplyUserFilter(IQueryable<Data.Entities.Project> query, Guid? userId)
        {
            if (userId == null)
            {
                return query;
            }

            query = query.Where(p => p.AssignedToId == userId);

            return query;
        }

        private static IQueryable<Data.Entities.Project> ApplyStatusFilter(IQueryable<Data.Entities.Project> query, ProjectStatusQueryParameter? status)
        {
            if (status == ProjectStatusQueryParameter.InProgress)
            {
                query = query.Where(p => p.State == ProjectState.Active && p.AssignedToId != null);
            }

            return query;
        }
    }
}
