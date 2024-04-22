using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface ICreateProjectRiskCache : ICookieCacheService<CreateRiskCacheItem>
    {
    }

    public class CreateProjectRiskCache : CookieCacheService<CreateRiskCacheItem>, ICreateProjectRiskCache
    {
        public CreateProjectRiskCache(IHttpContextAccessor httpContextAccessor, IDataProtectionProvider DataProtectionProvider) 
            : base(httpContextAccessor, DataProtectionProvider,  "R1")
        {
        }
    }

    public class CreateRiskCacheItem
    {
        public RiskEntryModel GovernanceAndSuitability { get; set; } = new();

        public RiskEntryModel Education { get; set; } = new();

        public RiskEntryModel Finance { get; set; } = new();

        public RiskEntryModel Overall { get; set; } = new();

        public string RiskAppraisalFormSharepointLink { get; set; }

        public string SchoolName { get; set; }
    }

    public class RiskEntryModel
    {
        public ProjectRiskRating? RiskRating { get; set; }
        public string Summary { get; set; }
    }
}
