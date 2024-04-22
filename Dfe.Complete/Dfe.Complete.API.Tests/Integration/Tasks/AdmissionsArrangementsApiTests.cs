using System;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class AdmissionsArrangementsApiTests : ApiTestsBase
    {
        public AdmissionsArrangementsApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewAdmissionsArrangements_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                AdmissionsArrangements = new AdmissionsArrangementsTask()
                {
                    TrustConfirmedAdmissionsArrangementsPolicies = true,
                    TrustConfirmedAdmissionsArrangementsTemplate = true,
                    AdmissionsArrangementsConfirmedDate = new DateTime().AddDays(10),
                    SavedToWorkplaces = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.AdmissionsArrangements.ToString());

            projectResponse.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsPolicies.Should()
                .Be(request.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsPolicies);
            projectResponse.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsTemplate.Should()
                .Be(request.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsTemplate);
            projectResponse.AdmissionsArrangements.AdmissionsArrangementsConfirmedDate.Should()
                .Be(request.AdmissionsArrangements.AdmissionsArrangementsConfirmedDate);
            projectResponse.AdmissionsArrangements.SavedToWorkplaces.Should()
                .Be(request.AdmissionsArrangements.SavedToWorkplaces);
        }

        [Fact]
        public async Task Patch_ExistingAdmissionsArragements_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            
            var admissionsArrangementsTask = DatabaseModelBuilder.BuildAdmissionsArrangementsTask(project.Rid);
            context.Milestones.Add(admissionsArrangementsTask);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                AdmissionsArrangements = new AdmissionsArrangementsTask()
                {
                    TrustConfirmedAdmissionsArrangementsPolicies = false,
                    TrustConfirmedAdmissionsArrangementsTemplate = false,
                    AdmissionsArrangementsConfirmedDate = new DateTime().AddDays(9),
                    SavedToWorkplaces = false
                }
            };

            await _client.UpdateProjectTask(projectId, request, TaskName.AdmissionsArrangements.ToString());

            var updateRequest = new UpdateProjectByTaskRequest()
            {
                AdmissionsArrangements = new()
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.AdmissionsArrangements.ToString());

            projectResponse.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsPolicies.Should()
                .Be(request.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsPolicies);
            projectResponse.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsTemplate.Should()
                .Be(request.AdmissionsArrangements.TrustConfirmedAdmissionsArrangementsTemplate);
            projectResponse.AdmissionsArrangements.AdmissionsArrangementsConfirmedDate.Should()
                .Be(request.AdmissionsArrangements.AdmissionsArrangementsConfirmedDate);
            projectResponse.AdmissionsArrangements.SavedToWorkplaces.Should()
                .Be(request.AdmissionsArrangements.SavedToWorkplaces);
        }

    }
}
