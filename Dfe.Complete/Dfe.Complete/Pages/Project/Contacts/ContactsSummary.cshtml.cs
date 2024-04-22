using System;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Contacts;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Contacts;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Contacts;

public class ContactsSummaryModel : PageModel
{
    private readonly IGetContactsService _getContactsService;
    
    private readonly IGetProjectOverviewService _getProjectOverviewService;
    
    private readonly ILogger<ContactsSummaryModel> _logger;
    
    [BindProperty(SupportsGet = true, Name = "projectId")]
    public string ProjectId { get; set; }
    
    public string SchoolName { get; set; }

    public GetContactsResponse Contacts { get; set; }

    public ContactsSummaryModel(IGetContactsService getContactsService, IGetProjectOverviewService projectOverviewService, ILogger<ContactsSummaryModel> logger )
    {
        _getContactsService = getContactsService;
        _getProjectOverviewService = projectOverviewService;
        _logger = logger;
    }

   public async Task<IActionResult> OnGet()
   {
       _logger.LogMethodEntered();

       try
       {
           var projectId = RouteData.Values["projectId"] as string;

           Contacts = await _getContactsService.Execute(projectId);
           var project = await _getProjectOverviewService.Execute(projectId);
           SchoolName = project.ProjectStatus.CurrentFreeSchoolName;
       }
       catch (Exception ex)
       {
           _logger.LogErrorMsg(ex);
       }

       return Page();
   }


}