namespace Dfe.ManageFreeSchoolProjects.API.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int count)
        {
            return query.Skip((page - 1) * count).Take(count);
        }
    }
}
