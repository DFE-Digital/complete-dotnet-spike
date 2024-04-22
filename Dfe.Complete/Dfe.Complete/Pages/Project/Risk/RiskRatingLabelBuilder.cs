using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using System.Collections.Generic;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Risk
{
    public static class RiskRatingLabelBuilder
    {
        public static List<RiskRatingLabel> Build()
        {
            return new List<RiskRatingLabel>()
            {
                new RiskRatingLabel()
                {
                    RiskRating = ProjectRiskRating.Green,
                    Label = "<strong class=\"govuk-tag govuk-tag--green\">Green</strong>"
                },
                new RiskRatingLabel()
                {
                    RiskRating = ProjectRiskRating.AmberGreen,
                    Label = "<strong class=\"govuk-tag govuk-tag--amber\">Amber</strong>&nbsp;<strong class=\"govuk-tag govuk-tag--green\">Green</strong>"
                },
                new RiskRatingLabel()
                {
                    RiskRating = ProjectRiskRating.AmberRed,
                    Label = "<strong class=\"govuk-tag govuk-tag--amber\">Amber</strong>&nbsp;<strong class=\"govuk-tag govuk-tag--red\">Red</strong>"
                },
                new RiskRatingLabel()
                {
                    RiskRating = ProjectRiskRating.Red,
                    Label = "<strong class=\"govuk-tag govuk-tag--red\">Red</strong>"
                }
            };
        }
    }

    public class RiskRatingLabel
    {
        public ProjectRiskRating RiskRating { get; set; }
        public string Label { get; set; }
    }
}
