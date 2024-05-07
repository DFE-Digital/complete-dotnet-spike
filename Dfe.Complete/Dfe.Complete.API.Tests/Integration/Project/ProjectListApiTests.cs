using Dfe.Complete.API.Contracts.Common;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using Dfe.Complete.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ProjectListApiTests : ApiTestsBase
    {
        public ProjectListApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task GetProjectList_Returns_Correct_Data_200()
        {
            using var context = _testFixture.GetContext();

            var user = new User() { Email = "project.list.properties@education.gov.uk", FirstName = "ProjectList", LastName = "User" };
            context.Add(user);

            var dbInProgressProject = DatabaseModelBuilder.BuildInProgressProject(user);

            context.Projects.AddRange(dbInProgressProject);

            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"api/v1/client/projects/list?userId={user.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<ApiListWrapper<ProjectListEntryResponse>>();

            var projects = content.Data;
            projects.Should().HaveCount(1);

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

            var test = $"api/v1/client/projects/list?status={ProjectStatusQueryParameter.InProgress}";

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

        [Fact]
        public async Task GetProjectList_ByUserId_Returns_200()
        {
            using var context = _testFixture.GetContext();
            var defaultUser = context.Users.FirstOrDefault(u => u.Email == _testFixture.DefaultUser.Email);

            var otherUserProject = DatabaseModelBuilder.BuildInProgressProject(defaultUser);

            var user = new User() { Email = "filter.by.user@education.gov.uk", FirstName = "FilterBy", LastName = "User" };
            context.Add(user);

            var userProject = DatabaseModelBuilder.BuildInProgressProject(user);

            context.Projects.AddRange(otherUserProject, userProject);

            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"api/v1/client/projects/list?userId={user.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<ApiListWrapper<ProjectListEntryResponse>>();

            var projects = content.Data;

            projects.Should().HaveCount(1);

            var project = projects.FirstOrDefault(p => p.Id == userProject.Id);
            project.Should().NotBeNull();
        }

        [Fact]
        public async Task GetProjectList_Pagination_Returns_200()
        {
            using var context = _testFixture.GetContext();
            var user = new User() { Email = "pagination.user@education.gov.uk", FirstName = "Pagination", LastName = "User" };
            context.Add(user);

            var projects = new List<Data.Entities.Project>
            {
                DatabaseModelBuilder.BuildInProgressProject(user),
                DatabaseModelBuilder.BuildInProgressProject(user),
                DatabaseModelBuilder.BuildInProgressProject(user),
                DatabaseModelBuilder.BuildInProgressProject(user),
                DatabaseModelBuilder.BuildInProgressProject(user),
                DatabaseModelBuilder.BuildInProgressProject(user)
            };

            context.AddRange(projects);

            await context.SaveChangesAsync();

            var orderedProjects = projects.OrderBy(p => p.SignificantDate).ToList();
            var pairs = orderedProjects.Select(p => new { Id = p.Id, Date = p.SignificantDate }).ToList();


            // Page one
            var pageOneResponse = await _client.GetAsync($"api/v1/client/projects/list?userId={user.Id}&page=1&count=2");
            pageOneResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var pageOneResult = await pageOneResponse.Content.ReadFromJsonAsync<ApiListWrapper<ProjectListEntryResponse>>();

            pageOneResult.Data.Should().HaveCount(2);
            pageOneResult.Paging.RecordCount.Should().Be(6);
            pageOneResult.Paging.Page.Should().Be(1);
            pageOneResult.Paging.HasNext.Should().BeTrue();
            pageOneResult.Paging.HasPrevious.Should().BeFalse();
            pageOneResult.Paging.TotalPages.Should().Be(3);

            pageOneResult.Data.Should().Contain(r => r.Id == orderedProjects[0].Id);
            pageOneResult.Data.Should().Contain(r => r.Id == orderedProjects[1].Id);

            // Page three
            var pageThreeResponse = await _client.GetAsync($"api/v1/client/projects/list?userId={user.Id}&page=3&count=2");
            pageThreeResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var pageThreeResult = await pageThreeResponse.Content.ReadFromJsonAsync<ApiListWrapper<ProjectListEntryResponse>>();

            pageThreeResult.Data.Should().HaveCount(2);
            pageThreeResult.Paging.Page.Should().Be(3);
            pageThreeResult.Paging.HasNext.Should().BeFalse();
            pageThreeResult.Paging.HasPrevious.Should().BeTrue();

            pageThreeResult.Data.Should().Contain(r => r.Id == orderedProjects[4].Id);
            pageThreeResult.Data.Should().Contain(r => r.Id == orderedProjects[5].Id);
        }
    }
}
