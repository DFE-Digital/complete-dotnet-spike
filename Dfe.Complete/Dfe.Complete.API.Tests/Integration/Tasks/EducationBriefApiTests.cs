using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks;

  [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class EducationBriefTaskApiTests : ApiTestsBase
    {
        public EducationBriefTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewEducationBrief_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();
            
            var request = new UpdateProjectByTaskRequest()
            {
                EducationBrief = new EducationBriefTask()
                {
                    EducationPlanInEducationBrief = true,
                    EducationPolicesInEducationBrief = null,
                    PupilAssessmentAndTrackingHistoryInPlace = false,
                    EducationBriefSavedToWorkplaces = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.EducationBrief.ToString());

            projectResponse.EducationBrief.EducationPlanInEducationBrief.Should().Be(request.EducationBrief.EducationPlanInEducationBrief);
            projectResponse.EducationBrief.EducationPolicesInEducationBrief.Should().Be(request.EducationBrief.EducationPolicesInEducationBrief);
            projectResponse.EducationBrief.PupilAssessmentAndTrackingHistoryInPlace.Should().Be(request.EducationBrief.PupilAssessmentAndTrackingHistoryInPlace);
            projectResponse.EducationBrief.EducationBriefSavedToWorkplaces.Should().Be(request.EducationBrief.EducationBriefSavedToWorkplaces);
        }

        [Fact]
        public async Task Patch_EducationBriefMeeting_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var educationBriefTask = DatabaseModelBuilder.BuildEducationBriefTask(project.Rid);
            context.Milestones.Add(educationBriefTask);

            await context.SaveChangesAsync();
            
            var request = new UpdateProjectByTaskRequest()
            {
                EducationBrief = new EducationBriefTask()
                {
                    EducationPlanInEducationBrief = true,
                    EducationPolicesInEducationBrief = null,
                    PupilAssessmentAndTrackingHistoryInPlace = false,
                    EducationBriefSavedToWorkplaces = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.EducationBrief.ToString());

            projectResponse.EducationBrief.EducationPlanInEducationBrief.Should().Be(request.EducationBrief.EducationPlanInEducationBrief);
            projectResponse.EducationBrief.EducationPolicesInEducationBrief.Should().Be(request.EducationBrief.EducationPolicesInEducationBrief);
            projectResponse.EducationBrief.PupilAssessmentAndTrackingHistoryInPlace.Should().Be(request.EducationBrief.PupilAssessmentAndTrackingHistoryInPlace);
            projectResponse.EducationBrief.EducationBriefSavedToWorkplaces.Should().Be(request.EducationBrief.EducationBriefSavedToWorkplaces);
        }
    }