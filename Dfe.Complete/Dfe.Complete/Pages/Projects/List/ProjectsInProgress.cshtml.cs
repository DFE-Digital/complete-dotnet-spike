using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.Pages.Pagination;
using Dfe.Complete.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.List
{
    public class ProjectsInProgressModel : PageModel
    {
        private readonly IGetProjectListService _getProjectListService;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public PaginationModel Pagination { get; set; } = new();

        public List<ProjectListEntryResponse> Projects { get; set; }

        public ProjectsInProgressModel(IGetProjectListService getProjectListService)
        {
            _getProjectListService = getProjectListService;
        }

        public async Task OnGet()
        {
            var parameters = new GetProjectListServiceParameters()
            {
                Status = ProjectStatusQueryParameter.InProgress,
                Page = PageNumber,
                Count = 20
            };

            var response = await _getProjectListService.Execute(parameters);
            Projects = response.Data.ToList();

            var paginationModel = PaginationMapping.ToModel(response.Paging);
            paginationModel.Url = "?handler=movePage";
            Pagination = paginationModel;
        }

        public async Task OnGetMovePage()
        {
            await OnGet();
        }
    }
}
