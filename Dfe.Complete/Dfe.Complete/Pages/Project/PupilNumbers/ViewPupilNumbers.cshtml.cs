using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    public class ViewPupilNumbersModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetPupilNumbersResponse PupilNumbers { get; set; }

        public ProjectByTaskSummaryResponse ProjectTaskListSummary { get; set; }

        [BindProperty(SupportsGet = true, Name = "fromSaveForm")]
        public bool ShowBanner { get; set; }

        private readonly IGetPupilNumbersService _getPupilNumbersService;
        private readonly IGetProjectByTaskSummaryService _getProjectByTaskSummaryService;

        public ViewPupilNumbersModel(
            IGetPupilNumbersService getPupilNumbersService, 
            IGetProjectByTaskSummaryService getProjectByTaskSummaryService)
        {
            _getPupilNumbersService = getPupilNumbersService;
            _getProjectByTaskSummaryService = getProjectByTaskSummaryService;
        }

        public async Task<IActionResult> OnGet()
        {
            PupilNumbers = await _getPupilNumbersService.Execute(ProjectId);
            ProjectTaskListSummary = await _getProjectByTaskSummaryService.Execute(ProjectId);

            return Page();
        }
    }
}
