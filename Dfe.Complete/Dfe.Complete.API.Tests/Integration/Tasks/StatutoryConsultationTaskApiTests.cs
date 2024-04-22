using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class StatutoryConsultationTaskApiTests : ApiTestsBase
    {
        public StatutoryConsultationTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewStatutoryConsultation_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var dateNineteenDaysInFuture = new DateTime().AddDays(19);
            var dateTwentyDaysInFuture = new DateTime().AddDays(20);

            var request = new UpdateProjectByTaskRequest()
            {
                StatutoryConsultation = new StatutoryConsultationTask()
                {
                    ExpectedDateForReceivingFindingsFromTrust = dateNineteenDaysInFuture,
                    ReceivedConsultationFindingsFromTrust = true,
                    DateReceived = dateTwentyDaysInFuture,
                    ConsultationFulfilsTrustSection10StatutoryDuty = true,
                    Comments = "The consultation has been completed with no issues.",
                    SavedFindingsInWorkplacesFolder = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.StatutoryConsultation.ToString());

            projectResponse.StatutoryConsultation.ExpectedDateForReceivingFindingsFromTrust.Should().Be(request.StatutoryConsultation.ExpectedDateForReceivingFindingsFromTrust);
            projectResponse.StatutoryConsultation.ReceivedConsultationFindingsFromTrust.Should().Be(request.StatutoryConsultation.ReceivedConsultationFindingsFromTrust);
            projectResponse.StatutoryConsultation.DateReceived.Should().Be(request.StatutoryConsultation.DateReceived);
            projectResponse.StatutoryConsultation.ConsultationFulfilsTrustSection10StatutoryDuty.Should().Be(request.StatutoryConsultation.ConsultationFulfilsTrustSection10StatutoryDuty);
            projectResponse.StatutoryConsultation.Comments.Should().Be(request.StatutoryConsultation.Comments);
            projectResponse.StatutoryConsultation.SavedFindingsInWorkplacesFolder.Should().Be(request.StatutoryConsultation.SavedFindingsInWorkplacesFolder);
        }

        [Fact]
        public async Task Patch_ExistingStatutoryConsultation_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var StatutoryConsultationTask = DatabaseModelBuilder.BuildStatutoryConsultationTask(project.Rid);
            context.Milestones.Add(StatutoryConsultationTask);

            await context.SaveChangesAsync();

            var dateNineteenDaysInFuture = new DateTime().AddDays(19);
            var dateTwentyDaysInFuture = new DateTime().AddDays(20);

            var request = new UpdateProjectByTaskRequest()
            {
                StatutoryConsultation = new StatutoryConsultationTask()
                {
                    ExpectedDateForReceivingFindingsFromTrust = dateNineteenDaysInFuture,
                    ReceivedConsultationFindingsFromTrust = true,
                    DateReceived = dateTwentyDaysInFuture,
                    ConsultationFulfilsTrustSection10StatutoryDuty = true,
                    Comments = "The consultation has been completed with no issues.",
                    SavedFindingsInWorkplacesFolder = true
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.StatutoryConsultation.ToString());

            projectResponse.StatutoryConsultation.ExpectedDateForReceivingFindingsFromTrust.Should().Be(request.StatutoryConsultation.ExpectedDateForReceivingFindingsFromTrust);
            projectResponse.StatutoryConsultation.ReceivedConsultationFindingsFromTrust.Should().Be(request.StatutoryConsultation.ReceivedConsultationFindingsFromTrust);
            projectResponse.StatutoryConsultation.DateReceived.Should().Be(request.StatutoryConsultation.DateReceived);
            projectResponse.StatutoryConsultation.ConsultationFulfilsTrustSection10StatutoryDuty.Should().Be(request.StatutoryConsultation.ConsultationFulfilsTrustSection10StatutoryDuty);
            projectResponse.StatutoryConsultation.Comments.Should().Be(request.StatutoryConsultation.Comments);
            projectResponse.StatutoryConsultation.SavedFindingsInWorkplacesFolder.Should().Be(request.StatutoryConsultation.SavedFindingsInWorkplacesFolder);
        }
    }
}
