using Dfe.ManageFreeSchoolProjects.API.Contracts.Http;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class AuditTests : ApiTestsBase
    {
        public AuditTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        // This test checks that audits are written for all the configured tables
        // Not all tables that have been configured for auditing are actually written to yet, this will happen in the future
        // The reason there is a separate test for this, is logically it makes sense to have all the audit tests in one place
        // This is because different apis write to the same tables, so having audit checking logic in some tasks and not others would be confusing
        // If we ever created our tables to more represent our task domain then it would make sense to check in each individual task
        [Fact]
        public async Task Audit_User()
        {
            var project = await CreateProject();
            await UpdateMilestones(project.ProjectId);
            await CreateProjectRisk(project.ProjectId);
            await UpdateRiskAppraisalMeeting(project.ProjectId);

            var context = _testFixture.GetContext();
            var kpi = await context.Kpi.FirstAsync(x => x.ProjectStatusProjectId == project.ProjectId);
            var user = await context.Users.FirstAsync(x => x.Email == _testFixture.DefaultUser);
            var milestones = await context.Milestones.FirstAsync(x => x.Rid == kpi.Rid);
            var po = await context.Po.FirstAsync(x => x.Rid == kpi.Rid);
            var rag = await context.Rag.FirstAsync(x => x.Rid == kpi.Rid);
            var riskAppraisalMeeting = await context.RiskAppraisalMeetingTask.FirstAsync(x => x.RID == kpi.Rid);
            var tasks = await context.Tasks.Where(x => x.Rid == kpi.Rid).ToListAsync();

            // All proposed tables we are going to use, not all are covered here because we haven't written to these tables yet
            //[dbo].[KPI]
            //[dbo].[Opens]
            //[dbo].[RAG]
            //[dbo].[Ofsted_FSG]
            //[dbo].[FS_KIM]
            //[dbo].[KAI]
            //[dbo].[PO]
            //[dbo].[Milestones]
            //[dbo].[constructData]
            //[dbo].[BS]
            //[dbo].Property

            kpi.UpdatedByUserId.Should().Be(user.Id);
            po.UpdatedByUserId.Should().Be(user.Id);
            milestones.UpdatedByUserId.Should().Be(user.Id);
            rag.UpdatedByUserId.Should().Be(user.Id);
            riskAppraisalMeeting.UpdatedByUserId.Should().Be(user.Id);

            var milestoneTask = tasks.First(x => x.TaskName == TaskName.School);
            milestoneTask.UpdatedByUserId.Should().Be(user.Id);

            var riskTask = tasks.First(x => x.TaskName == TaskName.RiskAppraisalMeeting);
            riskTask.UpdatedByUserId.Should().Be(user.Id);
        }

        [Fact]
        public async Task Audit_UserUnkown_SetsNull()
        {
            // Subject to change, but this is documenting the behaviour
            // Since we use an ID, we just have to set the user to null if we can't find them
            // **Should not** happen in reality
            var project = await CreateProject();

            using var beforeContext = _testFixture.GetContext();
            var user = await beforeContext.Users.FirstAsync(x => x.Email == _testFixture.DefaultUser);
            var kpi = await beforeContext.Kpi.FirstAsync(x => x.ProjectStatusProjectId == project.ProjectId);

            kpi.UpdatedByUserId.Should().Be(user.Id);

            var request = new UpdateProjectByTaskRequest()
            {
                School = _autoFixture.Create<SchoolTask>()
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Patch, $"/api/v1/client/projects/{project.ProjectId}/tasks")
            {
                Content = request.ConvertToJson(),
            };

            // override the header so that the user is not found
            requestMessage.Headers.Add(HttpHeaderConstants.UserContextName, _autoFixture.Create<string>());


            var response = await _client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            using var afterContext = _testFixture.GetContext();
            var kpiAfter = await afterContext.Kpi.FirstAsync(x => x.ProjectStatusProjectId == project.ProjectId);
            kpiAfter.UpdatedByUserId.Should().BeNull();
        }

        private async Task<ProjectResponseDetails> CreateProject()
        {
            using var context = _testFixture.GetContext();
            var trust = DatabaseModelBuilder.BuildTrust();

            context.Trust.Add(trust);
            await context.SaveChangesAsync();

            var projectDetails = _autoFixture.Create<ProjectDetails>();

            var request = new CreateProjectRequest();
            projectDetails.TRN = trust.TrustRef;

            projectDetails.ApplicationWave = DatabaseModelBuilder.CreateProjectWave();

            request.Projects.Add(projectDetails);

            var projectId = DatabaseModelBuilder.CreateProjectId();
            request.Projects[0].ProjectId = projectId;

            var createProjectResponse = await _client.PostAsync($"/api/v1/client/projects/create", request.ConvertToJson());
            createProjectResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createProjectContent = await createProjectResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<CreateProjectResponse>>();

            return createProjectContent.Data.Projects[0];
        }

        private async Task UpdateMilestones(string projectId)
        {
            var request = new UpdateProjectByTaskRequest()
            {
                DraftGovernancePlan = _autoFixture.Create<DraftGovernancePlanTask>()
            };

            await _client.UpdateProjectTask(projectId, request, TaskName.School.ToString());
        }

        private async Task CreateProjectRisk(string projectId)
        {
            var request = _autoFixture.Create<CreateProjectRiskRequest>();

            var response = await _client.PostAsJsonAsync($"/api/v1/client/projects/{projectId}/risk", request);
            response.EnsureSuccessStatusCode();
        }

        private async Task UpdateRiskAppraisalMeeting(string projectId)
        {
            var request = new UpdateProjectByTaskRequest()
            {
                RiskAppraisalMeeting = _autoFixture.Create<RiskAppraisalMeetingTask>()
            };

            await _client.UpdateProjectTask(projectId, request, TaskName.RiskAppraisalMeeting.ToString());
        }
    }
}
