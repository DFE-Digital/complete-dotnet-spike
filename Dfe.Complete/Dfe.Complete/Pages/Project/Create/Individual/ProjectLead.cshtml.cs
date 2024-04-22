using System.ComponentModel.DataAnnotations;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual;

public class ProjectLead : CreateProjectBaseModel
{
    private readonly ErrorService _errorService;

    [Required(ErrorMessage = "Please enter the name.")]
    [BindProperty(Name = "name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter an email.")]
    [BindProperty(Name = "email")]
    public string Email { get; set; }
    
    public ProjectLead(ErrorService errorService, ICreateProjectCache createProjectCache)
        :base(createProjectCache)
    {
        _errorService = errorService;
    }

    public IActionResult OnGet()
    {
        if (!IsUserAuthorised())
        {
            return new UnauthorizedResult();
        }


        var projectCache = _createProjectCache.Get();

        BackLink = GetPreviousPage(CreateProjectPageName.ProjectLead);

        Name = projectCache.ProjectLeadName;
        Email = projectCache.ProjectLeadEmail;

        return Page();
    }


    public IActionResult OnPost()
    {
        var projectCache = _createProjectCache.Get();
        BackLink = GetPreviousPage(CreateProjectPageName.ProjectLead);

        if (!ModelState.IsValid)
        {
            _errorService.AddErrors(ModelState.Keys, ModelState);
            return Page();
        }

        if (!IsNameValid(Name))
        {
            ModelState.AddModelError("name", "Enter the full name, for example John Smith");
            _errorService.AddErrors(ModelState.Keys, ModelState);
            return Page();
        }

        if (!IsEmailValid(Email))
        {
            ModelState.AddModelError("email", "Enter an email address in the correct format. For example, firstname.surname@education.gov.uk");
            _errorService.AddErrors(ModelState.Keys, ModelState);
            return Page();
        }

        projectCache.ProjectLeadName = Name;
        projectCache.ProjectLeadEmail = Email;
        _createProjectCache.Update(projectCache);
        
        return Redirect(RouteConstants.CreateProjectCheckYourAnswers);
    }

    private static bool IsEmailValid(string email)
    {
        return email != null && email.Contains("@education.gov.uk") && new EmailAddressAttribute().IsValid(email);
    }

    private static bool IsNameValid(string name)
    {
        return name != null && name.Contains(' ');
    }
}