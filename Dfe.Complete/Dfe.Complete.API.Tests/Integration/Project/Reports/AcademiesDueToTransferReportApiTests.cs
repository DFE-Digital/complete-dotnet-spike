using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using Dfe.Complete.Constants;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Reports
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class AcademiesDueToTransferReportApiTests : ApiTestsBase
    {
        public AcademiesDueToTransferReportApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {

        }

        [Fact]
        public async Task GetAcademiesDueToTransferReport_Returns_Correct_Data_200()
        {
            using var context = _testFixture.GetContext();
            var user = context.Users.First(u => u.Email == _testFixture.DefaultUser.Email);

            var transferProject = DatabaseModelBuilder.BuildTransferProject();

            transferProject.Project.AssignedToId = user.Id;

            context.Projects.Add(transferProject.Project);
            context.TransferTasksData.Add(transferProject.TaskData);

            await context.SaveChangesAsync();

            var response = await _client.GetAsync(RouteConstants.ProjectReportAcademiesDueToTransfer);
            response.StatusCode.Should().Be(HttpStatusCode.Found);
        }
    }
}
