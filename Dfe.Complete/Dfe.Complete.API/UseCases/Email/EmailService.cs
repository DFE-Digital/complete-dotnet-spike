using System.ComponentModel.DataAnnotations;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Notify.Client;
using Notify.Models.Responses;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Email;


public interface IEmailService
{
    bool IsEmailValid(string email);
    Task<EmailNotificationResponse> SendEmail(EmailNotifyRequest request);
}

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public Task<EmailNotificationResponse> SendEmail(EmailNotifyRequest request)
    {
        var apiKey = _configuration.GetValue<string>("GovNotify:ApiKey");

        if (string.IsNullOrEmpty(apiKey))
        {
            _logger.LogWarning("Missing API key for GovNotify.");
            return Task.FromResult(new EmailNotificationResponse());   
        }
        
        var templateId = _configuration.GetValue<string>("GovNotify:TemplateId");
        
        var client = new NotificationClient(apiKey);

        var personalisation = new Dictionary<string, dynamic>
        {
            { "project_url", request.ProjectUrl }
        };

        return client.SendEmailAsync(request.Email, templateId, personalisation);
    }

    public bool IsEmailValid(string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }
}