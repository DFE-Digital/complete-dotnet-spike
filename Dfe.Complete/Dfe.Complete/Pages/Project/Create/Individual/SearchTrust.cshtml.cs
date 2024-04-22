using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Trust;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Services;
using System.Net.Http;
using System.Text.RegularExpressions;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create
{
    public class SearchTrustTaskModel : CreateProjectBaseModel
    {
        private readonly ILogger<SearchTrustTaskModel> _logger;
        private readonly IGetTrustByRefService _getTrustByRefService;
        private readonly ErrorService _errorService;
        
        [BindProperty(Name = "trn")]
        [Display(Name = "TRN (trust reference number)")]
        [StringLength(7, ErrorMessage = ValidationConstants.TextValidationMessage)]
        [Required(ErrorMessage = "Enter the TRN")]
        public string TRN { get; set; }

        public GetTrustByRefResponse Trust { get; set; }

        
        public SearchTrustTaskModel(
            IGetTrustByRefService getTrustByRefService,
            ICreateProjectCache createProjectCache,
            ILogger<SearchTrustTaskModel> logger,
            ErrorService errorService)
            :base(createProjectCache)
        {
            _getTrustByRefService = getTrustByRefService;
            _logger = logger;
            _errorService = errorService;
        }

        public IActionResult OnGet()
        {
            _logger.LogMethodEntered();
            
            if (!IsUserAuthorised())
            {
                return new UnauthorizedResult();
            }

            try
            {
                var project = _createProjectCache.Get();

                BackLink = GetPreviousPage(CreateProjectPageName.SearchTrust);
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

            var project = _createProjectCache.Get();

            BackLink = GetPreviousPage(CreateProjectPageName.SearchTrust);

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

                throw;
            }

            return Redirect(GetNextPage(CreateProjectPageName.SearchTrust, TRN));
        }
    }
}