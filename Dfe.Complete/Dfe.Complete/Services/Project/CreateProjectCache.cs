using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using SchoolType = Dfe.ManageFreeSchoolProjects.API.Contracts.Project.SchoolType;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface ICreateProjectCache: ICookieCacheService<CreateProjectCacheItem>
    {
    }

    public class CreateProjectCache : CookieCacheService<CreateProjectCacheItem>, ICreateProjectCache
    {
        public CreateProjectCache(IHttpContextAccessor httpContextAccessor, IDataProtectionProvider DataProtectionProvider)
            : base(httpContextAccessor, DataProtectionProvider, "CP1")
        {
        }
    }

    public enum CreateProjectNavigation
    {
        Default,
        FromFaithType,
    }

    public record CreateProjectCacheItem
    {
        public CreateProjectNavigation Navigation { get; set; }
        public bool ReachedCheckYourAnswers { get; set; }
        public string ProjectId { get; set; }
        public string SchoolName { get; set; }
        public ProjectRegion Region { get; set; }
        public ProjectRegion PreviousRegion { get; set; }
        public IDictionary<string, string> LocalAuthorities { get; set; }
        public string LocalAuthority { get; set; }
        public string LocalAuthorityCode { get; set; }
        public string ConfirmTrust { get; set; }
        public SchoolType SchoolType { get; set; }
        public SchoolType PreviousSchoolType { get; set; }
        public SchoolPhase SchoolPhase { get; set; }
        public string TrustName { get; set; }
        public string TRN { get; set; }
        public ClassType.SixthForm SixthForm { get; set; }
        public ClassType.Nursery Nursery { get; set; }
        public ClassType.AlternativeProvision AlternativeProvision { get; set; }
        public ClassType.SpecialEducationNeeds SpecialEducationNeeds { get; set; }
        public string AgeRange { get; set; }
        public int? NurseryCapacity { get; set; }
        public int? YRY6Capacity { get; set; }
        public int? Y7Y11Capacity { get; set; }
        public int? Y12Y14Capacity { get; set; }
        public string FormsOfEntry { get; set; }
        public FaithStatus FaithStatus { get; set; }
        public FaithStatus PreviousFaithStatus { get; set; }
        public FaithType FaithType { get; set; }
        public string OtherFaithType { get; set; }
        public DateTime? ProvisionalOpeningDate { get; set; }
        public string ProjectLeadName { get; set; }
        public string ProjectLeadEmail { get; set; }
    }
}
