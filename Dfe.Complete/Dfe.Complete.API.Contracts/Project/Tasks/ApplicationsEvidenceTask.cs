namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

public class ApplicationsEvidenceTask
{
    public bool? ConfirmedPupilNumbers { get; set; }
        
    public string Comments { get; set; }
        
    public bool? BuildUpFormSavedToWorkplaces { get; set; }
        
    public bool? UnderwritingAgreementSavedToWorkplaces { get; set; }
}