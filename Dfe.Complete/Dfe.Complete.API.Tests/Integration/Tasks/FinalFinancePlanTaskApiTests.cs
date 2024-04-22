using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;
using System;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class FinalFinanceTaskApiTests : ApiTestsBase
    {
        public FinalFinanceTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewFinalFinancePlanTask_Returns_200()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            await context.SaveChangesAsync();

            var signoffDate = DateTime.Now.Date.AddDays(-5);

            var request = new UpdateProjectByTaskRequest()
            {
                FinalFinancePlan = new FinalFinancePlanTask()
                {
                    ConfirmedTrustHasProvidedFinalPlan = true,
                    Grade6SignedOffFinalPlanDate = signoffDate,

                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.FinalFinancePlan.ToString());

            projectResponse.FinalFinancePlan.ConfirmedTrustHasProvidedFinalPlan.Should().Be(true);
            projectResponse.FinalFinancePlan.Grade6SignedOffFinalPlanDate.Should().Be(signoffDate);
            projectResponse.FinalFinancePlan.SentFinalPlanToRevenueFundingMailbox.Should().BeNull();
            projectResponse.FinalFinancePlan.SavedFinalPlanInWorkplacesFolder.Should().BeNull();

        }

        [Fact]
        public async Task Patch_ExistingFinalFinancePlanTask_Returns_200()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var FinalFinancePlan = DatabaseModelBuilder.BuildFinalFinancePlanTask(project.Rid);
            context.Milestones.Add(FinalFinancePlan);

            await context.SaveChangesAsync();

            var signoffDate = DateTime.Now.Date.AddDays(-5);

            var request = new UpdateProjectByTaskRequest()
            {
                FinalFinancePlan = new FinalFinancePlanTask()
                {
                    ConfirmedTrustHasProvidedFinalPlan = true,
                    Grade6SignedOffFinalPlanDate = signoffDate,
                    SentFinalPlanToRevenueFundingMailbox = true,
                    SavedFinalPlanInWorkplacesFolder = true

                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.FinalFinancePlan.ToString());
            projectResponse.FinalFinancePlan.ConfirmedTrustHasProvidedFinalPlan.Should().Be(true);
            projectResponse.FinalFinancePlan.Grade6SignedOffFinalPlanDate.Should().Be(signoffDate);
            projectResponse.FinalFinancePlan.SentFinalPlanToRevenueFundingMailbox.Should().Be(true);
            projectResponse.FinalFinancePlan.SavedFinalPlanInWorkplacesFolder.Should().Be(true);
        }
    }
}
