using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Conversion.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConversionSupplementalFundingAgreementApiTest : ApiTestsBase
    {
        public ConversionSupplementalFundingAgreementApiTest(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_SupplementalFundingAgreementTask_Returns_200()
        {
            var createProjectRequest = new CreateConversionProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var project = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();

            var request = new UpdateConversionProjectByTaskRequest()
            {
                SupplementalFundingAgreement = new ConversionSupplementalFundingAgreementTask()
                {
                    Received = true,
                    Cleared = true,
                    Signed = true,
                    Saved = true,
                    Sent = true,
                    SignedSecretaryState = true,
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}?taskName={ConversionProjectTaskName.SupplementalFundingAgreement}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedTask = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskResponse>();

            updatedTask.SupplementalFundingAgreement.Received.Should().BeTrue();
            updatedTask.SupplementalFundingAgreement.Cleared.Should().BeTrue();
            updatedTask.SupplementalFundingAgreement.Signed.Should().BeTrue();
            updatedTask.SupplementalFundingAgreement.Saved.Should().BeTrue();
            updatedTask.SupplementalFundingAgreement.Sent.Should().BeTrue();
            updatedTask.SupplementalFundingAgreement.SignedSecretaryState.Should().BeTrue();
        }

        [Fact]
        public async Task Get_SupplementalFundingAgreement_TaskSummary_Returns_200()
        {
            var createProjectRequest = new CreateConversionProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();
            var projectId = createdProject.Id;

            var request = new UpdateConversionProjectByTaskRequest()
            {
                SupplementalFundingAgreement = new()
                {
                    Received = true,
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTaskSummary, projectId)}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var summary = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskSummaryResponse>();

            summary.SupplementalFundingAgreement.Status.Should().Be(ProjectTaskStatus.InProgress);
        }
    }
}
