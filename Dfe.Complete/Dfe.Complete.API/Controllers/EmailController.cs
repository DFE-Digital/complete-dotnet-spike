using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Email;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/email")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly ILogger<EmailController> _logger;

    public EmailController(IEmailService emailService, ILogger<EmailController> logger)
    {
        _emailService = emailService;
        _logger = logger;
    }

     [HttpPost]
     public async Task<ActionResult> SendEmail([FromBody] EmailNotifyRequest request)
     {
         _logger.LogMethodEntered();

         if (request.Email.IsNullOrEmpty()) 
             return BadRequest("Email is required.");

         if (!_emailService.IsEmailValid(request.Email)) 
             return BadRequest("Email is not valid.");
         
         if (string.IsNullOrEmpty(request.ProjectUrl))
             return BadRequest("Project Url is required.");
         
         try
         {
             await _emailService.SendEmail(request);
             return Ok();
         }
         catch (Exception ex)
         {
             _logger.LogErrorMsg(ex);
             return new ObjectResult("Failed to send email. Check email exists/valid or Gov Notify service.")
                 { StatusCode = StatusCodes.Status500InternalServerError };
         }
     }
}