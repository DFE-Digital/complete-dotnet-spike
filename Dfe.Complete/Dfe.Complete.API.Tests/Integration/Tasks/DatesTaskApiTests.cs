using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System.Threading.Tasks;
using System;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class DatesTaskApiTests : ApiTestsBase
    {
        public DatesTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_DatesTask_Returns_201()
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
                Dates = new DatesTask()
                {
                    DateOfEntryIntoPreopening = DateTenDaysInFuture,
                    ProvisionalOpeningDateAgreedWithTrust = DateNineDaysInFuture,
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.Dates.ToString());

            projectResponse.Dates.DateOfEntryIntoPreopening.Should().Be(DateTenDaysInFuture);
            projectResponse.Dates.ProvisionalOpeningDateAgreedWithTrust.Should().Be(DateNineDaysInFuture);
            projectResponse.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);
        }
    }
}
