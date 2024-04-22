using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class LocalAuthorityAndRegionTaskApiTests : ApiTestsBase
    {
        public LocalAuthorityAndRegionTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
            
        }

        [Fact]
        public async Task Patch_LocalAuthorityAndRegionTask_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                RegionAndLocalAuthorityTask = new()
                {
                    LocalAuthority = "LocalAuthority",
                    Region = "Region"
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.RegionAndLocalAuthority.ToString());

            projectResponse.RegionAndLocalAuthority.LocalAuthority.Should().Be("LocalAuthority");
            projectResponse.RegionAndLocalAuthority.Region.Should().Be("Region");
            projectResponse.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);
        }
    }
}
