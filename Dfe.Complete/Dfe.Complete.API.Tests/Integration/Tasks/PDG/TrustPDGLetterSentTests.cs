using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks.PDG
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class TrustPDGLetterSentTests: ApiTestsBase
    {
        public TrustPDGLetterSentTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {

        }

        [Fact]
        public async Task Patch_NewTrustLetter_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                TrustPDGLetterSent = new ()
                {
                    TrustSignedPDGLetterDate = new DateTime().AddDays(10),
                    PDGLetterSavedInWorkspaces = true,
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.TrustPDGLetterSent.ToString());

            projectResponse.TrustPDGLetterSent.TrustSignedPDGLetterDate.Should()
                .Be(request.TrustPDGLetterSent.TrustSignedPDGLetterDate);
            projectResponse.TrustPDGLetterSent.PDGLetterSavedInWorkspaces.Should()
                .Be(request.TrustPDGLetterSent.PDGLetterSavedInWorkspaces);
        }


        [Fact]
        public async Task Patch_ExistingTrustLetter_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var trustLetterTask = DatabaseModelBuilder.BuildTrustLetterTask(project.Rid);
            context.Po.Add(trustLetterTask);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                TrustPDGLetterSent = new()
                {
                    TrustSignedPDGLetterDate = new DateTime().AddDays(10),
                    PDGLetterSavedInWorkspaces = true,
                }
            };


            var updateRequest = new UpdateProjectByTaskRequest()
            {
                TrustPDGLetterSent = new()
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.TrustPDGLetterSent.ToString());

            projectResponse.TrustPDGLetterSent.TrustSignedPDGLetterDate.Should()
                    .Be(request.TrustPDGLetterSent.TrustSignedPDGLetterDate);
            projectResponse.TrustPDGLetterSent.PDGLetterSavedInWorkspaces.Should()
                    .Be(request.TrustPDGLetterSent.PDGLetterSavedInWorkspaces);
        }
    }
}
