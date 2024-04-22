using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Risk
{
    public class AddRiskReviewModel : PageModel
    {
        private readonly ICreateProjectRiskCache _createProjectRiskCache;
        private readonly ICreateProjectRiskService _createProjectRiskService;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string SchoolName { get; set; }

        [BindProperty(Name = "risk-reviewed", BinderType = typeof(CheckboxInputModelBinder))]
        [Required(ErrorMessage = "Confirm that you have reviewed the ratings and summaries")]
        public bool RiskReviewed { get; set; }

        public CreateRiskCacheItem ProjectRisk { get; set; }

        public AddRiskReviewModel(ICreateProjectRiskCache createProjectRiskCache, ICreateProjectRiskService createProjectRiskService, ErrorService errorService)
        {
            _createProjectRiskCache = createProjectRiskCache;
            _createProjectRiskService = createProjectRiskService;
            _errorService = errorService;
        }

        public void OnGet()
        {
            var projectRisk = _createProjectRiskCache.Get();
            SchoolName = projectRisk.SchoolName;

            _createProjectRiskCache.Update(projectRisk);

            ProjectRisk = projectRisk;
        }

        public async Task<IActionResult> OnPost()
        {
            var riskToCreate = _createProjectRiskCache.Get();

            if (riskToCreate.Overall.RiskRating == null)
            {
                ModelState.AddModelError("overall-risk-missing", "Enter an overall risk");
            }

            if (!ModelState.IsValid)
            {
                SchoolName = riskToCreate.SchoolName;
                ProjectRisk = riskToCreate;
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            var request = new CreateProjectRiskRequest()
            {
                GovernanceAndSuitability = new ProjectRiskEntryRequest()
                {
                    Summary = riskToCreate.GovernanceAndSuitability.Summary,
                    RiskRating = riskToCreate.GovernanceAndSuitability.RiskRating
                },
                Education = new ProjectRiskEntryRequest()
                {
                    Summary = riskToCreate.Education.Summary,
                    RiskRating = riskToCreate.Education.RiskRating
                },
                Finance = new ProjectRiskEntryRequest()
                {
                    Summary = riskToCreate.Finance.Summary,
                    RiskRating = riskToCreate.Finance.RiskRating
                },
                Overall = new ProjectRiskEntryRequest()
                {
                    Summary = riskToCreate.Overall.Summary,
                    RiskRating = riskToCreate.Overall.RiskRating
                },
                RiskAppraisalFormSharepointLink = riskToCreate.RiskAppraisalFormSharepointLink
            };

            await _createProjectRiskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.ProjectRiskConfirmation, ProjectId, HttpUtility.UrlEncode(SchoolName)));
        }
    }
}
