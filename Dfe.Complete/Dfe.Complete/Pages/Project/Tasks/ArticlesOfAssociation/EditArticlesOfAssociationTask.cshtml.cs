using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using System;
using Dfe.ManageFreeSchoolProjects.Models;
using System.ComponentModel.DataAnnotations;
using Dfe.ManageFreeSchoolProjects.Validators;


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.ArticlesOfAssociation
{
    public class EditArticlesOfAssociationTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditArticlesOfAssociationTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name = "checked-submitted-articles-match")]
        public bool? CheckedSubmittedArticlesMatch { get; set; }
        
        [BindProperty(Name = "chair-have-submitted-confirmation")]
        public bool? ChairHaveSubmittedConfirmation { get; set; }
        
        [BindProperty(Name = "arrangements-match-governance-plans")]
        public bool? ArrangementsMatchGovernancePlans { get; set; }
        
        [BindProperty(Name = "forecast-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Forecast date")]

        public DateTime? ForecastDate { get; set; }

        [BindProperty(Name = "actual-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Actual date")]
        public DateTime? ActualDate { get; set; }

        [BindProperty(Name = "comments-on-decision")]
        [Display(Name = "Comments on decision to approve (if applicable)")]
        [ValidText(999)]
        public string CommentsOnDecision { get; set; }

        [BindProperty(Name = "sharepoint-link")]
        [Display(Name = "SharePoint link")]
        [StringLength(ValidationConstants.LinkMaxLength, ErrorMessage = ValidationConstants.TextValidationMessage)]
        [Url(ErrorMessage = ValidationConstants.LinkValidationMessage)]
        public string SharepointLink { get; set; }

        public string SchoolName { get; set; }

        public EditArticlesOfAssociationTaskModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditArticlesOfAssociationTaskModel> logger,
            ErrorService errorService)
        {
            _getProjectService = getProjectService;
            _updateProjectTaskService = updateProjectTaskService;
            _logger = logger;
            _errorService = errorService;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await LoadProject();
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.ArticlesOfAssociation);
            SchoolName = project.SchoolName;

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            try
            {
                var request = new UpdateProjectByTaskRequest()
                {
                    ArticlesOfAssociation = new ArticlesOfAssociationTask()
                    {
                        CheckedSubmittedArticlesMatch = CheckedSubmittedArticlesMatch,
                        ChairHaveSubmittedConfirmation = ChairHaveSubmittedConfirmation,
                        ArrangementsMatchGovernancePlans = ArrangementsMatchGovernancePlans,
                        ForecastDate = ForecastDate,
                        ActualDate = ActualDate,
                        CommentsOnDecision = CommentsOnDecision,
                        SharepointLink = SharepointLink
                    }
                };

                await _updateProjectTaskService.Execute(ProjectId, request);

                return Redirect(string.Format(RouteConstants.ViewArticlesOfAssociation, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.ArticlesOfAssociation);

            CheckedSubmittedArticlesMatch = project.ArticlesOfAssociation.CheckedSubmittedArticlesMatch;
            ChairHaveSubmittedConfirmation = project.ArticlesOfAssociation.ChairHaveSubmittedConfirmation;
            ArrangementsMatchGovernancePlans = project.ArticlesOfAssociation.ArrangementsMatchGovernancePlans;
            ForecastDate = project.ArticlesOfAssociation.ForecastDate;
            ActualDate = project.ArticlesOfAssociation.ActualDate;
            CommentsOnDecision = project.ArticlesOfAssociation.CommentsOnDecision;
            SharepointLink = project.ArticlesOfAssociation.SharepointLink;

            SchoolName = project.SchoolName;
        }
    }
}
