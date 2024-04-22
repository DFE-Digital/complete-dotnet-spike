using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class EqualitiesAssessmentTaskApiTests : ApiTestsBase
    {
        public EqualitiesAssessmentTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewEqualitiesAssessment_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                EqualitiesAssessment = new EqualitiesAssessmentTask()
                {
                    CompletedEqualitiesProcessRecord = true,
                    SavedEPRInWorkplacesFolder = null,
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.EqualitiesAssessment.ToString());

            projectResponse.EqualitiesAssessment.CompletedEqualitiesProcessRecord.Should().Be(request.EqualitiesAssessment.CompletedEqualitiesProcessRecord);
            projectResponse.EqualitiesAssessment.SavedEPRInWorkplacesFolder.Should().Be(request.EqualitiesAssessment.SavedEPRInWorkplacesFolder);

        }

        [Fact]
        public async Task Patch_ExistingEqualitiesAssessment_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var EqualitiesAssessmentTask = DatabaseModelBuilder.BuildEqualitiesAssessmentTask(project.Rid);
            context.Milestones.Add(EqualitiesAssessmentTask);

            await context.SaveChangesAsync();


            var request = new UpdateProjectByTaskRequest()
            {
                EqualitiesAssessment = new EqualitiesAssessmentTask()
                {
                    CompletedEqualitiesProcessRecord = true,
                    SavedEPRInWorkplacesFolder = true,
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.EqualitiesAssessment.ToString());

            projectResponse.EqualitiesAssessment.CompletedEqualitiesProcessRecord.Should().Be(request.EqualitiesAssessment.CompletedEqualitiesProcessRecord);
            projectResponse.EqualitiesAssessment.SavedEPRInWorkplacesFolder.Should().Be(request.EqualitiesAssessment.SavedEPRInWorkplacesFolder);
        }
    }
}
