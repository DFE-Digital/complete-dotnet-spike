using Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects;
using FluentValidation;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project
{
    public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectRequestValidator()
        {
            RuleForEach(x => x.Projects).SetValidator(new CreateProjectDetailsValidator());
        }
    }

    public class CreateProjectDetailsValidator : AbstractValidator<ProjectDetails>
    {
        public CreateProjectDetailsValidator()
        {
            RuleFor(x => x.TRN).NotEmpty();
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
