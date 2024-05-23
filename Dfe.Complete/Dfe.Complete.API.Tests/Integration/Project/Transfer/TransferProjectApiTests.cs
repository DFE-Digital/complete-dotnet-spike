using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using Dfe.Complete.Data.Entities;
using System;
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
            var createProjectRequest = _autoFixture.Create<CreateTransferProjectRequest>();
            createProjectRequest.Region = Region.NorthWest;
            createProjectRequest.Urn = "1001";
            createProjectRequest.IncomingTrustDetails.Ukprn = "10000001";
            createProjectRequest.OutgoingTrustDetails.Ukprn = "10000002";

            var response = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var createProjectResponse = await response.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();

            createProjectResponse.Id.Should().NotBeEmpty();

            var getProjectResponse = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectById, createProjectResponse.Id)}");
            getProjectResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var project = await getProjectResponse.Content.ReadFromJsonAsync<GetTransferProjectResponse>();

            // Project details
            project.ProjectDetails.Urn.Should().Be(createProjectRequest.Urn);
            project.ProjectDetails.Date.Value.Date.Should().Be(createProjectRequest.Date.Value.Date);
            project.ProjectDetails.IsDateProvisional.Should().Be(createProjectRequest.IsDateProvisional);
            project.ProjectDetails.IncomingTrustUkprn.Should().Be(createProjectRequest.IncomingTrustDetails.Ukprn);
            project.ProjectDetails.IncomingTrustName.Should().Be("Trust 1");
            project.ProjectDetails.OutgoingTrustUkprn.Should().Be(createProjectRequest.OutgoingTrustDetails.Ukprn);
            project.ProjectDetails.OutgoingTrustName.Should().Be("Trust 2");
            project.ProjectDetails.Region.Should().Be("North West");
            project.ProjectDetails.ProjectType.Should().Be(ProjectType.Transfer);
            project.ProjectDetails.LocalAuthority.Should().Be("Local authority 1");
            project.ProjectDetails.Name.Should().Be("Establishment 1");

            // Reason for the transfer
            project.ReasonForTheTransfer.IsDueTo2RI.Should().Be(createProjectRequest.IsDueTo2RI);
            project.ReasonForTheTransfer.IsDueToOfstedRating.Should().Be(createProjectRequest.IsDueToOfstedRating);
            project.ReasonForTheTransfer.IsDueToIssues.Should().Be(createProjectRequest.IsDueToIssues);

            // Advisory board details
            project.AdvisoryBoardDetails.Date.Value.Date.Should().Be(createProjectRequest.AdvisoryBoardDetails.Date.Value.Date);
            project.AdvisoryBoardDetails.Conditions.Should().Be(createProjectRequest.AdvisoryBoardDetails.Conditions);

            // Incoming trust details
            project.IncomingTrustDetails.Name.Should().Be("Trust 1");
            project.IncomingTrustDetails.UkPrn.Should().Be(createProjectRequest.IncomingTrustDetails.Ukprn);
            project.IncomingTrustDetails.GroupId.Should().Be("TR0001");
            project.IncomingTrustDetails.CompaniesHouseNumber.Should().Be("00001");
            project.IncomingTrustDetails.Address.Street.Should().Be("Trust 1 Street");
            project.IncomingTrustDetails.Address.Locality.Should().Be("Trust 1 Locality");
            project.IncomingTrustDetails.Address.Additional.Should().Be("Trust 1 Additional");
            project.IncomingTrustDetails.Address.Town.Should().Be("Trust 1 Town");
            project.IncomingTrustDetails.Address.County.Should().Be("Trust 1 County");
            project.IncomingTrustDetails.Address.Postcode.Should().Be("Trust 1 Postcode");
            project.IncomingTrustDetails.SharePointLink.Should().Be(createProjectRequest.IncomingTrustDetails.SharepointLink);

            // Outgoing trust details
            project.OutgoingTrustDetails.Name.Should().Be("Trust 2");
            project.OutgoingTrustDetails.UkPrn.Should().Be(createProjectRequest.OutgoingTrustDetails.Ukprn);
            project.OutgoingTrustDetails.GroupId.Should().Be("TR0002");
            project.OutgoingTrustDetails.CompaniesHouseNumber.Should().Be("00002");
            project.OutgoingTrustDetails.Address.Street.Should().Be("Trust 2 Street");
            project.OutgoingTrustDetails.Address.Locality.Should().Be("Trust 2 Locality");
            project.OutgoingTrustDetails.Address.Additional.Should().Be("Trust 2 Additional");
            project.OutgoingTrustDetails.Address.Town.Should().Be("Trust 2 Town");
            project.OutgoingTrustDetails.Address.County.Should().Be("Trust 2 County");
            project.OutgoingTrustDetails.Address.Postcode.Should().Be("Trust 2 Postcode");
            project.OutgoingTrustDetails.SharePointLink.Should().Be(createProjectRequest.OutgoingTrustDetails.SharepointLink);

            // School details
            project.SchoolDetails.Name.Should().Be("Establishment 1");
            project.SchoolDetails.Urn.Should().Be(createProjectRequest.Urn);
            project.SchoolDetails.Type.Should().Be("Voluntary aided school");
            project.SchoolDetails.LowerAge.Should().Be("3");
            project.SchoolDetails.UpperAge.Should().Be("16");
            project.SchoolDetails.AgeRange.Should().Be("3 to 16");
            project.SchoolDetails.Phase.Should().Be("Primary");
            project.SchoolDetails.Address.Street.Should().Be("Establishment 1 Street");
            project.SchoolDetails.Address.Locality.Should().Be("Establishment 1 Locality");
            project.SchoolDetails.Address.Additional.Should().Be("Establishment 1 Additional");
            project.SchoolDetails.Address.Town.Should().Be("Establishment 1 Town");
            project.SchoolDetails.Address.County.Should().Be("Establishment 1 County");
            project.SchoolDetails.Address.Postcode.Should().Be("Establishment 1 Postcode");
            project.SchoolDetails.Diocese.Should().Be("St Pauls");
            project.SchoolDetails.SharePointLink.Should().Be(createProjectRequest.SchoolSharePointLink);

            var testContext = _testFixture.GetContext();

            var dbProject = testContext.Projects.FirstOrDefault(p => p.Id == createProjectResponse.Id);
            dbProject.TasksDataType.Should().Be(TaskType.Transfer);
            dbProject.Type.Should().Be(ProjectType.Transfer);
            dbProject.SignificantDate.Value.Date.Should().Be(createProjectRequest.Date.Value.Date);
            dbProject.SignificantDateProvisional.Should().Be(createProjectRequest.IsDateProvisional);
        }

        [Fact]
        public async Task Update_Returns_200()
        {
            var createProjectRequest = _autoFixture.Create<CreateTransferProjectRequest>();
            createProjectRequest.Region = Region.NorthWest;
            createProjectRequest.Urn = "1001";
            createProjectRequest.IncomingTrustDetails.Ukprn = "10000001";
            createProjectRequest.OutgoingTrustDetails.Ukprn = "10000002";

            var createResponse = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createProjectResponse = await createResponse.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();
            var projectId = createProjectResponse.Id;

            var updateProjectRequest = _autoFixture.Create<UpdateTransferProjectRequest>();
            updateProjectRequest.IncomingTrustDetails.Ukprn = "10000003";
            updateProjectRequest.OutgoingTrustDetails.Ukprn = "10000004";

            var updateResponse = await _client.PatchAsync(string.Format(RouteConstants.TransferProjectById, projectId), updateProjectRequest.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.TransferProjectById, projectId));
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var project = await getResponse.Content.ReadFromJsonAsync<GetTransferProjectResponse>();

            // Incoming trust
            project.IncomingTrustDetails.Name.Should().Be("Trust 3");
            project.IncomingTrustDetails.CompaniesHouseNumber.Should().Be("00003");
            project.IncomingTrustDetails.UkPrn.Should().Be(updateProjectRequest.IncomingTrustDetails.Ukprn);

            // Outgoing trust
            project.OutgoingTrustDetails.Name.Should().Be("Trust 4");
            project.OutgoingTrustDetails.CompaniesHouseNumber.Should().Be("00004");
            project.OutgoingTrustDetails.UkPrn.Should().Be(updateProjectRequest.OutgoingTrustDetails.Ukprn);

            // Advisory board details
            project.AdvisoryBoardDetails.Date.Value.Date.Should().Be(updateProjectRequest.AdvisoryBoardDetails.Date.Value.Date);
            project.AdvisoryBoardDetails.Conditions.Should().Be(updateProjectRequest.AdvisoryBoardDetails.Conditions);

            // Reason for the transfer
            project.ReasonForTheTransfer.IsDueTo2RI.Should().Be(updateProjectRequest.ReasonForTheTransfer.IsDueTo2RI);
            project.ReasonForTheTransfer.IsDueToOfstedRating.Should().Be(updateProjectRequest.ReasonForTheTransfer.IsDueToOfstedRating);
            project.ReasonForTheTransfer.IsDueToIssues.Should().Be(updateProjectRequest.ReasonForTheTransfer.IsDueToIssues);

            // School
            project.SchoolDetails.SharePointLink.Should().Be(updateProjectRequest.SchoolSharePointLink);
        }

        [Fact]
        public async Task AcademiesReturns404_ReturnsEmptyTrustAndEstablishment() {
            var createProjectRequest = _autoFixture.Create<CreateTransferProjectRequest>();
            createProjectRequest.Region = Region.NorthWest;
            createProjectRequest.Urn = "1111";
            createProjectRequest.IncomingTrustDetails.Ukprn = "11111111";
            createProjectRequest.OutgoingTrustDetails.Ukprn = "11111111";

            var createResponse = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            var createProjectResponse = await createResponse.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();

            var projectId = createProjectResponse.Id;

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.TransferProjectById, projectId));
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var project = await getResponse.Content.ReadFromJsonAsync<GetTransferProjectResponse>();

            project.SchoolDetails.Name.Should().Be("1111");
            project.SchoolDetails.Urn.Should().Be("1111");

            project.IncomingTrustDetails.Name.Should().Be("11111111");
            project.IncomingTrustDetails.UkPrn.Should().Be("11111111");

            project.OutgoingTrustDetails.Name.Should().Be("11111111");
            project.OutgoingTrustDetails.UkPrn.Should().Be("11111111");

        }

        [Fact]
        public async Task Update_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();
            var request = new UpdateTransferProjectRequest();

            var response = await _client.PatchAsync(string.Format(RouteConstants.TransferProjectById, projectId), request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Get_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync(string.Format(RouteConstants.TransferProjectById, projectId));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Get_ProjectDoesNotHaveTaskData_Returns_404()
        {
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Transfer;

            var context = _testFixture.GetContext();
            context.Projects.Add(project);
            context.SaveChanges();

            var response = await _client.GetAsync(string.Format(RouteConstants.TransferProjectById, project.Id));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"Project with id {project.Id} does not have any transfer tasks data");
        }
    }
}
