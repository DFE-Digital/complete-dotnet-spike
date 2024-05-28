using Dfe.Complete.API.Contracts.User;
using FluentValidation;

namespace Dfe.Complete.API.UseCases.User
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(user => user.Email).NotEmpty();
        }
    }
}
