using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using FluentValidation;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Risk
{
    public class CreateProjectRiskRequestValidator : AbstractValidator<CreateProjectRiskRequest>
    {
        public CreateProjectRiskRequestValidator()
        {
            RuleFor(x => x.GovernanceAndSuitability.RiskRating).IsInEnum();
            RuleFor(x => x.GovernanceAndSuitability.Summary).MaximumLength(1000);

            RuleFor(x => x.Education.RiskRating).IsInEnum();
            RuleFor(x => x.Education.Summary).MaximumLength(1000);

            RuleFor(x => x.Finance.RiskRating).IsInEnum();
            RuleFor(x => x.Finance.Summary).MaximumLength(1000);

            RuleFor(x => x.Overall.RiskRating).IsInEnum().NotNull();
            RuleFor(x => x.Overall.Summary).MaximumLength(1000);

            RuleFor(x => x.RiskAppraisalFormSharepointLink).MaximumLength(1000);
        }
    }
}
