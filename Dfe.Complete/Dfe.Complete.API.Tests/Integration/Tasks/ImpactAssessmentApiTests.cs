using System;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ImpactAssessmentApiTests : ApiTestsBase
    {
        public ImpactAssessmentApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewImpactAssessment_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                ImpactAssessment = new ImpactAssessmentTask()
                {
                    ImpactAssessment = true,
                    SavedToWorkplaces = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.ImpactAssessment.ToString());

            projectResponse.ImpactAssessment.ImpactAssessment.Should()
                .Be(request.ImpactAssessment.ImpactAssessment);
            projectResponse.ImpactAssessment.SavedToWorkplaces.Should()
                .Be(request.ImpactAssessment.SavedToWorkplaces);
        }

        [Fact]
        public async Task Patch_ExistingImpactAssessment_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            
            var admissionsArrangementsTask = DatabaseModelBuilder.BuildImpactAssessmentTask(project.Rid);
            context.Milestones.Add(admissionsArrangementsTask);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                ImpactAssessment = new ImpactAssessmentTask()
                {
                    ImpactAssessment = false,
                    SavedToWorkplaces = false
                }
            };

            await _client.UpdateProjectTask(projectId, request, TaskName.ImpactAssessment.ToString());
            

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.ImpactAssessment.ToString());

            projectResponse.ImpactAssessment.ImpactAssessment.Should()
                .Be(request.ImpactAssessment.ImpactAssessment);
            projectResponse.ImpactAssessment.SavedToWorkplaces.Should()
                .Be(request.ImpactAssessment.SavedToWorkplaces);
        }

    }
}
