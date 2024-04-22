using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ProjectRiskApiTests : ApiTestsBase
    {
        public ProjectRiskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task When_Post_NoExistingRisk_Returns_200()
        {
            var today = DateTime.Now;

            var createProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();

            var project = await CreateProject();

            var createProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", createProjectRiskRequest.ConvertToJson());
            createProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var getProjectRiskResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectId}/risk");
            getProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectRiskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectRiskResponse>>();
            var projectRisk = content.Data;

            AssertProjectRisk(projectRisk, createProjectRiskRequest);

            projectRisk.History.Should().HaveCount(1);
            var history = projectRisk.History.First();
            history.RiskRating.Should().Be(createProjectRiskRequest.Overall.RiskRating);
            history.Date.Value.Date.Should().Be(today.Date);
        }

        [Fact]
        public async Task When_Post_MultipleRisks_Returns_LatestRisk_200()
        {
            var today = DateTime.Now;

            var firstCreateProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();
            var secondCreateProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();

            var project = await CreateProject();

            var firstCreateProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", firstCreateProjectRiskRequest.ConvertToJson());
            firstCreateProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var secondCreateProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", secondCreateProjectRiskRequest.ConvertToJson());
            secondCreateProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var getProjectRiskResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectId}/risk");
            getProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectRiskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectRiskResponse>>();
            var projectRisk = content.Data;

            AssertProjectRisk(projectRisk, secondCreateProjectRiskRequest);

            projectRisk.History.Should().HaveCount(2);

            var latestHistory = projectRisk.History.First();
            latestHistory.RiskRating.Should().Be(secondCreateProjectRiskRequest.Overall.RiskRating);
            latestHistory.Date.Value.Date.Should().Be(today.Date);

            var previousHistory = projectRisk.History.Last();
            previousHistory.RiskRating.Should().Be(firstCreateProjectRiskRequest.Overall.RiskRating);
            previousHistory.Date.Value.Date.Should().Be(today.Date);
        }

        [Fact]
        public async Task When_Post_MinimumFields_Returns_200()
        {
            var projectRiskRequest = new CreateProjectRiskRequest()
            {
                Overall = new()
                {
                    RiskRating = ProjectRiskRating.Green
                }
            };

            var project = await CreateProject();

            var createProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", projectRiskRequest.ConvertToJson());
            createProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var getProjectRiskResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectId}/risk");
            getProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectRiskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectRiskResponse>>();
            var projectRisk = content.Data;

            projectRisk.Overall.RiskRating.Should().Be(projectRiskRequest.Overall.RiskRating);
            projectRisk.Overall.Summary.Should().BeNull();
        }

        [Fact]
        public async Task When_Post_NoChange_CreatesEntry_Returns_200()
        {
            var today = DateTime.Now;

            var projectRiskRequest = new CreateProjectRiskRequest()
            {
                Overall = new()
                {
                    RiskRating = ProjectRiskRating.Green
                }
            };

            var project = await CreateProject();

            var firstCreateProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", projectRiskRequest.ConvertToJson());
            firstCreateProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var secondCreateProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", projectRiskRequest.ConvertToJson());
            secondCreateProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var getProjectRiskResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectId}/risk");
            getProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectRiskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectRiskResponse>>();
            var projectRisk = content.Data;

            projectRisk.Overall.RiskRating.Should().Be(projectRiskRequest.Overall.RiskRating);
            projectRisk.History.Should().HaveCount(2);

            var latestHistory = projectRisk.History.First();
            latestHistory.RiskRating.Should().Be(projectRiskRequest.Overall.RiskRating);
            latestHistory.Date.Value.Date.Should().Be(today.Date);

            var previousHistory = projectRisk.History.Last();
            previousHistory.RiskRating.Should().Be(projectRiskRequest.Overall.RiskRating);
            previousHistory.Date.Value.Date.Should().Be(today.Date);
        }

        [Fact]
        public async Task When_Get_ByEntry_Returns_RiskByEntry_200() 
        {
            var firstCreateProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();
            var secondCreateProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();
            var thirdCreateProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();

            var project = await CreateProject();

            var firstCreateProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", firstCreateProjectRiskRequest.ConvertToJson());
            firstCreateProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var secondCreateProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", secondCreateProjectRiskRequest.ConvertToJson());
            secondCreateProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var thirdCreateProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", thirdCreateProjectRiskRequest.ConvertToJson());
            thirdCreateProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var getProjectRiskResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectId}/risk?entry=3");
            getProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectRiskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectRiskResponse>>();
            var projectRisk = content.Data;

            AssertProjectRisk(projectRisk, firstCreateProjectRiskRequest);
        }

        [Fact]
        public async Task When_Get_ProjectRiskEntryOutOfBounds_Returns_204()
        {
            var firstCreateProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();

            var project = await CreateProject();

            var firstCreateProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{project.ProjectId}/risk", firstCreateProjectRiskRequest.ConvertToJson());
            firstCreateProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var getProjectRiskResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectId}/risk?entry=3");
            getProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectRiskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectRiskResponse>>();
            var projectRisk = content.Data;

            AssertEmptyResponse(projectRisk);
        }

        [Fact]
        public async Task When_Get_ProjectRiskDoesNotExist_Should_Return_204()
        {
            var project = await CreateProject();

            var getProjectRiskResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectId}/risk");
            getProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectRiskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectRiskResponse>>();
            var projectRisk = content.Data;

            AssertEmptyResponse(projectRisk);
        }

        [Fact]
        public async Task When_Get_WithEmptyEntry_Returns_DefaultValues_200()
        {
            var project = await CreateProject();

            using var context = _testFixture.GetContext();

            var dbProject = context.Kpi.First(x => x.ProjectStatusProjectId == project.ProjectId);

            Rag risk = new Rag()
            {
                Rid = dbProject.Rid
            };

            context.Rag.Add(risk);

            await context.SaveChangesAsync();

            var getProjectRiskResponse = await _client.GetAsync($"/api/v1/client/projects/{project.ProjectId}/risk");
            getProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getProjectRiskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectRiskResponse>>();
            var projectRisk = content.Data;

            var today = DateTime.Now;

            projectRisk.Date.Value.Date.Should().Be(today.Date);
            projectRisk.Education.RiskRating.Should().BeNull();
            projectRisk.Education.Summary.Should().BeNull();
            projectRisk.Finance.RiskRating.Should().BeNull();
            projectRisk.Finance.Summary.Should().BeNull();
            projectRisk.GovernanceAndSuitability.RiskRating.Should().BeNull();
            projectRisk.GovernanceAndSuitability.Summary.Should().BeNull();
            projectRisk.Overall.RiskRating.Should().BeNull();
            projectRisk.Overall.Summary.Should().BeNull();
            projectRisk.RiskAppraisalFormSharepointLink.Should().BeNull();

            projectRisk.History.Should().HaveCount(1);
            var history = projectRisk.History.First();
            history.RiskRating.Should().BeNull();
            history.Date.Value.Date.Should().Be(today.Date);
        }


        [Fact]
        public async Task When_Post_NoExistingProject_Returns_404()
        {
            var projectId = 1000000;

            var createProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();

            var createProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/{projectId}/risk", createProjectRiskRequest.ConvertToJson());
            createProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task When_Post_InvalidRequest_Returns_400()
        {
            var createProjectRiskRequest = _autoFixture.Create<CreateProjectRiskRequest>();
            
            createProjectRiskRequest.Education.RiskRating = (ProjectRiskRating)12;
            createProjectRiskRequest.Education.Summary = new string('a', 1001);

            createProjectRiskRequest.Finance.RiskRating = (ProjectRiskRating)12;
            createProjectRiskRequest.Finance.Summary = new string('a', 1001);

            createProjectRiskRequest.GovernanceAndSuitability.RiskRating = (ProjectRiskRating)12;
            createProjectRiskRequest.GovernanceAndSuitability.Summary = new string('a', 1001);

            createProjectRiskRequest.Overall.RiskRating = (ProjectRiskRating)12;
            createProjectRiskRequest.Overall.Summary = new string('a', 1001);

            createProjectRiskRequest.RiskAppraisalFormSharepointLink = new string('a', 1001);

            var createProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/1/risk", createProjectRiskRequest.ConvertToJson());
            createProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var error = await createProjectRiskResponse.Content.ReadAsStringAsync();
            error.Should().Contain("'Governance And Suitability Risk Rating' has a range of values which does not include '12'");
            error.Should().Contain("'Governance And Suitability Summary' must be 1000 characters");

            error.Should().Contain("'Education Risk Rating' has a range of values which does not include '12'");
            error.Should().Contain("'Education Summary' must be 1000 characters");

            error.Should().Contain("'Finance Risk Rating' has a range of values which does not include '12'");
            error.Should().Contain("'Finance Summary' must be 1000 characters");

            error.Should().Contain("'Overall Risk Rating' has a range of values which does not include '12'");
            error.Should().Contain("'Overall Summary' must be 1000 characters");

            error.Should().Contain("'Risk Appraisal Form Sharepoint Link' must be 1000 characters");
        }

        [Fact]
        public async Task When_Post_InvalidRequest_MissingRequired_Returns_400()
        {
            var createProjectRiskRequest = new CreateProjectRiskRequest();

            var createProjectRiskResponse = await _client.PostAsync($"/api/v1/client/projects/1/risk", createProjectRiskRequest.ConvertToJson());
            createProjectRiskResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var error = await createProjectRiskResponse.Content.ReadAsStringAsync();
            error.Should().Contain("'Overall Risk Rating' must not be empty");
        }

        private async Task<ProjectResponseDetails> CreateProject()
        {
            var createProjectRequest = new CreateProjectRequest
            {
                Projects = new List<ProjectDetails>()
            };

            var project = _autoFixture.Create<ProjectDetails>();
            
            using var context = _testFixture.GetContext();
            
            var trust = DatabaseModelBuilder.BuildTrust();
            
            var truncatedTRN = project.TRN.Substring(0, 5);
            
            project.TRN = truncatedTRN;
            trust.TrustRef = truncatedTRN;
            project.ApplicationWave = DatabaseModelBuilder.CreateProjectWave();

            context.Trust.Add(trust);
            await context.SaveChangesAsync();
            
            project.ProjectId = DatabaseModelBuilder.CreateProjectId();
            createProjectRequest.Projects.Add(project);

            var response = await _client.PostAsync($"/api/v1/client/projects/create", createProjectRequest.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var content = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<CreateProjectResponse>>();

            return content.Data.Projects.First();
        }

        private static void AssertProjectRisk(GetProjectRiskResponse actual, CreateProjectRiskRequest expected)
        {
            var today = DateTime.Now;

            actual.Date.Value.Date.Should().Be(today.Date);

            actual.Education.RiskRating.Should().Be(expected.Education.RiskRating);
            actual.Education.Summary.Should().Be(expected.Education.Summary);

            actual.Finance.RiskRating.Should().Be(expected.Finance.RiskRating);
            actual.Finance.Summary.Should().Be(expected.Finance.Summary);

            actual.GovernanceAndSuitability.RiskRating.Should().Be(expected.GovernanceAndSuitability.RiskRating);
            actual.GovernanceAndSuitability.Summary.Should().Be(expected.GovernanceAndSuitability.Summary);

            actual.Overall.RiskRating.Should().Be(expected.Overall.RiskRating);
            actual.Overall.Summary.Should().Be(expected.Overall.Summary);

            actual.RiskAppraisalFormSharepointLink.Should().Be(expected.RiskAppraisalFormSharepointLink);
        }

        private static void AssertEmptyResponse(GetProjectRiskResponse projectRisk)
        {
            projectRisk.Date.Should().BeNull();
            projectRisk.GovernanceAndSuitability.RiskRating.Should().BeNull();
            projectRisk.GovernanceAndSuitability.Summary.Should().BeNull();

            projectRisk.Education.RiskRating.Should().BeNull();
            projectRisk.Education.Summary.Should().BeNull();

            projectRisk.Finance.RiskRating.Should().BeNull();
            projectRisk.Finance.Summary.Should().BeNull();

            projectRisk.Overall.RiskRating.Should().BeNull();
            projectRisk.Overall.Summary.Should().BeNull();

            projectRisk.RiskAppraisalFormSharepointLink.Should().BeNull();

            projectRisk.History.Should().HaveCount(0);
        }
    }
}
