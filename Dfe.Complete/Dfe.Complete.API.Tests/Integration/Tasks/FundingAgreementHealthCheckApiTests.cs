using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class FundingAgreementHealthCheckApiTests : ApiTestsBase
    {
        public FundingAgreementHealthCheckApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_FundingAgreementHealthCheck_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                FundingAgreementHealthCheck = new FundingAgreementHealthCheckTask()
                {
                    DraftedFundingAgreementHealthCheck = true,
                    RegionalDirectorSignedOffFundingAgreementHealthCheck = false,
                    MinisterSignedOffFundingAgreementHealthCheck = false,
                    SavedFundingAgreementHealthCheckInWorkplacesFolder = false
                }
            };

            var projectResponse =
                await _client.UpdateProjectTask(projectId, request, TaskName.FundingAgreementHealthCheck.ToString());

            projectResponse.FundingAgreementHealthCheck.DraftedFundingAgreementHealthCheck.Should()
                .Be(request.FundingAgreementHealthCheck.DraftedFundingAgreementHealthCheck);
            projectResponse.FundingAgreementHealthCheck.RegionalDirectorSignedOffFundingAgreementHealthCheck.Should()
                .Be(request.FundingAgreementHealthCheck.RegionalDirectorSignedOffFundingAgreementHealthCheck);
            projectResponse.FundingAgreementHealthCheck.RegionalDirectorSignedOffFundingAgreementHealthCheck.Should()
                .Be(request.FundingAgreementHealthCheck.RegionalDirectorSignedOffFundingAgreementHealthCheck);
            projectResponse.FundingAgreementHealthCheck.SavedFundingAgreementHealthCheckInWorkplacesFolder.Should()
                .Be(request.FundingAgreementHealthCheck.SavedFundingAgreementHealthCheckInWorkplacesFolder);

        }

        [Fact]
        public async Task Patch_ExistingModelFundingArrangement_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var FundingAgreementHealthCheckTask = DatabaseModelBuilder.BuildFundingAgreementHealthCheckTask(project.Rid);
            context.Milestones.Add(FundingAgreementHealthCheckTask);

            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                FundingAgreementHealthCheck = new FundingAgreementHealthCheckTask()
                {
                    DraftedFundingAgreementHealthCheck = true,
                    RegionalDirectorSignedOffFundingAgreementHealthCheck = true,
                    MinisterSignedOffFundingAgreementHealthCheck = false,
                    SavedFundingAgreementHealthCheckInWorkplacesFolder = true
                }
            };

            var projectResponse =
                await _client.UpdateProjectTask(projectId, request, TaskName.FundingAgreementHealthCheck.ToString());

            projectResponse.FundingAgreementHealthCheck.DraftedFundingAgreementHealthCheck.Should()
                .Be(request.FundingAgreementHealthCheck.DraftedFundingAgreementHealthCheck);
            projectResponse.FundingAgreementHealthCheck.RegionalDirectorSignedOffFundingAgreementHealthCheck.Should()
                .Be(request.FundingAgreementHealthCheck.RegionalDirectorSignedOffFundingAgreementHealthCheck);
            projectResponse.FundingAgreementHealthCheck.RegionalDirectorSignedOffFundingAgreementHealthCheck.Should()
                .Be(request.FundingAgreementHealthCheck.RegionalDirectorSignedOffFundingAgreementHealthCheck);
            projectResponse.FundingAgreementHealthCheck.SavedFundingAgreementHealthCheckInWorkplacesFolder.Should()
                .Be(request.FundingAgreementHealthCheck.SavedFundingAgreementHealthCheckInWorkplacesFolder);
        }
    }
}
