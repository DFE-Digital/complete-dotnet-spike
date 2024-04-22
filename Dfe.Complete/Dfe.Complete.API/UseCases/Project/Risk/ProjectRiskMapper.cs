using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Risk
{
    public class ProjectRiskMapper
    {
        public static ProjectRiskRating? ToRiskRating(string value)
        {
            if (value == "Green")
            {
                return ProjectRiskRating.Green;
            }

            if (value == "Amber/Green")
            {
                return ProjectRiskRating.AmberGreen;
            }

            if (value == "Amber/Red")
            {
                return ProjectRiskRating.AmberRed;
            }

            if (value == "Red")
            {
                return ProjectRiskRating.Red;
            }

            return null;
        }
    }
}
