using Dfe.ManageFreeSchoolProjects.API.Contracts.Users;
using FluentValidation;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Users
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(user => user.Email).NotEmpty();
        }
    }
}
