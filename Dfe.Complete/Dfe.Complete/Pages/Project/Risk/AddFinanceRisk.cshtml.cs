using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.Extensions;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Risk
{
    public class AddFinanceRiskModel : AddRiskBaseModel
    {
        private readonly ErrorService _errorService;
        private readonly ICreateProjectRiskCache _createProjectRiskCache;

        public AddFinanceRiskModel(ICreateProjectRiskCache createProjectRiskCache, ErrorService errorService)
        {
            _createProjectRiskCache = createProjectRiskCache;
            _errorService = errorService;
        }

        public void OnGet()
        {
            var existingCacheItem = _createProjectRiskCache.Get();

            Summary = existingCacheItem.Finance.Summary;
            RiskRating = existingCacheItem.Finance.RiskRating.ToIntString();
            SchoolName = existingCacheItem.SchoolName;
        }

        public IActionResult OnPost()
        {
            var existingCacheItem = _createProjectRiskCache.Get();

            if (!ModelState.IsValid)
            {
                SchoolName = existingCacheItem.SchoolName;
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            existingCacheItem.Finance = new()
            {
                Summary = Summary,
                RiskRating = RiskRating.ToEnum<ProjectRiskRating>()
            };

            _createProjectRiskCache.Update(existingCacheItem);

            return Redirect(GetNextPage());
        }
    }
}
