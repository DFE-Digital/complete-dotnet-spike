using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ProjectSiteApiTests : ApiTestsBase
    {
        public ProjectSiteApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task When_SitesDoNotExist_Returns_200()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var updatePermanentSiteRequest = _autoFixture.Create<UpdateProjectSiteRequest>();
            var updatePermanentSiteResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/sites/permanent", updatePermanentSiteRequest.ConvertToJson());
            updatePermanentSiteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updateTemporarySiteRequest = _autoFixture.Create<UpdateProjectSiteRequest>();
            var updateTemporarySiteResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/sites/temporary", updateTemporarySiteRequest.ConvertToJson());
            updateTemporarySiteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getProjectSitesResponse = await _client.GetAsync($"/api/v1/client/projects/{projectId}/sites");
            getProjectSitesResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectSitesResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectSitesResponse>>();

            var actualPermanentSite = content.Data.PermanentSite;
            var actualTemporarySite = content.Data.TemporarySite;

            AssertionHelper.AssertProjectSite(actualPermanentSite, updatePermanentSiteRequest);
            AssertionHelper.AssertProjectSite(actualTemporarySite, updateTemporarySiteRequest);

            content.Data.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);
        }

        [Fact]
        public async Task When_SitesExist_Returns_200()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            await SetSites(projectId);

            var updatePermanentSiteRequest = _autoFixture.Create<UpdateProjectSiteRequest>();
            var updatePermanentSiteResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/sites/permanent", updatePermanentSiteRequest.ConvertToJson());
            updatePermanentSiteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updateTemporarySiteRequest = _autoFixture.Create<UpdateProjectSiteRequest>();
            var updateTemporarySiteResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/sites/temporary", updateTemporarySiteRequest.ConvertToJson());
            updateTemporarySiteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getProjectSitesResponse = await _client.GetAsync($"/api/v1/client/projects/{projectId}/sites");
            getProjectSitesResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectSitesResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectSitesResponse>>();

            var actualPermanentSite = content.Data.PermanentSite;
            var actualTemporarySite = content.Data.TemporarySite;

            AssertionHelper.AssertProjectSite(actualPermanentSite, updatePermanentSiteRequest);
            AssertionHelper.AssertProjectSite(actualTemporarySite, updateTemporarySiteRequest);
        }

        [Fact]
        public async Task When_SiteNotConfigured_Returns_200()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var getProjectSitesResponse = await _client.GetAsync($"/api/v1/client/projects/{projectId}/sites");
            getProjectSitesResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectSitesResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectSitesResponse>>();

            AssertBlankSite(content.Data.PermanentSite);
            AssertBlankSite(content.Data.TemporarySite);
        }

        [Fact]
        public async Task When_Get_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid().ToString();

            var getProjectSitesResponse = await _client.GetAsync($"/api/v1/client/projects/{projectId}/sites");
            getProjectSitesResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task When_Patch_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid().ToString();
            var updateSiteRequest = _autoFixture.Create<UpdateProjectSiteRequest>();

            var updateSiteResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/sites/permanent", updateSiteRequest.ConvertToJson());
            updateSiteResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task When_Patch_SiteTypeInvalid_Returns_400()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;
            var updateSiteRequest = _autoFixture.Create<UpdateProjectSiteRequest>();

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var updateSiteResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/sites/invalid", updateSiteRequest.ConvertToJson());
            updateSiteResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private async Task SetSites(string projectId)
        {
            var setPermanentSiteRequest = _autoFixture.Create<UpdateProjectSiteRequest>();
            var setPermanentSiteResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/sites/permanent", setPermanentSiteRequest.ConvertToJson());
            setPermanentSiteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var setTemporarySiteRequest = _autoFixture.Create<UpdateProjectSiteRequest>();
            var setTemporarySiteResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/sites/temporary", setTemporarySiteRequest.ConvertToJson());
            setTemporarySiteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        private static void AssertBlankSite(ProjectSite actual)
        {
            actual.Address.AddressLine1.Should().BeNull();
            actual.Address.AddressLine2.Should().BeNull();
            actual.Address.Postcode.Should().BeNull();
            actual.Address.TownOrCity.Should().BeNull();
            actual.StartDateOfSiteOccupation.Should().BeNull();
        }
    }
}
