using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks.PDG
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class WriteOffApiTests : ApiTestsBase
    {
        public WriteOffApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {

        }

        [Fact]
        public async Task Patch_NewWriteOff_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var request = new UpdateProjectByTaskRequest()
            {
                WriteOff = new()
                {
                    WriteOffDate = new DateTime().AddDays(10),
                    WriteOffAmount = 123,
                    WriteOffReason = "Reason",
                    ApprovalDate = new DateTime().AddDays(12),
                    FinanceBusinessPartnerApprovalReceivedFrom = "Davey Jones"
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.WriteOff.ToString());

            projectResponse.WriteOff.WriteOffDate.Should()
                .Be(request.WriteOff.WriteOffDate);
            projectResponse.WriteOff.WriteOffAmount.Should()
                .Be(request.WriteOff.WriteOffAmount);
            projectResponse.WriteOff.WriteOffReason.Should()
                .Be(request.WriteOff.WriteOffReason);
            projectResponse.WriteOff.ApprovalDate.Should()
                .Be(request.WriteOff.ApprovalDate);
            projectResponse.WriteOff.FinanceBusinessPartnerApprovalReceivedFrom.Should()
                .Be(request.WriteOff.FinanceBusinessPartnerApprovalReceivedFrom);
        }


        [Fact]
        public async Task Patch_ExistingWriteOff_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var WriteOffTask = DatabaseModelBuilder.BuildWriteOffTask(project.Rid);
            context.Po.Add(WriteOffTask);
            await context.SaveChangesAsync();
            
            var request = new UpdateProjectByTaskRequest()
            {
                WriteOff = new()
                {
                    WriteOffDate = new DateTime().AddDays(10),
                    WriteOffAmount = 123,
                    WriteOffReason = "Reason",
                    ApprovalDate = new DateTime().AddDays(12),
                    FinanceBusinessPartnerApprovalReceivedFrom = "Davey Jones"
                }
            };

            var updateRequest = new UpdateProjectByTaskRequest()
            {
                WriteOff = new()
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.WriteOff.ToString());

            projectResponse.WriteOff.WriteOffDate.Should()
                .Be(request.WriteOff.WriteOffDate);
            projectResponse.WriteOff.WriteOffAmount.Should()
                .Be(request.WriteOff.WriteOffAmount);
            projectResponse.WriteOff.WriteOffReason.Should()
                .Be(request.WriteOff.WriteOffReason);
            projectResponse.WriteOff.ApprovalDate.Should()
                .Be(request.WriteOff.ApprovalDate);
            projectResponse.WriteOff.FinanceBusinessPartnerApprovalReceivedFrom.Should()
                .Be(request.WriteOff.FinanceBusinessPartnerApprovalReceivedFrom);
        }
    }
}
