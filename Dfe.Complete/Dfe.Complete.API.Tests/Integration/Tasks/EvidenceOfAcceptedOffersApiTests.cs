using System;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class EvidenceOfAcceptedOffersApiTests : ApiTestsBase
    {
        public EvidenceOfAcceptedOffersApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_EvidenceAcceptedOffers_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                EvidenceOfAcceptedOffers = new EvidenceOfAcceptedOffersTask()
                {
                    EvidenceOfAcceptedOffers = true,
                    Comments = "Test Comments",
                    SavedToWorkplaces = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.EvidenceOfAcceptedOffers.ToString());

            projectResponse.EvidenceOfAcceptedOffers.EvidenceOfAcceptedOffers.Should()
                .Be(request.EvidenceOfAcceptedOffers.EvidenceOfAcceptedOffers);
            projectResponse.EvidenceOfAcceptedOffers.Comments.Should()
                .Be(request.EvidenceOfAcceptedOffers.Comments);
            projectResponse.EvidenceOfAcceptedOffers.SavedToWorkplaces.Should()
                .Be(request.EvidenceOfAcceptedOffers.SavedToWorkplaces);
        }

        [Fact]
        public async Task Patch_Existing_EvidenceOfAcceptedOffers_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            
            var evidenceOfAcceptedOffersTask = DatabaseModelBuilder.EvidenceOfAcceptedOffersTask(project.Rid);
            context.Milestones.Add(evidenceOfAcceptedOffersTask);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                EvidenceOfAcceptedOffers = new EvidenceOfAcceptedOffersTask()
                {
                    EvidenceOfAcceptedOffers = true,
                    Comments = "Test Comments",
                    SavedToWorkplaces = true
                }
            };

            await _client.UpdateProjectTask(projectId, request, TaskName.EvidenceOfAcceptedOffers.ToString());
            
            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.EvidenceOfAcceptedOffers.ToString());

            projectResponse.EvidenceOfAcceptedOffers.EvidenceOfAcceptedOffers.Should()
                .Be(request.EvidenceOfAcceptedOffers.EvidenceOfAcceptedOffers);
            projectResponse.EvidenceOfAcceptedOffers.Comments.Should()
                .Be(request.EvidenceOfAcceptedOffers.Comments);
            projectResponse.EvidenceOfAcceptedOffers.SavedToWorkplaces.Should()
                .Be(request.EvidenceOfAcceptedOffers.SavedToWorkplaces);
        }

    }
}
