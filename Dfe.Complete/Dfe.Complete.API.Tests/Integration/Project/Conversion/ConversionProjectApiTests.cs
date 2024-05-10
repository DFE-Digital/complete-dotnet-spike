using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Conversion
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConversionProjectApiTests : ApiTestsBase
    {
        private const string ApiUrl = "api/v1/conversion-projects";

        public ConversionProjectApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Post_Returns_200()
        {
            var request = new CreateTransferProjectRequest();

            var response = await _client.PostAsync(ApiUrl, request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var project = await response.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();

            project.Id.Should().NotBeEmpty();

            var testContext = _testFixture.GetContext();

            var dbProject = testContext.Projects.FirstOrDefault(p => p.Id == project.Id);
            dbProject.Should().NotBeNull();
            dbProject.TasksDataType.Should().Be(TaskType.Conversion);
            dbProject.Type.Should().Be(ProjectType.Conversion);

            var task = testContext.ConversionTasksData.FirstOrDefault(t => t.Id == dbProject.TasksDataId);
            task.Should().NotBeNull();
        }
    }
}
