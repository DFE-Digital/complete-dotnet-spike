using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ModelFundingAgreementApiTests : ApiTestsBase
    {
        public ModelFundingAgreementApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_ModelFundingAgreement_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var dateNineDaysInFuture = new DateTime().AddDays(9);

            var request = new UpdateProjectByTaskRequest()
            {
                ModelFundingAgreement = new ModelFundingAgreementTask()
                {
                    TailoredAModelFundingAgreement = true,
                    SharedFAWithTheTrust = true,
                    TrustAgreesWithModelFA = YesNo.Yes,
                    DateTrustAgreesWithModelFA = dateNineDaysInFuture,
                    Comments = "new comments",
                    DraftedFAHealthCheck = true,
                    SavedFADocumentsInWorkplacesFolder = true
                }
            };

            var projectResponse =
                await _client.UpdateProjectTask(projectId, request, TaskName.ModelFundingAgreement.ToString());

            projectResponse.ModelFundingAgreement.TrustAgreesWithModelFA.Should()
                .Be(request.ModelFundingAgreement.TrustAgreesWithModelFA);
            projectResponse.ModelFundingAgreement.DateTrustAgreesWithModelFA.Should()
                .Be(request.ModelFundingAgreement.DateTrustAgreesWithModelFA);
            projectResponse.ModelFundingAgreement.TailoredAModelFundingAgreement.Should()
                .Be(request.ModelFundingAgreement.TailoredAModelFundingAgreement);
            projectResponse.ModelFundingAgreement.SharedFAWithTheTrust.Should()
                .Be(request.ModelFundingAgreement.SharedFAWithTheTrust);
            projectResponse.ModelFundingAgreement.Comments.Should()
                .Be(request.ModelFundingAgreement.Comments);
            projectResponse.ModelFundingAgreement.DraftedFAHealthCheck.Should()
                .Be(request.ModelFundingAgreement.DraftedFAHealthCheck);
            projectResponse.ModelFundingAgreement.SavedFADocumentsInWorkplacesFolder.Should()
                .Be(request.ModelFundingAgreement.SavedFADocumentsInWorkplacesFolder);
        }

        [Fact]
        public async Task Patch_ExistingModelFundingArrangement_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var modelFundingAgreementTask = DatabaseModelBuilder.BuildModelFundingAgreementTask(project.Rid);
            context.Milestones.Add(modelFundingAgreementTask);

            await context.SaveChangesAsync();

            var dateNineDaysInFuture = new DateTime().AddDays(9);

            var request = new UpdateProjectByTaskRequest()
            {
                ModelFundingAgreement = new ModelFundingAgreementTask()
                {
                    TailoredAModelFundingAgreement = true,
                    SharedFAWithTheTrust = false,
                    TrustAgreesWithModelFA = YesNo.Yes,
                    DateTrustAgreesWithModelFA = dateNineDaysInFuture,
                    Comments = "new comments dave",
                    DraftedFAHealthCheck = true,
                    SavedFADocumentsInWorkplacesFolder = false
                }
            };

            var projectResponse =
                await _client.UpdateProjectTask(projectId, request, TaskName.ModelFundingAgreement.ToString());

            projectResponse.ModelFundingAgreement.TrustAgreesWithModelFA.Should()
                .Be(request.ModelFundingAgreement.TrustAgreesWithModelFA);
            projectResponse.ModelFundingAgreement.DateTrustAgreesWithModelFA.Should()
                .Be(request.ModelFundingAgreement.DateTrustAgreesWithModelFA);
            projectResponse.ModelFundingAgreement.TailoredAModelFundingAgreement.Should()
                .Be(request.ModelFundingAgreement.TailoredAModelFundingAgreement);
            projectResponse.ModelFundingAgreement.SharedFAWithTheTrust.Should()
                .Be(request.ModelFundingAgreement.SharedFAWithTheTrust);
            projectResponse.ModelFundingAgreement.Comments.Should()
                .Be(request.ModelFundingAgreement.Comments);
            projectResponse.ModelFundingAgreement.DraftedFAHealthCheck.Should()
                .Be(request.ModelFundingAgreement.DraftedFAHealthCheck);
            projectResponse.ModelFundingAgreement.SavedFADocumentsInWorkplacesFolder.Should()
                .Be(request.ModelFundingAgreement.SavedFADocumentsInWorkplacesFolder);
        }
    }
}
