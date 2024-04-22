using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;

namespace Dfe.ManageFreeSchoolProjects.Services.Project;


public interface INotifyUserService
{
    Task Execute(string email, string projectUrl);
}

public class NotifyUserService : INotifyUserService
{
    private readonly MfspApiClient _apiClient;

    public NotifyUserService(MfspApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task Execute(string email, string projectUrl)
    {
        var notifyEmailRequest = new EmailNotifyRequest
        {
            Email = email,
            ProjectUrl = projectUrl
        };

        await _apiClient.Post<EmailNotifyRequest, string>("/api/v1.0/email", notifyEmailRequest);
    }
}