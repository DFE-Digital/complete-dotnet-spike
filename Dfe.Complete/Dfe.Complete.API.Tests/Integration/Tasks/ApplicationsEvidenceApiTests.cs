using System;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ApplicationsEvidenceApiTests : ApiTestsBase
    {
        public ApplicationsEvidenceApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_ApplicationsEvidence_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                ApplicationsEvidence = new ApplicationsEvidenceTask()
                {
                    ConfirmedPupilNumbers = true,
                    Comments = "Test Comments",
                    BuildUpFormSavedToWorkplaces = true,
                    UnderwritingAgreementSavedToWorkplaces = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.ApplicationsEvidence.ToString());

            projectResponse.ApplicationsEvidence.ConfirmedPupilNumbers.Should()
                .Be(request.ApplicationsEvidence.ConfirmedPupilNumbers);
            projectResponse.ApplicationsEvidence.Comments.Should()
                .Be(request.ApplicationsEvidence.Comments);
            projectResponse.ApplicationsEvidence.BuildUpFormSavedToWorkplaces.Should()
                .Be(request.ApplicationsEvidence.BuildUpFormSavedToWorkplaces);
            projectResponse.ApplicationsEvidence.UnderwritingAgreementSavedToWorkplaces.Should()
                .Be(request.ApplicationsEvidence.UnderwritingAgreementSavedToWorkplaces);
        }

        [Fact]
        public async Task Patch_Existing_ApplicationsEvidence_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            
            var evidenceOfAcceptedOffersTask = DatabaseModelBuilder.ApplicationsEvidenceTask(project.Rid);
            context.Milestones.Add(evidenceOfAcceptedOffersTask);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                ApplicationsEvidence = new ApplicationsEvidenceTask()
                {
                    ConfirmedPupilNumbers = true,
                    Comments = "Test Comments",
                    BuildUpFormSavedToWorkplaces = true,
                    UnderwritingAgreementSavedToWorkplaces = true
                }
            };

            await _client.UpdateProjectTask(projectId, request, TaskName.ApplicationsEvidence.ToString());
            
            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.ApplicationsEvidence.ToString());

            projectResponse.ApplicationsEvidence.ConfirmedPupilNumbers.Should()
                .Be(request.ApplicationsEvidence.ConfirmedPupilNumbers);
            projectResponse.ApplicationsEvidence.Comments.Should()
                .Be(request.ApplicationsEvidence.Comments);
            projectResponse.ApplicationsEvidence.BuildUpFormSavedToWorkplaces.Should()
                .Be(request.ApplicationsEvidence.BuildUpFormSavedToWorkplaces);
            projectResponse.ApplicationsEvidence.UnderwritingAgreementSavedToWorkplaces.Should()
                .Be(request.ApplicationsEvidence.UnderwritingAgreementSavedToWorkplaces);
        }

    }
}
