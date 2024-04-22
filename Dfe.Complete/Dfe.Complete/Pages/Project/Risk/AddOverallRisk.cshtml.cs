using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Dfe.ManageFreeSchoolProjects.Extensions;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Risk
{
    public class AddOverallRiskModel : AddRiskBaseModel
    {
        private readonly ErrorService _errorService;
        private readonly ICreateProjectRiskCache _createProjectRiskCache;

        public AddOverallRiskModel(ICreateProjectRiskCache createProjectRiskCache, ErrorService errorService)
        {
            _createProjectRiskCache = createProjectRiskCache;
            _errorService = errorService;
        }

        public void OnGet()
        {
            var existingCacheItem = _createProjectRiskCache.Get();

            Summary = existingCacheItem.Overall.Summary;
            RiskRating = existingCacheItem.Overall.RiskRating.ToIntString();
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

            existingCacheItem.Overall = new()
            {
                Summary = Summary,
                RiskRating = RiskRating.ToEnum<ProjectRiskRating>()
            };

            _createProjectRiskCache.Update(existingCacheItem);

            return Redirect(GetNextPage());
        }
    }
}
