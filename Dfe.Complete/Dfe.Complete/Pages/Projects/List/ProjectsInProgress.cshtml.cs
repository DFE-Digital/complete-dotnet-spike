using Dfe.Complete.Pages.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dfe.Complete.Pages.Projects.List
{
    public class ProjectsInProgressModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public PaginationModel Pagination { get; set; } = new();

        // public List<ProjectListEntryResponse> Projects { get; set; }
        
        public async Task OnGet()
        {
            //TODO: Review pagination logic
            // var parameters = new GetProjectListServiceParameters()
            // {
            //     Status = ProjectStatusQueryParameter.InProgress,
            //     Page = PageNumber,
            //     Count = 20
            // };
            //
            // var response = await _getProjectListService.Execute(parameters);
            // Projects = response.Data.ToList();
            //
            // var paginationModel = PaginationMapping.ToModel(response.Paging);
            // paginationModel.Url = "?handler=movePage";
            // Pagination = paginationModel;
        }

        public async Task OnGetMovePage()
        {
            await OnGet();
        }
    }
}
