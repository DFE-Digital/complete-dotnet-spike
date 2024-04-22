using System;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class OfstedInspectionApiTests : ApiTestsBase
    {
        public OfstedInspectionApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewOfstedInspection_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                OfstedInspection = new OfstedInspectionTask()
                {
                    ProcessDetailsProvided = true,
                    InspectionBlockDecided = true,
                    OfstedAndTrustLiaisonDetailsConfirmed = true,
                    BlockAndContentDetailsToOpenersSpreadSheet = true, 
                    SharedOutcomeWithTrust  = true,
                    InspectionConditionsMet  = true,
                    ProposedToOpenOnGias = true,
                    SavedToWorkplaces = true,
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.OfstedInspection.ToString());

            projectResponse.OfstedInspection.ProcessDetailsProvided.Should()
                .Be(request.OfstedInspection.ProcessDetailsProvided);
            projectResponse.OfstedInspection.InspectionBlockDecided.Should()
                .Be(request.OfstedInspection.InspectionBlockDecided);
            projectResponse.OfstedInspection.OfstedAndTrustLiaisonDetailsConfirmed.Should()
                .Be(request.OfstedInspection.OfstedAndTrustLiaisonDetailsConfirmed);
            projectResponse.OfstedInspection.BlockAndContentDetailsToOpenersSpreadSheet.Should()
                .Be(request.OfstedInspection.BlockAndContentDetailsToOpenersSpreadSheet);
            projectResponse.OfstedInspection.SharedOutcomeWithTrust.Should()
                .Be(request.OfstedInspection.SharedOutcomeWithTrust);
            projectResponse.OfstedInspection.InspectionConditionsMet.Should()
                .Be(request.OfstedInspection.InspectionConditionsMet);
            projectResponse.OfstedInspection.ProposedToOpenOnGias.Should()
                .Be(request.OfstedInspection.ProposedToOpenOnGias);
            projectResponse.OfstedInspection.SavedToWorkplaces.Should()
                .Be(request.OfstedInspection.SavedToWorkplaces);
        }

        [Fact]
        public async Task Patch_ExistingOfstedInspection_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            
            var admissionsArrangementsTask = DatabaseModelBuilder.OfstedInspectionTask(project.Rid);
            context.Milestones.Add(admissionsArrangementsTask);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                OfstedInspection = new OfstedInspectionTask()
                {
                   ProcessDetailsProvided = false,
                   InspectionBlockDecided = false,
                   OfstedAndTrustLiaisonDetailsConfirmed = false,
                   BlockAndContentDetailsToOpenersSpreadSheet = false,
                   SharedOutcomeWithTrust = false,
                   InspectionConditionsMet = false,
                   ProposedToOpenOnGias = false,
                   SavedToWorkplaces = false
                }
            };

            await _client.UpdateProjectTask(projectId, request, TaskName.OfstedInspection.ToString());

            var updateRequest = new UpdateProjectByTaskRequest()
            {
                OfstedInspection = new()
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.OfstedInspection.ToString());

            projectResponse.OfstedInspection.ProcessDetailsProvided.Should()
                .Be(request.OfstedInspection.ProcessDetailsProvided);
            projectResponse.OfstedInspection.InspectionBlockDecided.Should()
                .Be(request.OfstedInspection.InspectionBlockDecided);
            projectResponse.OfstedInspection.OfstedAndTrustLiaisonDetailsConfirmed.Should()
                .Be(request.OfstedInspection.OfstedAndTrustLiaisonDetailsConfirmed);
            projectResponse.OfstedInspection.BlockAndContentDetailsToOpenersSpreadSheet.Should()
                .Be(request.OfstedInspection.BlockAndContentDetailsToOpenersSpreadSheet);
            projectResponse.OfstedInspection.SharedOutcomeWithTrust.Should()
                .Be(request.OfstedInspection.SharedOutcomeWithTrust);
            projectResponse.OfstedInspection.InspectionConditionsMet.Should()
                .Be(request.OfstedInspection.InspectionConditionsMet);
            projectResponse.OfstedInspection.ProposedToOpenOnGias.Should()
                .Be(request.OfstedInspection.ProposedToOpenOnGias);
            projectResponse.OfstedInspection.SavedToWorkplaces.Should()
                .Be(request.OfstedInspection.SavedToWorkplaces);
        }
    }
}
