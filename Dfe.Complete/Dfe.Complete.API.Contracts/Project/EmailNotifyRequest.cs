namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project;

public record EmailNotifyRequest
{
    public string Email { get; init; }
    public string ProjectUrl { get; init; }
}