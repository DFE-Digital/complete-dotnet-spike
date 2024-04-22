using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class GiasTaskApiTests : ApiTestsBase
    {
        public GiasTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewGias_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();
            
            var request = new UpdateProjectByTaskRequest()
            {
                Gias = new GiasTask()
                {
                    CheckedTrustInformation = true,
                    ApplicationFormSent = null,
                    SavedToWorkspaces = false,
                    UrnSent = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.Gias.ToString());

            projectResponse.Gias.CheckedTrustInformation.Should().Be(request.Gias.CheckedTrustInformation);
            projectResponse.Gias.ApplicationFormSent.Should().Be(false);
            projectResponse.Gias.SavedToWorkspaces.Should().Be(request.Gias.SavedToWorkspaces);
            projectResponse.Gias.UrnSent.Should().Be(request.Gias.UrnSent);
        }

        [Fact]
        public async Task Patch_GiasMeeting_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var kickOffMeetingTask = DatabaseModelBuilder.BuildGiasTask(project.Rid);
            context.Milestones.Add(kickOffMeetingTask);

            await context.SaveChangesAsync();
            
            var request = new UpdateProjectByTaskRequest()
            {
                Gias = new GiasTask()
                {
                    CheckedTrustInformation = false,
                    ApplicationFormSent = false,
                    SavedToWorkspaces = false,
                    UrnSent = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.Gias.ToString());

            projectResponse.Gias.CheckedTrustInformation.Should().Be(request.Gias.CheckedTrustInformation);
            projectResponse.Gias.ApplicationFormSent.Should().Be(request.Gias.ApplicationFormSent);
            projectResponse.Gias.SavedToWorkspaces.Should().Be(request.Gias.SavedToWorkspaces);
            projectResponse.Gias.UrnSent.Should().Be(request.Gias.UrnSent);
        }
    }
}
