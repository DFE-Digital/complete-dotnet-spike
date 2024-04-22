using Dfe.ManageFreeSchoolProjects.API.Contracts.Users;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.User
{
    public interface ICreateUserService
    {
        public Task Execute(string email);
    }

    public class CreateUserService : ICreateUserService
    {
        private readonly MfspApiClient _apiClient;

        public CreateUserService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Execute(string email)
        {
            var request = new CreateUserRequest()
            {
                Email = email
            };

            await _apiClient.Post<CreateUserRequest, object>($"/api/v1/client/users/", request);
        }
    }
}
