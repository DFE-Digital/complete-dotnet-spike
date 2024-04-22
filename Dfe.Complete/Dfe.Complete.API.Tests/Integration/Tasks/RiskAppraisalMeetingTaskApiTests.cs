using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class RiskAppraisalMeetingTaskApiTests : ApiTestsBase
    {
        public RiskAppraisalMeetingTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewRiskAppraisalMeetingTask_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var DateTenDaysInFuture = new DateTime().AddDays(10);
            var DateNineDaysInFuture = new DateTime().AddDays(9);

            var request = new UpdateProjectByTaskRequest()
            {
                RiskAppraisalMeeting = new RiskAppraisalMeetingTask()
                {
                    ForecastDate = DateTenDaysInFuture,
                    ActualDate = DateNineDaysInFuture,
                    CommentsOnDecisionToApprove = "CommentsOnDecisionToApprove",
                    InitialRiskAppraisalMeetingCompleted = true,
                    ReasonNotApplicable = "ReasonNotApplicable"
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.RiskAppraisalMeeting.ToString());

            projectResponse.RiskAppraisalMeeting.ForecastDate.Should().Be(DateTenDaysInFuture);
            projectResponse.RiskAppraisalMeeting.ActualDate.Should().Be(DateNineDaysInFuture);
            projectResponse.RiskAppraisalMeeting.CommentsOnDecisionToApprove.Should().Be("CommentsOnDecisionToApprove");
            projectResponse.RiskAppraisalMeeting.InitialRiskAppraisalMeetingCompleted.Should().Be(true);
            projectResponse.RiskAppraisalMeeting.ReasonNotApplicable.Should().Be("ReasonNotApplicable");
            projectResponse.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);
        }

        [Fact]
        public async Task Patch_ExistingRiskAppraisalMeetingTask_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var riskAppraisalMeetingTask = DatabaseModelBuilder.BuildRiskAppraisalMeetingTask(project.Rid);
            context.RiskAppraisalMeetingTask.Add(riskAppraisalMeetingTask);

            await context.SaveChangesAsync();

            var DateTenDaysInFuture = new DateTime().AddDays(10);
            var DateNineDaysInFuture = new DateTime().AddDays(9);

            var request = new UpdateProjectByTaskRequest()
            {
                RiskAppraisalMeeting = new RiskAppraisalMeetingTask()
                {
                    ForecastDate = DateTenDaysInFuture,
                    ActualDate = DateNineDaysInFuture,
                    CommentsOnDecisionToApprove = "CommentsOnDecisionToApprove",
                    InitialRiskAppraisalMeetingCompleted = true,
                    ReasonNotApplicable = "ReasonNotApplicable"
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.RiskAppraisalMeeting.ToString());

            projectResponse.RiskAppraisalMeeting.ForecastDate.Should().Be(DateTenDaysInFuture);
            projectResponse.RiskAppraisalMeeting.ActualDate.Should().Be(DateNineDaysInFuture);
            projectResponse.RiskAppraisalMeeting.CommentsOnDecisionToApprove.Should().Be("CommentsOnDecisionToApprove");
            projectResponse.RiskAppraisalMeeting.InitialRiskAppraisalMeetingCompleted.Should().Be(true);
            projectResponse.RiskAppraisalMeeting.ReasonNotApplicable.Should().Be("ReasonNotApplicable");

            context.RiskAppraisalMeetingTask.Count(r => r.RID == project.Rid).Should().Be(1);
        }
    }

}
