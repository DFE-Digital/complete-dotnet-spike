namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

public class OfstedInspectionTask
{
    public bool? ProcessDetailsProvided { get; set; }
        
    public bool? InspectionBlockDecided { get; set; }
        
    public bool? OfstedAndTrustLiaisonDetailsConfirmed { get; set; }
        
    public bool? BlockAndContentDetailsToOpenersSpreadSheet { get; set; }
        
    public bool? SharedOutcomeWithTrust { get; set; }
    
    public bool? InspectionConditionsMet { get; set; }
        
    public bool? ProposedToOpenOnGias { get; set; }
        
    public bool? SavedToWorkplaces { get; set; }
}