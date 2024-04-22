using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Contacts;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Contacts;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Contacts;

public class EditTrustChairContactModel : PageModel
{
    private readonly IGetContactsService _getContactsService;
    
    private readonly IAddContactsService _addContactsService;
    
    private readonly IGetProjectOverviewService _getProjectOverviewService;
    
    private readonly ILogger<EditTrustChairContactModel> _logger;
    
    private readonly ErrorService _errorService;
    
    [BindProperty(Name = "projectId")]
    public string ProjectId { get; set; }
    
    [BindProperty(Name = "trust-chair-name")]
    [ValidText(100)]
    [DisplayName("Trust chair name")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string TrustChairName { get; set; }

    [BindProperty(Name = "trust-chair-email")]
    [DisplayName("Trust chair email")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    
    public string TrustChairEmail { get; set; }
    
    [BindProperty]
    public GetContactsResponse PageContacts { get; set; }
    
    public string SchoolName { get; set; }
    
    public string GetNextPage()
    {
        return string.Format(RouteConstants.ViewContacts, ProjectId);
    }

    public EditTrustChairContactModel(IGetContactsService getContactsService,IGetProjectOverviewService projectOverviewService,IAddContactsService addContactsService,ErrorService errorService, ILogger<EditTrustChairContactModel> logger )
    {
        _getContactsService = getContactsService;
        _getProjectOverviewService = projectOverviewService;
        _errorService = errorService;
        _addContactsService = addContactsService;
        _logger = logger;
    }
    
    public async Task<IActionResult> OnGet()
    {
        _logger.LogMethodEntered();

        try
        {
            var projectId = RouteData.Values["projectId"] as string;
            PageContacts = await _getContactsService.Execute(projectId);
            ProjectId = projectId;
            var project = await _getProjectOverviewService.Execute(projectId);
            SchoolName = project.ProjectStatus.CurrentFreeSchoolName;
        }
        catch (Exception ex)
        {
            _logger.LogErrorMsg(ex);
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPost()
    {
        PageContacts = new GetContactsResponse()
        {
            Contacts = new ContactsTask()
            {
                ChairOfGovernorsEmail = TrustChairEmail,
                ChairOfGovernorsName = TrustChairName
            }
        };

        var projectId = RouteData.Values["projectId"] as string;
        var project = await _getProjectOverviewService.Execute(projectId);
        ProjectId = projectId;
        SchoolName = project.ProjectStatus.CurrentFreeSchoolName;
        
        
        if (TrustChairEmail?.Length > 100)
        {
            ModelState.AddModelError("trust-chair-email", "The trust chair email must be 100 characters or less");
        }
        
        if (!IsEmailValid(TrustChairEmail))
        {
            ModelState.AddModelError("trust-chair-email", "Enter an email address in the correct format");
        }
        
        if (TrustChairName != null && TrustChairName.Any(char.IsDigit))
        {
            ModelState.AddModelError("trust-chair-name", "Trust chair name cannot contain numbers");
        }
        
        if (!ModelState.IsValid)
        {
            _errorService.AddErrors(ModelState.Keys, ModelState);
            return Page();
        }

        var updateContactsRequest = new UpdateContactsRequest()
        {
            Contacts = new ContactsTask()
            {
                ChairOfGovernorsName = TrustChairName,
                ChairOfGovernorsEmail = TrustChairEmail
            }
            
        };

        await _addContactsService.Execute(ProjectId, updateContactsRequest);

        return Redirect(GetNextPage());
    }
    
    private static bool IsEmailValid(string email)
    {
        return string.IsNullOrEmpty(email) || new EmailAddressAttribute().IsValid(email);
    }
}