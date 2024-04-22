using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public class FinancePlanTask
    {
        public YesNo? FinancePlanAgreed { get; set; }
        public DateTime? DateAgreed { get; set; }
        public YesNo? PlanSavedInWorksplacesFolder { get; set; }
        public YesNoNotApplicable? LocalAuthorityAgreedPupilNumbers { get; set; }
        public string Comments { get; set; }
        public YesNo? TrustWillOptIntoRpa { get; set; }
        public DateTime? RpaStartDate { get; set; }
        public string RpaCoverType { get; set; }
    }
}
