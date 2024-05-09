using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Transfer
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class TransferProjectApiTests : ApiTestsBase
    {
        public TransferProjectApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Post_Returns_200()
        {
            var request = new CreateTransferProjectRequest();

            var response = await _client.PostAsync("api/v1/projects/transfer", request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var project = await response.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();

            project.Id.Should().NotBeEmpty();

            var testContext = _testFixture.GetContext();

            var dbProject = testContext.Projects.FirstOrDefault(p => p.Id == project.Id);
            dbProject.Should().NotBeNull();
        }
    }
}
