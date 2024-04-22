using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites
{
    public class GetProjectSitesResponse
    {
        public ProjectSite PermanentSite { get; set; } = new();
        public ProjectSite TemporarySite { get; set; } = new();
        public string SchoolName { get; set; }
    }
}
