using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.Conversion.Tasks.LandRegistry
{
    public class ViewLandRegistryTaskModel : PageModel
    {
        private readonly IGetConversionProjectByTaskService _getConversionProjectByTaskService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetConversionProjectByTaskResponse Project { get; set; }

        public ViewLandRegistryTaskModel(IGetConversionProjectByTaskService getConversionProjectByTaskService)
        {
            _getConversionProjectByTaskService = getConversionProjectByTaskService;
        }

        public async Task OnGet()
        {
            Project = await _getConversionProjectByTaskService.Execute(Guid.Parse(ProjectId), ConversionProjectTaskName.LandRegistry);
        }
    }
}
