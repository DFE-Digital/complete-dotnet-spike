using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;
using System;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class FinanceTaskApiTests : ApiTestsBase
    {
        public FinanceTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewFinancePlanTask_Returns_200()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            await context.SaveChangesAsync();

            var dateAgreed = DateTime.Now.Date.AddDays(-5);
            var rpaStartDate = DateTime.Now.Date.AddDays(10);

            var request = new UpdateProjectByTaskRequest()
            {
                FinancePlan = new FinancePlanTask()
                {
                    FinancePlanAgreed = YesNo.Yes,
                    Comments = "CommentsOnDecisionToApprove",
                    LocalAuthorityAgreedPupilNumbers = YesNoNotApplicable.Yes,
                    DateAgreed = dateAgreed,
                    PlanSavedInWorksplacesFolder = YesNo.Yes,
                    TrustWillOptIntoRpa = YesNo.Yes,
                    RpaCoverType = "RpaCoverType",
                    RpaStartDate = rpaStartDate
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.FinancePlan.ToString());

            projectResponse.FinancePlan.FinancePlanAgreed.Should().Be(YesNo.Yes);
            projectResponse.FinancePlan.Comments.Should().Be("CommentsOnDecisionToApprove");
            projectResponse.FinancePlan.LocalAuthorityAgreedPupilNumbers.Should().Be(YesNoNotApplicable.Yes);
            projectResponse.FinancePlan.DateAgreed.Should().Be(dateAgreed);
            projectResponse.FinancePlan.PlanSavedInWorksplacesFolder.Should().Be(YesNo.Yes);
            projectResponse.FinancePlan.TrustWillOptIntoRpa.Should().Be(YesNo.Yes);
            projectResponse.FinancePlan.RpaCoverType.Should().Be("RpaCoverType");
            projectResponse.FinancePlan.RpaStartDate.Should().Be(rpaStartDate);
        }

        [Fact]
        public async Task Patch_ExistingFinancePlanTask_Returns_200()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var milestone = DatabaseModelBuilder.BuildMilestone(project.Rid);
            context.Milestones.Add(milestone);

            await context.SaveChangesAsync();

            var dateAgreed = DateTime.Now.Date.AddDays(-5);
            var rpaStartDate = DateTime.Now.Date.AddDays(10);

            var request = new UpdateProjectByTaskRequest()
            {
                FinancePlan = new FinancePlanTask()
                {
                    FinancePlanAgreed = YesNo.No,
                    Comments = "ChangedDecisionToApprove",
                    LocalAuthorityAgreedPupilNumbers = YesNoNotApplicable.NotApplicable,
                    DateAgreed = dateAgreed,
                    PlanSavedInWorksplacesFolder = YesNo.No,
                    TrustWillOptIntoRpa = YesNo.No,
                    RpaCoverType = "a new RpaCoverType",
                    RpaStartDate = rpaStartDate
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.FinancePlan.ToString());

            projectResponse.FinancePlan.FinancePlanAgreed.Should().Be(YesNo.No);
            projectResponse.FinancePlan.Comments.Should().Be("ChangedDecisionToApprove");
            projectResponse.FinancePlan.LocalAuthorityAgreedPupilNumbers.Should().Be(YesNoNotApplicable.NotApplicable);
            projectResponse.FinancePlan.DateAgreed.Should().Be(dateAgreed);
            projectResponse.FinancePlan.PlanSavedInWorksplacesFolder.Should().Be(YesNo.No);
            projectResponse.FinancePlan.TrustWillOptIntoRpa.Should().Be(YesNo.No);
            projectResponse.FinancePlan.RpaCoverType.Should().Be("a new RpaCoverType");
            projectResponse.FinancePlan.RpaStartDate.Should().Be(rpaStartDate);
        }
    }
}
