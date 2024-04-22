using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Pages.Pagination;
using Dfe.ManageFreeSchoolProjects.Services.Dashboard;
using Dfe.ManageFreeSchoolProjects.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Dashboard
{
    public class DashboardBasePageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        [BindProperty(Name = "search-by-project", SupportsGet = true)]
        public string ProjectSearchTerm { get; set; }

        [BindProperty(Name = "search-by-region", SupportsGet = true)]
        public List<string> RegionSearchTerm { get; set; } = new();

        [BindProperty(Name = "search-by-local-authority", SupportsGet = true)]
        public List<string> LocalAuthoritySearchTerm { get; set; } = new();

        [BindProperty(Name = "search-by-pmb", SupportsGet = true)]
        public List<string> ProjectManagedBySearchTerm { get; set; }

        [BindProperty]
        public bool UserCanCreateProject { get; set; }

        [BindProperty]
        public List<string> ProjectManagers { get; set; }

        public DashboardModel Dashboard { get; set; } = new();

        protected readonly ICreateUserService _createUserService;
        protected readonly IGetDashboardService _getDashboardService;
        private readonly IGetLocalAuthoritiesService _getLocalAuthoritiesService;
        private readonly IGetProjectManagersService _getProjectManagersService;

        public DashboardBasePageModel(
            ICreateUserService createUserService,
            IGetDashboardService getDashboardAllService,
            IGetLocalAuthoritiesService getLocalAuthoritiesService,
            IGetProjectManagersService getProjectManagersService)
        {
            _createUserService = createUserService;
            _getDashboardService = getDashboardAllService;
            _getLocalAuthoritiesService = getLocalAuthoritiesService;
            _getProjectManagersService = getProjectManagersService;
        }

        public async Task<JsonResult> OnGetLocalAuthoritiesByRegion(string regions)
        {
            if (string.IsNullOrEmpty(regions))
            {
                return new JsonResult(new List<string>());
            }

            var regionsToSearch = regions.Split(",").ToList();

            var localAuthoritiesResponse = await _getLocalAuthoritiesService.Execute(regionsToSearch);

            var result = new JsonResult(localAuthoritiesResponse.Regions);

            return result;
        }

        protected async Task AddUser()
        {
            var username = User.Identity.Name.ToString();
            await _createUserService.Execute(username);
        }

        protected async Task LoadDashboard(LoadDashboardParameters loadDashboardParameters)
        {
            var getDashboardServiceParameters = loadDashboardParameters.GetDashboardServiceParameters;

            getDashboardServiceParameters.Project = ProjectSearchTerm;
			getDashboardServiceParameters.Regions = RegionSearchTerm;
            getDashboardServiceParameters.LocalAuthorities = LocalAuthoritySearchTerm;
            getDashboardServiceParameters.ProjectManagedBy = ProjectManagedBySearchTerm;
            getDashboardServiceParameters.Page = PageNumber;

            var response = await _getDashboardService.Execute(getDashboardServiceParameters);

            var projectManagersResponse = _getProjectManagersService.Execute();

            var paginationModel = PaginationMapping.ToModel(response.Paging);
            var query = BuildPaginationQuery();
            paginationModel.Url = $"{loadDashboardParameters.Url}{query}";

            Dashboard = new DashboardModel
            {
                Projects = response.Data.ToList(),
                ProjectSearchTerm = ProjectSearchTerm,
                RegionSearchTerm = RegionSearchTerm,
                LocalAuthoritySearchTerm = LocalAuthoritySearchTerm,
                ProjectManagedBySearchTerm = ProjectManagedBySearchTerm,
                Pagination = paginationModel,
                UserCanCreateProject = User.IsInRole(RolesConstants.ProjectRecordCreator),
                ProjectManagers = projectManagersResponse.Result.ProjectManagers,
                IsMyProjectsPage = loadDashboardParameters.Url.Contains("/my")
            };  
        }

        private string BuildPaginationQuery()
        {
            QueryString query = new QueryString("?handler=movePage");

            if (!string.IsNullOrEmpty(ProjectSearchTerm))
            {
                query = query.Add("search-by-project", ProjectSearchTerm);
            }

            if (RegionSearchTerm.Any())
            {
                RegionSearchTerm.ForEach((r => query = query.Add("search-by-region", r)));
            }

            if (LocalAuthoritySearchTerm.Any())
            {
                LocalAuthoritySearchTerm.ForEach((l => query = query.Add("search-by-local-authority", l)));
            }

            if (ProjectManagedBySearchTerm.Count > 0)
            {
               ProjectManagedBySearchTerm.ForEach((m => query = query.Add("search-by-pmb", m)));
            }

            return query.ToString();
        }

        protected class LoadDashboardParameters
        {
            public GetDashboardServiceParameters GetDashboardServiceParameters { get; set; }
            public string Url { get; set; }
        }
    }
}
