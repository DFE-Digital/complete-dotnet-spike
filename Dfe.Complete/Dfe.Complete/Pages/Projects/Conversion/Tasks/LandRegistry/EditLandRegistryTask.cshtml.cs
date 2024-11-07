using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks;
using Dfe.Complete.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.LandRegistry
{
    public class EditLandRegistryTaskModel : PageModel
    {
        private readonly IGetConversionProjectByTaskService _getConversionProjectByTaskService;
        private readonly IUpdateConversionProjectByTaskService _updateConversionProjectByTaskService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public Guid ProjectId { get; set; }

        public string SchoolName { get; set; }

        [BindProperty(Name = "cleared")]
        public bool? Cleared { get; set; }

        [BindProperty(Name = "received")]
        public bool? Received { get; set; }

        [BindProperty(Name = "saved")]
        public bool? Saved { get; set; }

        public EditLandRegistryTaskModel(
            IGetConversionProjectByTaskService getConversionProjectByTaskService,
            IUpdateConversionProjectByTaskService updateConversionProjectByTaskService)
        {
            _getConversionProjectByTaskService = getConversionProjectByTaskService;
            _updateConversionProjectByTaskService = updateConversionProjectByTaskService;
        }

        public async Task OnGet()
        {
            var project = await _getConversionProjectByTaskService.Execute(ProjectId, ConversionProjectTaskName.LandRegistry);

            Received = project.LandRegistry.Received;
            Cleared = project.LandRegistry.Cleared;
            Saved = project.LandRegistry.Saved;

            SchoolName = project.SchoolName;
        }

        public async Task<IActionResult> OnPost()
        {
            var request = new UpdateConversionProjectByTaskRequest()
            {
                LandRegistry = new()
                {
                    Cleared = Cleared,
                    Received = Received,
                    Saved = Saved,
                }
            };

            await _updateConversionProjectByTaskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.ConversionLandRegistryTask, ProjectId));
        }
    }
}
