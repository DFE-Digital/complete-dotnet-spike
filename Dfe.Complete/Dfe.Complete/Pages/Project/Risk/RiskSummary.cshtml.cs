using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Risk
{
    public class RiskSummaryModel : PageModel
    {
        private readonly IGetProjectRiskService _getProjectRiskRatingService;

        private readonly ICreateProjectRiskCache _createProjectRiskCache;
        private readonly IGetProjectOverviewService _getProjectOverviewService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public GetProjectRiskResponse ProjectRisk { get; set; }

        public string SchoolName { get; set; }

        public DateTime? RiskDate { get; set; }

        public int Entry { get; set; }

        public RiskSummaryModel(
            IGetProjectRiskService getProjectRiskRatingService,
            ICreateProjectRiskCache createProjectRiskCache,
            IGetProjectOverviewService getProjectOverviewService)
        {
            _getProjectRiskRatingService = getProjectRiskRatingService;
            _createProjectRiskCache = createProjectRiskCache;
            _getProjectOverviewService = getProjectOverviewService;
        }

        public async Task<IActionResult> OnGetNewConfigureRiskRating()
        {
            _createProjectRiskCache.Delete();

            var projectOverview = await _getProjectOverviewService.Execute(ProjectId);
            var existingProjectRisk = await _getProjectRiskRatingService.Execute(ProjectId, 1);

            var createRiskCacheItem = CreateProjectRiskItem(projectOverview, existingProjectRisk);

            _createProjectRiskCache.Update(createRiskCacheItem);

            return Redirect(string.Format(RouteConstants.ProjectRiskReview, ProjectId));
        }

        private static CreateRiskCacheItem CreateProjectRiskItem(ProjectOverviewResponse projectOverview, GetProjectRiskResponse existingProjectRisk)
        {
            var result = new CreateRiskCacheItem()
            {
                SchoolName = projectOverview.ProjectStatus.CurrentFreeSchoolName
            };

            if (existingProjectRisk == null)
            {
                return result;
            }

            result.GovernanceAndSuitability = new()
            {
                Summary = existingProjectRisk.GovernanceAndSuitability.Summary,
                RiskRating = existingProjectRisk.GovernanceAndSuitability.RiskRating
            };

            result.Education = new()
            {
                Summary = existingProjectRisk.Education.Summary,
                RiskRating = existingProjectRisk.Education.RiskRating
            };

            result.Finance = new()
            {
                Summary = existingProjectRisk.Finance.Summary,
                RiskRating = existingProjectRisk.Finance.RiskRating
            };

            result.Overall = new()
            {
                Summary = existingProjectRisk.Overall.Summary,
                RiskRating = existingProjectRisk.Overall.RiskRating
            };

            result.RiskAppraisalFormSharepointLink = existingProjectRisk.RiskAppraisalFormSharepointLink;

            return result;
        }

        public async Task<IActionResult> OnGet(int entry = 1)
        {
            Entry = entry;
            ProjectRisk = new GetProjectRiskResponse();

            var projectRiskResponse = await _getProjectRiskRatingService.Execute(ProjectId, entry);
            var projectOverview = await _getProjectOverviewService.Execute(ProjectId);

            SchoolName = projectOverview.ProjectStatus.CurrentFreeSchoolName;
            ProjectRisk = projectRiskResponse;
            RiskDate = projectRiskResponse.Date;

            return Page();
        }
    }
}
