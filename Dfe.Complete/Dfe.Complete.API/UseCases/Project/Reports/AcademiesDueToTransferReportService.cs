using Dfe.Complete.API.Contracts.Project.Reports;
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
                GetTrustResponse incomingTrust = null;
                GetTrustResponse outgoingTrust = null;

                var establishment = establishmentAndTrustLookup.Establishments[transferProject.Project.Urn.ToString()];

                if (transferProject.Project.IncomingTrustUkprn.HasValue)
                {
                    incomingTrust = establishmentAndTrustLookup.Trusts[transferProject.Project.IncomingTrustUkprn.ToString()];
                }

                if (transferProject.Project.OutgoingTrustUkprn.HasValue)
                {
                    outgoingTrust = establishmentAndTrustLookup.Trusts[transferProject.Project.OutgoingTrustUkprn.ToString()];
                }

                AcademiesDueToTransferReportEntry entry = BuildEntry(transferProject, establishment, incomingTrust, outgoingTrust);

                result.Add(entry);
            }

            return result;
        }

        private AcademiesDueToTransferReportEntry BuildEntry(
            TransferProject transferProject,
            GetEstablishmentResponse establishment,
            GetTrustResponse incomingTrust, 
            GetTrustResponse outgoingTrust)
        {
            return new AcademiesDueToTransferReportEntry()
            {
                SchoolUrn = transferProject.Project.Urn.ToString(),
                AssignedToEmail = transferProject.Project.AssignedTo?.Email,
                TransferType = "join a MAT",
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
    }
}
