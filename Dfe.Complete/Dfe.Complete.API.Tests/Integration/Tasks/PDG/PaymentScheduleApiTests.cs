using Azure.Core;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks.PDG
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class PaymentScheduleApiTests : ApiTestsBase
    {
        public PaymentScheduleApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
            
        }


        [Fact]
        public async Task Patch_NewPaymentSchedule_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                PaymentSchedule = new PaymentScheduleTask()
                {
                    PaymentActualDate = new DateTime().AddDays(10),
                    PaymentActualAmount = 999,
                    PaymentScheduleAmount = 1000,
                    PaymentScheduleDate = new DateTime().AddDays(8)
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.PaymentSchedule.ToString());

            projectResponse.PaymentSchedule.PaymentActualDate.Should()
                .Be(request.PaymentSchedule.PaymentActualDate);
            projectResponse.PaymentSchedule.PaymentActualAmount.Should()
                .Be(request.PaymentSchedule.PaymentActualAmount);
            projectResponse.PaymentSchedule.PaymentScheduleAmount.Should()
                .Be(request.PaymentSchedule.PaymentScheduleAmount);
            projectResponse.PaymentSchedule.PaymentScheduleDate.Should()
                .Be(request.PaymentSchedule.PaymentScheduleDate);
        }


        [Fact]
        public async Task Patch_ExistingPaymentSchedule_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var paymentScheduleTask = DatabaseModelBuilder.BuildPaymentScheduleTask(project.Rid);
            context.Po.Add(paymentScheduleTask);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                
            PaymentSchedule = new PaymentScheduleTask()
            {
                PaymentActualDate = new DateTime().AddDays(10),
                PaymentActualAmount = 999,
                PaymentScheduleAmount = 1000,
                PaymentScheduleDate = new DateTime().AddDays(8)
            }
            };


            var updateRequest = new UpdateProjectByTaskRequest()
            {
                PaymentSchedule = new()
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.PaymentSchedule.ToString());

            projectResponse.PaymentSchedule.PaymentActualDate.Should()
                    .Be(request.PaymentSchedule.PaymentActualDate);
            projectResponse.PaymentSchedule.PaymentActualAmount.Should()
                    .Be(request.PaymentSchedule.PaymentActualAmount);
            projectResponse.PaymentSchedule.PaymentScheduleAmount.Should()
                    .Be(request.PaymentSchedule.PaymentScheduleAmount);
            projectResponse.PaymentSchedule.PaymentScheduleDate.Should()
                    .Be(request.PaymentSchedule.PaymentScheduleDate);
    }
    }

}
