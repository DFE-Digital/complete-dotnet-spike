using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;

namespace Dfe.ManageFreeSchoolProjects.Pages.Pagination
{
    public static class PaginationMapping
    {
        public static PaginationModel ToModel(PagingResponse paginationResponse)
        {
            if (paginationResponse == null)
            {
                return new PaginationModel();
            }

            var result = new PaginationModel()
            {
                Url = string.Empty,
                PageNumber = paginationResponse.Page,
                TotalPages = paginationResponse.TotalPages,
                Next = paginationResponse.HasNext ? paginationResponse.Page + 1 : null,
                Previous = paginationResponse.HasPrevious ? paginationResponse.Page - 1 : null,
                RecordCount = paginationResponse.RecordCount
            };

            return result;
        }
    }
}
