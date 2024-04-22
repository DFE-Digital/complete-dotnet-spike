using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual
{
    public class ConfirmationModel : PageModel
    {
        private readonly ICreateProjectCache _createProjectCache;

        public string ProjectID { get; set; }

        public string EmailToNotify { get; set; }

        public ConfirmationModel(ICreateProjectCache createProjectCache)
        {
            _createProjectCache = createProjectCache;
        }

        public void OnGet()
        {
            ProjectID = _createProjectCache.Get().ProjectId;
            EmailToNotify = _createProjectCache.Get().ProjectLeadEmail;
        }
    }
}
