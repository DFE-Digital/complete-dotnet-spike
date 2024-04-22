using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Risk;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.RiskRating
{
    public class AddRiskAppraisalFormModel : AddRiskBaseModel
    {
        private readonly ICreateProjectRiskCache _createProjectRiskCache;
        private readonly ErrorService _errorService;

        [BindProperty(Name = "sharepoint-link")]
        [StringLength(ValidationConstants.LinkMaxLength, ErrorMessage = ValidationConstants.TextValidationMessage)]
        [Url(ErrorMessage = ValidationConstants.LinkValidationMessage)]
        [DisplayName("SharePoint link")]
        public string SharePointLink { get; set; }

        public AddRiskAppraisalFormModel(
            ICreateProjectRiskCache createProjectRiskCache, 
            ErrorService errorService)
        {
            _createProjectRiskCache = createProjectRiskCache;
            _errorService = errorService;
        }

        public void OnGet()
        {
            var existingCacheItem = _createProjectRiskCache.Get();

            SharePointLink = existingCacheItem.RiskAppraisalFormSharepointLink;
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

            existingCacheItem.RiskAppraisalFormSharepointLink = SharePointLink;

            _createProjectRiskCache.Update(existingCacheItem);

            return Redirect(GetNextPage());
        }
    }
}
