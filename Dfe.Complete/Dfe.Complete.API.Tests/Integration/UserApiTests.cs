using Dfe.Complete.API.Contracts.User;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class UserApiTests : ApiTestsBase
    {
        public UserApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task When_Post_UserDoesNotExist_CreatesUser_Returns_201()
        {
            var request = _autoFixture.Create<CreateUserRequest>();
            request.Email = request.Email.ToUpper() + " ";

            var result = await _client.PostAsync($"/api/v1/client/users", request.ConvertToJson());

            result.StatusCode.Should().Be(HttpStatusCode.Created);

            using var context = _testFixture.GetContext();

            var createdUser = context.Users.First(u => u.Email == request.Email);

            createdUser.Email.Should().Be(request.Email.ToLower().Trim());
            createdUser.Id.Should().NotBeEmpty();
        }

        [Fact]
        public async Task When_Post_UserExists_DoesNotCreateUser_Returns_409()
        {
            var request = _autoFixture.Create<CreateUserRequest>();

            await _client.PostAsync($"/api/v1/client/users", request.ConvertToJson());

            var secondPost = await _client.PostAsync($"/api/v1/client/users", request.ConvertToJson());
            secondPost.StatusCode.Should().Be(HttpStatusCode.Conflict);

            var content = await secondPost.Content.ReadAsStringAsync();

            content.Should().Contain("User with email already exists, no record has been created");
        }

        [Fact]
        public async Task When_Post_EmailNotProvided_Returns_400()
        {
            var request = new CreateUserRequest();

            var result = await _client.PostAsync($"/api/v1/client/users", request.ConvertToJson());
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            string error = await result.Content.ReadAsStringAsync();

            error.Should().Contain("'Email' must not be empty");
        }
    }
}
