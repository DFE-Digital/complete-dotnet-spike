using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.API.Tests.Utils;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConstituencyTaskApiTests : ApiTestsBase
    {
        public ConstituencyTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_ConstituencyTask_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var tasks = TasksStub.BuildListOfTasks(project.Rid);
            context.Tasks.AddRange(tasks);

            await context.SaveChangesAsync();

            const string Battersea = "Battersea";
            const string TeddyBones = "RT Hon Theodore Bones";
            const string MRL = "Monster Raving Loony";
            var request = new UpdateProjectByTaskRequest()
            {
                Constituency = new ConstituencyTask()
                {
                    Name = Battersea,
                    MPName = TeddyBones,
                    Party = MRL,
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.Constituency.ToString());

            projectResponse.Constituency.Name.Should().Be(Battersea);
            projectResponse.Constituency.MPName.Should().Be(TeddyBones);
            projectResponse.Constituency.Party.Should().Be(MRL);
            projectResponse.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);
        }
    }
}
