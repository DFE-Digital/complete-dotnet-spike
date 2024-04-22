namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

public class GiasTask
{
    public bool? CheckedTrustInformation { get; set; }
    public bool? ApplicationFormSent { get; set; }
    public bool? SavedToWorkspaces { get; set; }
    public bool? UrnSent { get; set; }
}