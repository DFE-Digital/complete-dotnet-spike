using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ProjectManagersApiTests : ApiTestsBase
    {
        public ProjectManagersApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task When_Get_ProjectManagers_Returns_ProjectManagers_200()
        {
            using var context = _testFixture.GetContext();

            var projectOne = DatabaseModelBuilder.BuildProject();
            var projectTwo = DatabaseModelBuilder.BuildProject();

            context.Kpi.AddRange(projectOne, projectTwo);

            await context.SaveChangesAsync();

            var projectManagersResponse = await _client.GetAsync($"/api/v1/client/project-managers");
            projectManagersResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await projectManagersResponse.Content
                .ReadFromJsonAsync<ApiSingleResponseV2<GetProjectManagersResponse>>();
            var projectManagers = responseContent.Data.ProjectManagers;

            var expectedProjectManagers = new List<string>()
            {
                projectOne.KeyContactsFsgLeadContact, projectTwo.KeyContactsFsgLeadContact
            };

            projectManagers.Should().HaveCountGreaterThanOrEqualTo(2);
            projectManagers.Should().Contain(projectOne.KeyContactsFsgLeadContact);
            projectManagers.Should().Contain(projectTwo.KeyContactsFsgLeadContact);

        }

    }
}