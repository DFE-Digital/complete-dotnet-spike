using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Tasks;
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
        private const string ApiUrl = "api/v1/transfer-projects";

        public TransferProjectApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Post_Returns_200()
        {
            var request = _autoFixture.Create<CreateTransferProjectRequest>();

            var response = await _client.PostAsync(ApiUrl, request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var project = await response.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();

            project.Id.Should().NotBeEmpty();

            var testContext = _testFixture.GetContext();

            var dbProject = testContext.Projects.FirstOrDefault(p => p.Id == project.Id);
            dbProject.Should().NotBeNull();
            dbProject.TasksDataType.Should().Be(TaskType.Transfer);
            dbProject.Type.Should().Be(ProjectType.Transfer);
            dbProject.SignificantDate.Value.Date.Should().Be(request.Date.Value.Date);
            dbProject.SignificantDateProvisional.Should().Be(request.IsDateProvisional);
            dbProject.OutgoingTrustUkprn.Should().Be(request.OutgoingTrustUkprn);
            dbProject.IncomingTrustUkprn.Should().Be(request.IncomingTrustUkprn);
            dbProject.Region.Should().Be(request.Region);

            var task = testContext.TransferTasksData.FirstOrDefault(t => t.Id == dbProject.TasksDataId);
            task.Should().NotBeNull();
        }
    }
}
