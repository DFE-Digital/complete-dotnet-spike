using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class TrustTaskApiTests : ApiTestsBase
    {
        public TrustTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_TrustTask_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var trust = DatabaseModelBuilder.BuildTrust();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            context.Trust.Add(trust);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                Trust = new TrustTask()
                {
                    TRN = trust.TrustRef
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.Trust.ToString());

            projectResponse.Trust.TRN.Should().Be(trust.TrustRef);
            projectResponse.Trust.TrustName.Should().Be(trust.TrustsTrustName);
            projectResponse.Trust.TrustType.Should().Be(ProjectMapper.ToTrustType(trust.TrustsTrustType));
            projectResponse.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);
        }
    }
}
