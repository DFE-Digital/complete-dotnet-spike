using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Contacts;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Contacts;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers;


[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/client/contacts")]
[ApiController]

public class ContactsController : ControllerBase
{
    private readonly ILogger<ContactsController> _logger;
    private readonly IGetProjectContactsService _getProjectContactsService;
    private readonly IUpdateProjectContactsService _getUpdateProjectContactsService;

    public ContactsController(ILogger<ContactsController> logger, IGetProjectContactsService getProjectContactsService, IUpdateProjectContactsService updateProjectContactsService)
    {
        _logger = logger;
        _getProjectContactsService = getProjectContactsService;
        _getUpdateProjectContactsService = updateProjectContactsService;
    }
    
    [HttpGet]
    public async Task<ActionResult<ApiSingleResponseV2<GetContactsResponse>>> GetContacts(string projectId)
    {
        _logger.LogMethodEntered();
        
        var response = await _getProjectContactsService.Execute(projectId);
        
        return new ObjectResult(new ApiSingleResponseV2<GetContactsResponse>(response))
            { StatusCode = StatusCodes.Status200OK };
    }
    
    [HttpPatch]
    public async Task<ActionResult<ApiSingleResponseV2<GetContactsResponse>>> UpdateContacts(string projectId, UpdateContactsRequest request)
    {
        _logger.LogMethodEntered();

        await _getUpdateProjectContactsService.Execute(projectId, request);

        return new OkResult();
    }
}