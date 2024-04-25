using Dfe.Complete.API.Contracts.Common;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ProjectListApiTests : ApiTestsBase
    {
        public ProjectListApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task GetProjectList_All_Returns_200()
        {
            using var context = _testFixture.GetContext();
            var user = context.Users.FirstOrDefault(u => u.Email == _testFixture.DefaultUser.Email);

            var dbInProgressProject = DatabaseModelBuilder.BuildInProgressProject(user);

            context.Projects.AddRange(dbInProgressProject);

            await context.SaveChangesAsync();

            var response = await _client.GetAsync("api/v1/client/projects/list");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<ApiListWrapper<ProjectListEntryResponse>>();

            var projects = content.Data;

            var existingProject = projects.FirstOrDefault(p => p.Id == dbInProgressProject.Id);
            existingProject.Should().NotBeNull();

            existingProject.Urn.Should().Be(dbInProgressProject.Urn);
            existingProject.ConversionOrTransferDate.Value.Date.Should().Be(dbInProgressProject.SignificantDate.Value.Date);
            existingProject.ProjectType.Should().Be(ProjectType.Conversion);
            existingProject.AssignedTo.Should().Be($"{user.FirstName} {user.LastName}");
            existingProject.SchoolOrAcademy.Should().Be("Establishment 1");
        }

        [Fact]
        public async Task GetProjectList_InProgress_Returns_200()
        {
            using var context = _testFixture.GetContext();
            var user = context.Users.FirstOrDefault(u => u.Email == _testFixture.DefaultUser.Email);

            var dbInProgressProject = DatabaseModelBuilder.BuildInProgressProject(user);
            var dbCompletedProject = DatabaseModelBuilder.BuildCompletedProject();

            context.Projects.AddRange(dbInProgressProject, dbCompletedProject);

            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"api/v1/client/projects/list?status={ProjectStatusQueryParameter.InProgress}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<ApiListWrapper<ProjectListEntryResponse>>();

            var projects = content.Data;

            var inProgressProject = projects.FirstOrDefault(p => p.Id == dbInProgressProject.Id);
            inProgressProject.Should().NotBeNull();

            var completedProject = projects.FirstOrDefault(p => p.Id == dbCompletedProject.Id);
            completedProject.Should().BeNull();
        }

        [Fact]
        public async Task GetProjectList_AcademyUrn_Returns_NameFromGiasEstablishments_200()
        {
            using var context = _testFixture.GetContext();

            var dbCompletedProject = DatabaseModelBuilder.BuildCompletedProject();
            dbCompletedProject.AcademyUrn = 1001;

            context.Projects.AddRange(dbCompletedProject);

            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"api/v1/client/projects/list");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<ApiListWrapper<ProjectListEntryResponse>>();

            var projects = content.Data;

            var project = projects.FirstOrDefault(p => p.Id == dbCompletedProject.Id);
            project.SchoolOrAcademy.Should().Be("DB Establishment 1");
        }
    }
}
