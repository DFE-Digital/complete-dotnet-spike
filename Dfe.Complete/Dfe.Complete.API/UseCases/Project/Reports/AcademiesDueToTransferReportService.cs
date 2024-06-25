using Dfe.Complete.API.Extensions;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Dfe.Complete.API.UseCases.Project.Reports
{
    public interface IAcademiesDueToTransferReportService
    {
        public Task<MemoryStream> Execute();
    }

    public class AcademiesDueToTransferReportService : IAcademiesDueToTransferReportService
    {
        private readonly CompleteContext _context;
        private readonly IGetEstablishmentAndTrustService _getEstablishmentAndTrustService;

        public AcademiesDueToTransferReportService(
            CompleteContext context, IGetEstablishmentAndTrustService getEstablishmentAndTrustService)
        {
            _context = context;
            _getEstablishmentAndTrustService = getEstablishmentAndTrustService;
        }

        public async Task<MemoryStream> Execute()
        {
            var projects = _context.Projects.Include(p => p.AssignedTo);

            var transferProjects = await _context
                .GetTransferProjects(projects)
                .Where(t => t.Project.Urn == 142278)
                .ToListAsync();

            var urns = transferProjects.Select(p => p.Project.Urn).ToList();
            var outgoingUkPrns = transferProjects.Select(p => p.Project.OutgoingTrustUkprn).ToList();
            var incomingUkPrns = transferProjects.Select(p => p.Project.IncomingTrustUkprn).ToList();

            var establishmentAndTrustLookup = await _getEstablishmentAndTrustService.Execute(urns, incomingUkPrns, outgoingUkPrns);

            var entries = BuildEntries(transferProjects, establishmentAndTrustLookup);

            return WriteCsv(entries);
        }

        private List<AcademiesDueToTransferReportEntry> BuildEntries(
            List<TransferProject> transferProjects,
            GetMultipleEstablishmentAndTrustResponse establishmentAndTrustLookup)
        {
            List<AcademiesDueToTransferReportEntry> result = new List<AcademiesDueToTransferReportEntry>();

            foreach (var transferProject in transferProjects)
            {
                var establishment = establishmentAndTrustLookup.Establishments[transferProject.Project.Urn.ToString()];
                var incomingTrust = establishmentAndTrustLookup.Trusts[transferProject.Project.IncomingTrustUkprn?.ToString()];
                var outgoingTrust = establishmentAndTrustLookup.Trusts[transferProject.Project.OutgoingTrustUkprn?.ToString()];

                var entry = new AcademiesDueToTransferReportEntry()
                {
                    SchoolUrn = transferProject.Project.Urn.ToString(),
                    AssignedToEmail = transferProject.Project.AssignedTo?.Email,
                    TwoRequiresImprovement = ToYesNoString(transferProject.Project.TwoRequiresImprovement),
                    TransferDueToInadequate = ToYesNoString(transferProject.TaskData.InadequateOfsted),
                    TransferDueToIssues = ToYesNoString(transferProject.TaskData.FinancialSafeguardingGovernanceIssues),
                    OutgoingTrustToClose = ToYesNoString(transferProject.TaskData.OutgoingTrustToClose),
                    NewUrnRequested = ToYesNoString(transferProject.Project.AcademyUrn.HasValue),
                    BankDetailsChanging = ToYesNoString(transferProject.TaskData.BankDetailsChangingYesNo),
                    TeamManagingTheProject = transferProject.Project.Team.ToDescription(),
                    AuthorityToProceed = ToYesNoString(transferProject.Project.AllConditionsMet),
                    Region = transferProject.Project.Region.ToDescription(),
                    SchoolPhase = establishment?.PhaseOfEducation.Name,
                    SchoolAgeRange = establishment?.ToAgeRange(),
                    LocalAuthority = establishment?.LocalAuthorityName,
                    SchoolName = establishment?.Name,
                    IncomingTrustUkprn = incomingTrust?.Ukprn,
                    IncomingTrustCompaniesHouseNumber = incomingTrust?.CompaniesHouseNumber,
                    IncomingTrustName = incomingTrust?.Name,
                    OutgoingTrustUkprn = outgoingTrust?.Ukprn,
                    OutgoingTrustCompaniesHouseNumber = outgoingTrust?.CompaniesHouseNumber,
                    OutgoingTrustName = outgoingTrust?.Name,
                };

                result.Add(entry);
            }

            return result;
        }

        private string ToYesNoString(bool? value) => value == true ? "yes" : "no";

        private MemoryStream WriteCsv<T>(List<T> data)
        {
            MemoryStream memoryStream = new MemoryStream();

            using StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8, leaveOpen: true);

            var entryProperties = typeof(T).GetProperties();
            var headers = entryProperties.Select(GetHeaderName).ToArray();

            writer.WriteLine(string.Join(",", headers));

            foreach (var project in data)
            {
                var row = entryProperties.Select(p => p.GetValue(project)?.ToString()).ToArray();
                writer.WriteLine(string.Join(",", row));
            }

            writer.Flush();
            memoryStream.Position = 0;

            return memoryStream;
        }

        private string GetHeaderName(PropertyInfo propertyInfo)
        {
            var displayNameAttribute = (DisplayNameAttribute)propertyInfo.GetCustomAttribute(typeof(DisplayNameAttribute));
            return displayNameAttribute?.DisplayName;
        }

        public class AcademiesDueToTransferReportEntry
        {
            [DisplayName("School name")]
            public string SchoolName { get; set; }

            [DisplayName("School URN")]
            public string SchoolUrn { get; set; }

            [DisplayName("School phase")]
            public string SchoolPhase { get; set; }

            [DisplayName("School age range")]
            public string SchoolAgeRange { get; set; }

            [DisplayName("Local authority")]
            public string LocalAuthority { get; set; }

            [DisplayName("Transfer type")]
            public string TransferType { get; set; }

            [DisplayName("Outgoing trust name")]
            public string OutgoingTrustName { get; set; }

            [DisplayName("Outgoing trust companies house number")]
            public string OutgoingTrustCompaniesHouseNumber { get; set; }

            [DisplayName("Outgoing trust UKPRN")]
            public string OutgoingTrustUkprn { get; set; }

            [DisplayName("Incoming trust name")]
            public string IncomingTrustName { get; set; }

            [DisplayName("Incoming trust companies house number")]
            public string IncomingTrustCompaniesHouseNumber { get; set; }

            [DisplayName("Incoming trust UKPRN")]
            public string IncomingTrustUkprn { get; set; }

            [DisplayName("2RI (Two requires improvement)")]
            public string TwoRequiresImprovement { get; set; }

            [DisplayName("Transfer due to inadequate")]
            public string TransferDueToInadequate { get; set; }

            [DisplayName("Transfer due to financial safeguarding or governance")]
            public string TransferDueToIssues { get; set; }

            [DisplayName("Outgoing trust to close")]
            public string OutgoingTrustToClose { get; set; }

            [DisplayName("New URN/record requested")]
            public string NewUrnRequested { get; set; }

            [DisplayName("Bank details changing")]
            public string BankDetailsChanging { get; set; }

            [DisplayName("Region")]
            public string Region { get; set; }

            [DisplayName("Assigned to email")]
            public string AssignedToEmail { get; set; }

            [DisplayName("Team managing the project")]
            public string TeamManagingTheProject { get; set; }

            [DisplayName("Provisional transfer date")]
            public string ProvisionalTransferDate { get; set; }

            [DisplayName("Confirmed transfer date")]
            public string ConfirmedTransferDate { get; set; }

            [DisplayName("Authority to proceed")]
            public string AuthorityToProceed { get; set; }

            [DisplayName("Main contact name")]
            public string MainContactName { get; set; }

            [DisplayName("Main contact email")]
            public string MainContactEmail { get; set; }

            [DisplayName("Main contact role")]
            public string MainContactRole { get; set; }
        }
    }
}
