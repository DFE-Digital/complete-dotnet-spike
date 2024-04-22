using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.API.Tests.Utils;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class GetProjectTaskSummaryApiTests : ApiTestsBase
    {
        public GetProjectTaskSummaryApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task GetProjectTaskList_Returns_200()
        {
            using var context = _testFixture.GetContext();
            
            var project = DatabaseModelBuilder.BuildProject();
            context.Kpi.Add(project);
            
            var tasks = TasksStub.BuildListOfTasks(project.Rid);
            context.Tasks.AddRange(tasks);
            
            await context.SaveChangesAsync();

            var taskListResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectStatusProjectId}/tasks/summary");
            taskListResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await taskListResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<ProjectByTaskSummaryResponse>>();

            var result = content.Data;

            result.School.Name.Should().Be("School");
            result.School.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.Dates.Name.Should().Be("Dates");
            result.Dates.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.Trust.Name.Should().Be("Trust");
            result.Trust.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.Constituency.Name.Should().Be("Constituency");
            result.Constituency.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.KickOffMeeting.Name.Should().Be("KickOffMeeting");
            result.KickOffMeeting.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.ModelFundingAgreement.Name.Should().Be("ModelFundingAgreement");
            result.ModelFundingAgreement.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.StatutoryConsultation.Name.Should().Be("StatutoryConsultation");
            result.StatutoryConsultation.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.ArticlesOfAssociation.Name.Should().Be("ArticlesOfAssociation");
            result.ArticlesOfAssociation.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.FinancePlan.Name.Should().Be("FinancePlan");
            result.FinancePlan.Status.Should().Be(ProjectTaskStatus.NotStarted);

            result.DraftGovernancePlan.Name.Should().Be("DraftGovernancePlan");
            result.DraftGovernancePlan.Status.Should().Be(ProjectTaskStatus.NotStarted);

            result.AdmissionsArrangements.Name.Should().Be(TaskName.AdmissionsArrangements.ToString());
            result.AdmissionsArrangements.Status.Should().Be(ProjectTaskStatus.NotStarted);

            result.EqualitiesAssessment.Name.Should().Be("EqualitiesAssessment");
            result.EqualitiesAssessment.Status.Should().Be(ProjectTaskStatus.NotStarted);

            result.PDG.Name.Should().Be(TaskName.PDG.ToString());
            result.PDG.Status.Should().Be(ProjectTaskStatus.NotStarted);

            result.FinalFinancePlan.Name.Should().Be(TaskName.FinalFinancePlan.ToString());
            result.FinalFinancePlan.Status.Should().Be(ProjectTaskStatus.NotStarted);

            result.ApplicationsEvidence.Name.Should().Be(TaskName.ApplicationsEvidence.ToString());
            result.ApplicationsEvidence.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.ApplicationsEvidence.IsHidden.Should().BeFalse();
        }

        [Fact]
        public async Task GetProjectTaskList_ApplicationsEvidence_HiddenWithSchoolType_Returns_200()
        {
            using var context = _testFixture.GetContext();
            
            var project = DatabaseModelBuilder.BuildProject();
            project.SchoolDetailsSchoolTypeMainstreamApEtc = "FS - AP";

            context.Kpi.Add(project);

            await context.SaveChangesAsync();

            var taskListResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectStatusProjectId}/tasks/summary");
            taskListResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await taskListResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<ProjectByTaskSummaryResponse>>();

            var result = content.Data;

            result.ApplicationsEvidence.Name.Should().Be(TaskName.ApplicationsEvidence.ToString());
            result.ApplicationsEvidence.Status.Should().Be(ProjectTaskStatus.NotStarted);
            result.ApplicationsEvidence.IsHidden.Should().BeTrue();
        }

        [Fact]
        public async Task Get_ProjectTaskList_ProjectDoesNotExist_Returns_404()
        {
            var taskListResponse = await _client.GetAsync($"/api/v1/client/projects/NotExist/tasks/summary");
            taskListResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
