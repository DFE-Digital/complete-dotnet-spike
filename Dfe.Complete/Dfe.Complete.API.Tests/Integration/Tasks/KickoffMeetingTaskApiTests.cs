using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class KickoffMeetingTaskApiTests : ApiTestsBase
    {
        public KickoffMeetingTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewKickOffMeeting_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var dateNineDaysInFuture = new DateTime().AddDays(9);

            var request = new UpdateProjectByTaskRequest()
            {
                KickOffMeeting = new KickOffMeetingTask()
                {
                    FundingArrangementAgreed = true,
                    RealisticYearOfOpening = "2049/2050",
                    FundingArrangementDetailsAgreed = "text",
                    ProvisionalOpeningDate = dateNineDaysInFuture,
                    SharepointLink = "https://sharepoint/completed"
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.KickOffMeeting.ToString());

            projectResponse.KickOffMeeting.SharepointLink.Should().Be(request.KickOffMeeting.SharepointLink);
            projectResponse.KickOffMeeting.RealisticYearOfOpening.Should().Be(request.KickOffMeeting.RealisticYearOfOpening);
            projectResponse.KickOffMeeting.ProvisionalOpeningDate.Should().Be(request.KickOffMeeting.ProvisionalOpeningDate);
            projectResponse.KickOffMeeting.FundingArrangementAgreed.Should().Be(request.KickOffMeeting.FundingArrangementAgreed);
            projectResponse.KickOffMeeting.FundingArrangementDetailsAgreed.Should().Be(request.KickOffMeeting.FundingArrangementDetailsAgreed);
        }

        [Fact]
        public async Task Patch_ExistingKickOffMeeting_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var kickOffMeetingTask = DatabaseModelBuilder.BuildKickOffMeetingTask(project.Rid);
            context.Milestones.Add(kickOffMeetingTask);

            await context.SaveChangesAsync();

            var dateNineDaysInFuture = new DateTime().AddDays(9);

            var request = new UpdateProjectByTaskRequest()
            {
                KickOffMeeting = new KickOffMeetingTask()
                {
                    FundingArrangementAgreed = true,
                    RealisticYearOfOpening = "2049/2050",
                    FundingArrangementDetailsAgreed = "text",
                    ProvisionalOpeningDate = dateNineDaysInFuture,
                    SharepointLink = "https://sharepoint/completed"
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.KickOffMeeting.ToString());

            projectResponse.KickOffMeeting.SharepointLink.Should().Be(request.KickOffMeeting.SharepointLink);
            projectResponse.KickOffMeeting.RealisticYearOfOpening.Should().Be(request.KickOffMeeting.RealisticYearOfOpening);
            projectResponse.KickOffMeeting.ProvisionalOpeningDate.Should().Be(request.KickOffMeeting.ProvisionalOpeningDate);
            projectResponse.KickOffMeeting.FundingArrangementAgreed.Should().Be(request.KickOffMeeting.FundingArrangementAgreed);
            projectResponse.KickOffMeeting.FundingArrangementDetailsAgreed.Should().Be(request.KickOffMeeting.FundingArrangementDetailsAgreed);
        }
    }
}
