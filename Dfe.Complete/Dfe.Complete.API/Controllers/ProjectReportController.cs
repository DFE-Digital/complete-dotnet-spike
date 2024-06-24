using Dfe.Complete.API.UseCases.Project.Reports;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.Complete.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/projects/reports")]
    [Tags("Project reports")]
    [ApiController]
    public class ProjectReportController : ControllerBase
    {
        private readonly IAcademiesDueToTransferReportService _academiesDueToTransferReportService;

        public ProjectReportController(IAcademiesDueToTransferReportService academiesDueToTransferReportService)
        {
            _academiesDueToTransferReportService = academiesDueToTransferReportService;
        }

        [HttpGet]
        [Route("academies-due-to-transfer")]
        public async Task<FileStreamResult> GetAcademiesDueToTransfer()
        {
            var csvStream = await _academiesDueToTransferReportService.Execute();
            csvStream.Position = 0;

            var now = DateTime.Now.Date.ToString("yyyy-MM-dd");
            var fileName = $"{now}_academies_due_to_transfer.csv";

            return File(csvStream, "text/csv", fileName);
        }
    }
}
