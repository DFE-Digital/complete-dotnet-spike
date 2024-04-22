using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
	public class ProjectApiTests : ApiTestsBase
	{
		public ProjectApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
		{
		}

        [Fact]
        public async Task When_CreateProject_Returns_NewProjectFields_201()
        {
            using var context = _testFixture.GetContext();
            var trust = DatabaseModelBuilder.BuildTrust();

            context.Trust.Add(trust);
            await context.SaveChangesAsync();

            var projectDetails = _autoFixture.Create<ProjectDetails>();
            projectDetails.SchoolType = SchoolType.Mainstream;
            projectDetails.SchoolPhase = SchoolPhase.Primary;
            projectDetails.Nursery = ClassType.Nursery.Yes;

            projectDetails.ApplicationWave = DatabaseModelBuilder.CreateProjectWave();

            var request = new CreateProjectRequest();
            projectDetails.TRN = trust.TrustRef;
            request.Projects.Add(projectDetails);

            var projectId = DatabaseModelBuilder.CreateProjectId();
            request.Projects[0].ProjectId = projectId;

            var createProjectResponse = await _client.PostAsync($"/api/v1/client/projects/create", request.ConvertToJson());

            createProjectResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createProjectContent  = await createProjectResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<CreateProjectResponse>>();

            createProjectContent.Data.Projects.Should().HaveCount(1);
            createProjectContent.Data.Projects[0].ProjectId.Should().Be(projectId);

            // Check the database because there isn't an API that surfaces the information from create
            var createdProject = context.Kpi.First(p => p.ProjectStatusProjectId == projectId);
            var createdPo = context.Po.First(p => p.Rid == createdProject.Rid);

            createdProject.Rid.Should().HaveLength(11);
            createdProject.ProjectStatusProjectId.Should().Be(projectDetails.ProjectId);
            createdProject.ProjectStatusCurrentFreeSchoolName.Should().Be(projectDetails.SchoolName);
            createdProject.ProjectStatusFreeSchoolApplicationWave.Should().Be(projectDetails.ApplicationWave);
            createdProject.ProjectStatusFreeSchoolsApplicationNumber.Should().BeEmpty();
            createdProject.AprilIndicator.Should().BeEmpty();
            createdProject.Wave.Should().Be(projectDetails.ApplicationWave);
            createdProject.UpperStatus.Should().BeEmpty();
            createdProject.FsType.Should().BeEmpty();
            createdProject.FsType1.Should().BeEmpty();
            createdProject.MatUnitProjects.Should().BeEmpty();
            createdProject.SponsorUnitProjects.Should().BeEmpty();
            createdProject.SchoolDetailsGeographicalRegion.Should().Be(projectDetails.Region);
            createdProject.SchoolDetailsLocalAuthority.Should().Be(projectDetails.LocalAuthorityCode);
            createdProject.LocalAuthority.Should().Be(projectDetails.LocalAuthority);
            createdProject.SchoolDetailsSchoolTypeMainstreamApEtc.Should().Be("FS - Mainstream");
            createdProject.SchoolDetailsSchoolPhasePrimarySecondary.Should().Be("Primary");
            createdProject.TrustId.Should().Be(trust.TrustRef);
            createdProject.TrustName.Should().Be(trust.TrustsTrustName);
            createdProject.TrustType.Should().Be(trust.TrustsTrustType);
            createdProject.SchoolDetailsTrustId.Should().Be(trust.TrustsTrustRef);
            createdProject.SchoolDetailsTrustName.Should().Be(trust.TrustsTrustName);
            createdProject.SchoolDetailsTrustType.Should().Be(trust.TrustsTrustType);
            createdProject.SchoolDetailsSixthForm.Should().Be(projectDetails.SixthForm.ToString());
            createdProject.SchoolDetailsNursery.Should().Be(projectDetails.Nursery.ToString());
            createdProject.SchoolDetailsAlternativeProvision.Should().Be(projectDetails.AlternativeProvision.ToString());
            createdProject.SchoolDetailsSpecialEducationNeeds.Should().Be(projectDetails.SpecialEducationNeeds.ToString());
            createdProject.SchoolDetailsAgeRange.Should().Be(projectDetails.AgeRange);
            createdProject.SchoolDetailsNumberOfFormsOfEntry.Should().Be(projectDetails.FormsOfEntry);
            createdProject.SchoolDetailsFaithStatus.Should().Be(projectDetails.FaithStatus.ToString());
            createdProject.SchoolDetailsFaithType.Should().Be(projectDetails.FaithType.ToDescription());
            createdProject.SchoolDetailsPleaseSpecifyOtherFaithType.Should().Be(projectDetails.OtherFaithType);
            createdProject.ProjectStatusProvisionalOpeningDateAgreedWithTrust.Value.Date.Should().Be(projectDetails.ProvisionalOpeningDate.Value.Date);

            createdPo.Rid.Should().Be(createdProject.Rid);
            createdPo.PupilNumbersAndCapacityNurseryUnder5s.Should().Be(projectDetails.NurseryCapacity.ToString());
            createdPo.PupilNumbersAndCapacityYrY6Capacity.Should().Be(projectDetails.YRY6Capacity.ToString());
            createdPo.PupilNumbersAndCapacityY7Y11Capacity.Should().Be(projectDetails.Y7Y11Capacity.ToString());
            createdPo.PupilNumbersAndCapacityYrY11Pre16Capacity.Should().Be((projectDetails.YRY6Capacity + projectDetails.Y7Y11Capacity).ToString());
            createdPo.PupilNumbersAndCapacityY12Y14Post16Capacity.Should().Be(projectDetails.Y12Y14Capacity.ToString());
            createdPo.PupilNumbersAndCapacityTotalOfCapacityTotals.Should().Be((projectDetails.NurseryCapacity + projectDetails.YRY6Capacity + projectDetails.Y7Y11Capacity + projectDetails.Y12Y14Capacity).ToString());
        }

        [Fact]
        public async Task When_CreateProject_NurseryNo_Returns_CorrectTotals_201()
        {
            using var context = _testFixture.GetContext();
            var trust = DatabaseModelBuilder.BuildTrust();

            context.Trust.Add(trust);
            await context.SaveChangesAsync();

            var projectDetails = _autoFixture.Create<ProjectDetails>();
            projectDetails.Nursery = ClassType.Nursery.No;

            var request = new CreateProjectRequest();
            projectDetails.TRN = trust.TrustRef;

            projectDetails.ApplicationWave = DatabaseModelBuilder.CreateProjectWave();

            request.Projects.Add(projectDetails);

            var projectId = DatabaseModelBuilder.CreateProjectId();
            request.Projects[0].ProjectId = projectId;

            var createProjectResponse = await _client.PostAsync($"/api/v1/client/projects/create", request.ConvertToJson());
            createProjectResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createProjectContent = await createProjectResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<CreateProjectResponse>>();
            createProjectContent.Data.Projects.Should().HaveCount(1);
            createProjectContent.Data.Projects[0].ProjectId.Should().Be(projectId);

            var createdProject = context.Kpi.First(p => p.ProjectStatusProjectId == projectId);
            var createdPo = context.Po.First(p => p.Rid == createdProject.Rid);

            createdPo.PupilNumbersAndCapacityNurseryUnder5s.Should().Be("0");
            createdPo.PupilNumbersAndCapacityTotalOfCapacityTotals.Should().Be((projectDetails.YRY6Capacity + projectDetails.Y7Y11Capacity + projectDetails.Y12Y14Capacity).ToString());

        }

        [Fact]
        public async Task When_CreateProjectBulk_Returns_NewProjectFields_201()
        {
            using var setupContext = _testFixture.GetContext();
            var trust1 = DatabaseModelBuilder.BuildTrust();
            var trust2 = DatabaseModelBuilder.BuildTrust();
            var trust3 = DatabaseModelBuilder.BuildTrust();

            setupContext.Trust.Add(trust1);
            setupContext.Trust.Add(trust2);
            setupContext.Trust.Add(trust3);
            await setupContext.SaveChangesAsync();

            var proj1 = _autoFixture.Create<ProjectDetails>();
            var proj2 = _autoFixture.Create<ProjectDetails>();
            var proj3 = _autoFixture.Create<ProjectDetails>();

            CreateProjectRequest request = new CreateProjectRequest();

            proj1.TRN = trust1.TrustRef;
            proj2.TRN = trust2.TrustRef;
            proj3.TRN = trust3.TrustRef;

            proj1.ApplicationWave = DatabaseModelBuilder.CreateProjectWave();
            proj2.ApplicationWave = DatabaseModelBuilder.CreateProjectWave();
            proj3.ApplicationWave = DatabaseModelBuilder.CreateProjectWave();


            request.Projects.AddRange(new List<ProjectDetails>
            {
                proj1,
                proj2,
                proj3
            });

            foreach (ProjectDetails p in request.Projects)
            {
                p.ProjectId = DatabaseModelBuilder.CreateProjectId();
            }

            var result = await _client.PostAsync($"/api/v1/client/projects/create", request.ConvertToJson());

            result.StatusCode.Should().Be(HttpStatusCode.Created);

            using var context = _testFixture.GetContext();

            var createdProject1 = context.Kpi.First(p => p.ProjectStatusProjectId == request.Projects[0].ProjectId);
            var createdProject2 = context.Kpi.First(p => p.ProjectStatusProjectId == request.Projects[1].ProjectId);
            var createdProject3 = context.Kpi.First(p => p.ProjectStatusProjectId == request.Projects[2].ProjectId);

            createdProject1.ProjectStatusProjectId.Should().Be(request.Projects[0].ProjectId);
            createdProject2.ProjectStatusProjectId.Should().Be(request.Projects[1].ProjectId);
            createdProject3.ProjectStatusProjectId.Should().Be(request.Projects[2].ProjectId);

        }

        [Fact]
        public async Task When_CreateProject_Returns_Duplicate_422()
        {
            using var setupContext = _testFixture.GetContext();
            var trust = DatabaseModelBuilder.BuildTrust();

            setupContext.Trust.Add(trust);
            await setupContext.SaveChangesAsync();

            var proj1 = _autoFixture.Create<ProjectDetails>();

            CreateProjectRequest request = new CreateProjectRequest();
            proj1.TRN = trust.TrustRef;
            proj1.ApplicationWave = DatabaseModelBuilder.CreateProjectWave();
            request.Projects.Add(proj1);

            var projectId = DatabaseModelBuilder.CreateProjectId();
            request.Projects[0].ProjectId = projectId;

            var result = await _client.PostAsync($"/api/v1/client/projects/create", request.ConvertToJson());

            result.StatusCode.Should().Be(HttpStatusCode.Created);

            var result2 = await _client.PostAsync($"/api/v1/client/projects/create", request.ConvertToJson());

            result2.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
            var content = await result2.Content.ReadAsStringAsync();

            content.Should().Contain($"The following project(s) already exist: {projectId}");
        }

        [Fact]
        public async Task When_CreateProject_TrustDoesNotExist_Returns_422()
        {
            var context = _testFixture.GetContext();
            context.Trust.Add(DatabaseModelBuilder.BuildTrust());
            await context.SaveChangesAsync();

            var projectDetails = _autoFixture.Create<ProjectDetails>();
            projectDetails.ProjectId = DatabaseModelBuilder.CreateProjectId();

            var request = new CreateProjectRequest()
            {
                Projects = new List<ProjectDetails> { projectDetails }
            };

            var response = await _client.PostAsync($"/api/v1/client/projects/create", request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
            
            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"The trust does not exist: {projectDetails.TRN}");
        }

        [Fact]
        public async Task When_CreateProject_InvalidRequest_Returns_400()
        {
            var request = new CreateProjectRequest()
            {
                Projects = new List<ProjectDetails>()
                {
                    new ProjectDetails()
                }
            };

            var response = await _client.PostAsync($"/api/v1/client/projects/create", request.ConvertToJson());

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain("'TRN' must not be empty.");
            content.Should().Contain("'Project Id' must not be empty.");
            content.Should().Contain("'Created By' must not be empty.");
        }
    }
}

