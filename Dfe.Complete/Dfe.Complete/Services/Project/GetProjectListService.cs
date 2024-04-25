using Dfe.Complete.API.Contracts.Common;
using Dfe.Complete.API.Contracts.Project;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project
{
    public interface IGetProjectListService
    {
        public Task<ApiListWrapper<ProjectListEntryResponse>> Execute(GetProjectListServiceParameters parameters);
    }

    public record GetProjectListServiceParameters
    {
        public ProjectStatusQueryParameter? Status { get; set; }

        public Guid? UserId { get; set; }

        public int Page { get; set; } = 1;

        public int Count { get; set; } = 20;
    }

    public class GetProjectListService : IGetProjectListService
    {
        private readonly CompleteApiClient _apiClient;

        public GetProjectListService(CompleteApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiListWrapper<ProjectListEntryResponse>> Execute(GetProjectListServiceParameters parameters)
        {
            QueryString query = new QueryString("");

            if (parameters.UserId.HasValue)
            {
                query = query.Add("userId", parameters.UserId.Value.ToString());
            }

            if (parameters.Status.HasValue)
            {
                query = query.Add("status", parameters.Status.Value.ToString());
            }

            query = query.Add("page", parameters.Page.ToString());
            query = query.Add("count", parameters.Count.ToString());

            var response = await _apiClient.Get<ApiListWrapper<ProjectListEntryResponse>>($"/api/v1/client/projects/list{query}");

            return response;
        }
    }
}
