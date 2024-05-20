using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Conversion
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConversionProjectApiTests : ApiTestsBase
    {
        public ConversionProjectApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Post_Returns_200()
        {
            var createProjectRequest = _autoFixture.Create<CreateConversionProjectRequest>();
            createProjectRequest.Region = Region.NorthWest;
            createProjectRequest.Urn = "1001";
            createProjectRequest.IncomingTrustDetails.Ukprn = "10000001";

            var response = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var createProjectResponse = await response.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();

            createProjectResponse.Id.Should().NotBeEmpty();

            var getProjectResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectById, createProjectResponse.Id)}");
            getProjectResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var project = await getProjectResponse.Content.ReadFromJsonAsync<GetConversionProjectResponse>();

            // Project details
            project.ProjectDetails.Urn.Should().Be(createProjectRequest.Urn);
            project.ProjectDetails.Date.Value.Date.Should().Be(createProjectRequest.Date.Value.Date);
            project.ProjectDetails.IsDateProvisional.Should().Be(createProjectRequest.IsDateProvisional);
            project.ProjectDetails.IncomingTrustUkprn.Should().Be(createProjectRequest.IncomingTrustDetails.Ukprn);
            project.ProjectDetails.IncomingTrustName.Should().Be("Trust 1");
            project.ProjectDetails.OutgoingTrustUkprn.Should().BeNull();
            project.ProjectDetails.OutgoingTrustName.Should().BeNull();
            project.ProjectDetails.Region.Should().Be("North West");
            project.ProjectDetails.ProjectType.Should().Be(ProjectType.Conversion);
            project.ProjectDetails.LocalAuthority.Should().Be("Local authority 1");
            project.ProjectDetails.Name.Should().Be("Establishment 1");

            // Reason for the conversion
            project.ReasonForTheConversion.IsDueTo2RI.Should().Be(createProjectRequest.IsIsDueTo2RI);
            project.ReasonForTheConversion.HasAcademyOrderBeenIssued.Should().Be(createProjectRequest.HasAcademyOrderBeenIssued);

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
            dbProject.TasksDataType.Should().Be(TaskType.Conversion);
            dbProject.Type.Should().Be(ProjectType.Conversion);
            dbProject.SignificantDate.Value.Date.Should().Be(createProjectRequest.Date.Value.Date);
            dbProject.SignificantDateProvisional.Should().Be(createProjectRequest.IsDateProvisional);
        }

        [Fact]
        public async Task Get_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync(string.Format(RouteConstants.ConversionProjectById, projectId));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Get_ProjectDoesNotHaveTaskData_Returns_404()
        {
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Conversion;

            var context = _testFixture.GetContext();
            context.Projects.Add(project);
            context.SaveChanges();

            var response = await _client.GetAsync(string.Format(RouteConstants.ConversionProjectById, project.Id));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"Project with id {project.Id} does not have any conversion tasks data");
        }
    }
}
