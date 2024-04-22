using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks.PDG
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class RefundsApiTests : ApiTestsBase
    {
        public RefundsApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {

        }

        [Fact]
        public async Task Patch_NewRefunds_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                Refunds = new RefundsTask()
                {
                    LatestRefundDate = new DateTime().AddDays(10),
                    TotalAmount = 999,
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.Refunds.ToString());

            projectResponse.Refunds.LatestRefundDate.Should()
                .Be(request.Refunds.LatestRefundDate);
            projectResponse.Refunds.TotalAmount.Should()
                .Be(request.Refunds.TotalAmount);
        }


        [Fact]
        public async Task Patch_ExistingRefunds_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var RefundsTask = DatabaseModelBuilder.BuildRefundsTask(project.Rid);
            context.Po.Add(RefundsTask);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                Refunds = new RefundsTask()
                {
                    LatestRefundDate = new DateTime().AddDays(10),
                    TotalAmount = 999,
                }
            };

            var updateRequest = new UpdateProjectByTaskRequest()
            {
                Refunds = new()
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.Refunds.ToString());

            projectResponse.Refunds.LatestRefundDate.Should()
                    .Be(request.Refunds.LatestRefundDate);
            projectResponse.Refunds.TotalAmount.Should()
                    .Be(request.Refunds.TotalAmount);
        }
    }
}
