using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Dfe.ManageFreeSchoolProjects.Extensions;
using Dfe.ManageFreeSchoolProjects.Services.Dashboard;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create
{
    public class LocalAuthorityModel : CreateProjectBaseModel
    {
        [BindProperty(Name = "local-authority")]
        [Display(Name = "Local Authority")]
        [Required(ErrorMessage = "Select the local authority of the free school")]
        public string LocalAuthority { get; set; }

        [BindProperty(Name = "local-authorities")]
        public List<string> LocalAuthorities { get; set; }
        
        private readonly ErrorService _errorService;
        private readonly IGetLocalAuthoritiesService _getLocalAuthoritiesService;

        public LocalAuthorityModel(ErrorService errorService, ICreateProjectCache createProjectCache,
            IGetLocalAuthoritiesService getLocalAuthoritiesService)
            :base(createProjectCache)
        {
            _errorService = errorService;
            _getLocalAuthoritiesService = getLocalAuthoritiesService;
        }

        public async Task<ActionResult> OnGet()
        {
            if (!IsUserAuthorised())
            {
                return new UnauthorizedResult();
            }

            var project = _createProjectCache.Get();
            
            var localAuthorities = await GetLocalAuthoritiesByRegion();
            LocalAuthorities = localAuthorities.Values.ToList();
            LocalAuthorities.Sort();
            project.LocalAuthorities = localAuthorities;

            if (!string.IsNullOrEmpty(project.LocalAuthority))
                LocalAuthority = project.LocalAuthority;
            
            _createProjectCache.Update(project);

            BackLink = GetPreviousPage(CreateProjectPageName.LocalAuthority);
            
            return Page();
        }

        public ActionResult OnPost()
        {
            var project = _createProjectCache.Get();
            BackLink = GetPreviousPage(CreateProjectPageName.LocalAuthority);

            if (!ModelState.IsValid)
            {
                LocalAuthorities = _createProjectCache.Get().LocalAuthorities.Values.ToList();
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }
            
            project.LocalAuthority = LocalAuthority;
            project.LocalAuthorityCode = project.LocalAuthorities.FirstOrDefault(x => x.Value == LocalAuthority).Key;

            if (project.ReachedCheckYourAnswers)
            {
                project.Region = project.PreviousRegion;
            }

            _createProjectCache.Update(project);

            return Redirect(GetNextPage(CreateProjectPageName.LocalAuthority));
        }

        private async Task<Dictionary<string, string>> GetLocalAuthoritiesByRegion()
        {
            var project = _createProjectCache.Get();
            var region = project.Region.ToDescription();

            if (project.ReachedCheckYourAnswers)
            {
                region = project.PreviousRegion.ToDescription();
            }
            
            var response = await _getLocalAuthoritiesService.Execute(new List<string> { region });

            var authorities = new Dictionary<string, string>();

            response.Regions.ForEach(region =>
            {
                region.LocalAuthorities.ForEach(authority =>
                {
                    authorities.Add(authority.LACode, authority.Name);
                });
            });

            return authorities;
        }
    }
}