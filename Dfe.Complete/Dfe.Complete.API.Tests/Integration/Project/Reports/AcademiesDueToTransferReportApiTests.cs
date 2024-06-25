using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Reports;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System;
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
            var createProjectRequest = _autoFixture.Create<CreateTransferProjectRequest>();
            createProjectRequest.Region = Region.NorthWest;
            createProjectRequest.Urn = "1002";
            createProjectRequest.IncomingTrustDetails.Ukprn = "10000001";
            createProjectRequest.OutgoingTrustDetails.Ukprn = "10000002";
            createProjectRequest.IsDueToIssues = true;
            createProjectRequest.IsDueToOfstedRating = true;

            var createProjectResponse = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createProjectResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var response = await _client.GetAsync(RouteConstants.ProjectReportAcademiesDueToTransfer);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var fileStreamResult = await response.Content.ReadAsStringAsync();

            var lines = CsvHelper.GetLines(fileStreamResult);
            lines.Should().HaveCountGreaterThan(1);

            CsvHelper.IsValidCsv(fileStreamResult).Should().BeTrue();

            var headers = CsvHelper.GetHeaders(fileStreamResult);
            var expectedColumns = headers.Count;

            var projectRow = lines.First(l => l.Split(",").ElementAt(1) == "1002");
            var values = projectRow.Split(",");
            values.Should().HaveCount(expectedColumns);

            var entry = CsvHelper.ToObject<AcademiesDueToTransferReportEntry>(values);

            entry.SchoolUrn.Should().Be("1002");
            entry.SchoolName.Should().Be("Transfer report");
            entry.SchoolPhase.Should().Be("Primary");
            entry.SchoolAgeRange.Should().Be("3-16");
            entry.LocalAuthority.Should().Be("Local authority 2");
            entry.TransferType.Should().Be("join a MAT");
            entry.OutgoingTrustName.Should().Be("Trust 2");
            entry.OutgoingTrustCompaniesHouseNumber.Should().Be("00002");
            entry.OutgoingTrustUkprn.Should().Be("10000002");
            entry.IncomingTrustName.Should().Be("Trust 1");
            entry.IncomingTrustCompaniesHouseNumber.Should().Be("00001");
            entry.IncomingTrustUkprn.Should().Be("10000001");
            entry.TwoRequiresImprovement.Should().Be("no");
            entry.TransferDueToInadequate.Should().Be("yes");
            entry.TransferDueToIssues.Should().Be("yes");
            entry.OutgoingTrustToClose.Should().Be("no");
            entry.NewUrnRequested.Should().Be("no");
            entry.BankDetailsChanging.Should().Be("no");
            entry.Region.Should().Be("North West");
            //entry.AssignedToEmail.Should().Be(createProjectRequest.AssignedToEmail);
            //entry.TeamManagingTheProject.Should().Be(createProjectRequest.TeamManagingTheProject);
            //entry.ProvisionalTransferDate.Should().Be(createProjectRequest.ProvisionalTransferDate.ToString("dd/MM/yyyy"));
            //entry.ConfirmedTransferDate.Should().Be(createProjectRequest.ConfirmedTransferDate.ToString("dd/MM/yyyy"));
            entry.AuthorityToProceed.Should().Be("no");
            //entry.MainContactName.Should().Be(createProjectRequest.MainContact.Name);
            //entry.MainContactEmail.Should().Be(createProjectRequest.MainContact.Email);
            //entry.MainContactRole.Should().Be(createProjectRequest.MainContact.Role);
        }
    }
}
