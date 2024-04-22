using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks.PDG
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class StopPaymentsApiTests : ApiTestsBase
    {
        public StopPaymentsApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {

        }

        [Fact]
        public async Task Patch_NewStopPayment_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                StopPayment = new()
                {
                    PaymentStoppedDate = new DateTime().AddDays(10),
                    PaymentStopped = "No",
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.StopPayment.ToString());

            projectResponse.StopPayment.PaymentStoppedDate.Should()
                .Be(request.StopPayment.PaymentStoppedDate);
            projectResponse.StopPayment.PaymentStopped.Should()
                .Be(request.StopPayment.PaymentStopped);
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
                StopPayment = new()
                {
                    PaymentStoppedDate = new DateTime().AddDays(10),
                    PaymentStopped = "No",
                }
            };

            var updateRequest = new UpdateProjectByTaskRequest()
            {
                StopPayment = new()
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.StopPayment.ToString());

            projectResponse.StopPayment.PaymentStoppedDate.Should()
                .Be(request.StopPayment.PaymentStoppedDate);
            projectResponse.StopPayment.PaymentStopped.Should()
                .Be(request.StopPayment.PaymentStopped);
        }
    }
}
