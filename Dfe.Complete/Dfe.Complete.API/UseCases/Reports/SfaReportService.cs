using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Reports
{
    public interface ISfaReportService
    {
        public Task<MemoryStream> Execute();
    }

    public class SfaReportService : ISfaReportService
    {
        private readonly MfspContext _context;

        public SfaReportService(MfspContext context)
        {
            _context = context;
        }

        public async Task<MemoryStream> Execute()
        {
            var reportSourceData = await (from kpi in _context.Kpi
                                          join bs in _context.Bs on kpi.Rid equals bs.Rid into bsJoin
                                          from bs in bsJoin.DefaultIfEmpty()
                                          join po in _context.Po on kpi.Rid equals po.Rid into poJoin
                                          from po in poJoin.DefaultIfEmpty()
                                          join opens in _context.Opens on kpi.Rid equals opens.Rid into opensJoin
                                          from opens in opensJoin.DefaultIfEmpty()
                                          select new SfaReportSourceData
                                          {
                                              Kpi = kpi,
                                              Po = po,
                                              Opens = opens,
                                              Bs = bs
                                          }).ToListAsync();

            var report = SfaReportBuilder.Build(reportSourceData);

            var memoryStream = WriteCsv(report);

            return memoryStream;
        }

        private MemoryStream WriteCsv(SfaReport report)
        {
            MemoryStream memoryStream = new MemoryStream();

            using StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8, leaveOpen: true);

            var entryProperties = typeof(SfaReportEntry).GetProperties();
            var headers = entryProperties.Select(GetHeaderName).ToArray();

            writer.WriteLine(string.Join(",", headers));

            foreach (var project in report.Projects)
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

    public class SfaReportSourceData
    {
        public Kpi Kpi { get; set; }
        public Po Po { get; set; }
        public Opens Opens { get; set; }
        public Bs Bs { get; set; }
    }
}
