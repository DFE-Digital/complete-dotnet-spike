using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.Pages.Pagination;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dfe.ManageFreeSchoolProjects.Pages.Dashboard
{
    public class DashboardModel
    {
        public string Header { get; set; }
        public List<GetDashboardResponse> Projects { get; set; }
        public string ProjectSearchTerm { get; set; }
        public List<string> RegionSearchTerm { get; set; } = new();
        public List<string> LocalAuthoritySearchTerm { get; set; } = new();
        public List<string> ProjectManagedBySearchTerm { get; set; } = new();
        public bool UserCanCreateProject { get; set; } = false;
        public PaginationModel Pagination { get; set; } = new();
        public List<string> ProjectManagers { get; set; } = new();
        public bool IsMyProjectsPage { get; init; }
    }
}
