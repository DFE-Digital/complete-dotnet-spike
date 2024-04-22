using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Trust;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using Dfe.ManageFreeSchoolProjects.Services;
using System.Net.Http;
using System.Net;
using Dfe.ManageFreeSchoolProjects.Models;
using System.Text.RegularExpressions;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.Trust
{
    public class SearchTrustTaskModel : PageModel
    {
        private readonly ILogger<SearchTrustTaskModel> _logger;
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IGetTrustByRefService _getTrustByRefService;
        private readonly ISearchTrustByRefService _searchTrustByRefService;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        public string CurrentFreeSchoolName { get; set; }

        [BindProperty(Name = "trn")]
        [Display(Name = "TRN (trust reference number)")]
        [StringLength(7, ErrorMessage = ValidationConstants.TextValidationMessage)]
        [Required(ErrorMessage = "Enter the TRN.")]
        public string TRN { get; set; }

        //public string Nonce;

        public GetTrustByRefResponse Trust { get; set; }

        public SearchTrustByRefResponse TrustSearchResults { get; set; }

        public SearchTrustTaskModel(
            IGetProjectByTaskService getProjectService,
            IGetTrustByRefService getTrustByRefService,
            ISearchTrustByRefService searchTrustByRefService,
            ILogger<SearchTrustTaskModel> logger,
            ErrorService errorService)
        {
            _logger = logger;
            _getProjectService = getProjectService;
            _getTrustByRefService = getTrustByRefService;
            _searchTrustByRefService = searchTrustByRefService;
            _errorService = errorService;
        }

        public async Task<IActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            try
            {
                var project = await _getProjectService.Execute(ProjectId, TaskName.Trust);
                CurrentFreeSchoolName = project.SchoolName;

            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            _logger.LogMethodEntered();

            var project = await _getProjectService.Execute(ProjectId, TaskName.Trust);
            CurrentFreeSchoolName = project.SchoolName;

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);

                return Page();
            }

            if (!Regex.Match(TRN, "TR\\d\\d\\d\\d\\d", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5)).Success)
            {
                ModelState.AddModelError("trn", "The TRN must be in the format TRXXXXX");
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            try
            {
                //Attempt to get trust, will throw an exception when 404 is returned
                Trust = await _getTrustByRefService.Execute(TRN);
                
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ModelState.AddModelError("trn", "Trust ID not found");
                    _errorService.AddErrors(ModelState.Keys, ModelState);
                    return Page();
                }

                else
                {
                    throw;
                }
            }

            return Redirect(string.Format(RouteConstants.EditTrustTask, ProjectId, TRN));

        }

        public async Task<ActionResult> OnGetTrustsSearchResult(string searchTerm, string nonce)
        {
            try
            {
                _logger.LogMethodEntered();


                // Double check search term
                if (string.IsNullOrEmpty(searchTerm))
                {
                    _logger.LogInformationMsg($"Search rejected, searchQuery too short");
                    return new JsonResult(new TrustSearchResponse() { Nonce = nonce });
                }

                _logger.LogInformationMsg($"Entered trust search: searchQuery -'{searchTerm}', nonce-{nonce}");
                var trustSearchResponse = await _searchTrustByRefService.Execute(searchTerm);

                return new JsonResult(new TrustSearchResponse() { Nonce = nonce, Data = trustSearchResponse.Data });
            }
            catch (Exception ex)
            {
                _logger.LogError("Trust::IndexPageModel::OnGetTrustsSearchResult::Exception - {Message}", ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}