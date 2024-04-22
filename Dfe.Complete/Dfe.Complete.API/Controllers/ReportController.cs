using Dfe.ManageFreeSchoolProjects.API.UseCases.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [Route("api/v{version:apiVersion}/client/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IAllProjectsReportService _allProjectsReportService;
        private readonly ISfaReportService _sfaReportService;

        public ReportController(
            IAllProjectsReportService allProjectsReportService,
            ISfaReportService sfaReportService)
        {
            _allProjectsReportService = allProjectsReportService;
            _sfaReportService = sfaReportService;
        }

        [HttpGet("all-projects-export")]
        public async Task<FileStreamResult> GetAllProjects()
        {
            var excelStream = await _allProjectsReportService.Execute();
            excelStream.Position = 0;

            var now = DateTime.Now.Date.ToString("yyyy-MM-dd");
            var fileName = $"{now}-mfsp-all-projects-export.xlsx";

            return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [HttpGet("sfa-export")]
        public async Task<FileStreamResult> GetSfaExport()
        {
            var csvStream = await _sfaReportService.Execute();
            csvStream.Position = 0;

            var now = DateTime.Now.Date.ToString("yyyy-MM-dd");
            var fileName = $"{now}-mfsp-sfa-export.csv";

            return File(csvStream, "text/csv", fileName);
        }
    }
}
