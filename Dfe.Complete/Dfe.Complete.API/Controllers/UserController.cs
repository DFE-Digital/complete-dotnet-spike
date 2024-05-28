using Dfe.Complete.API.Contracts.User;
using Dfe.Complete.API.UseCases.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.Complete.API.Controllers
{
    [Route("api/v{version:apiVersion}/client/users")]
    [ApiController]
    [Tags("User (Client only)")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserService _createUser;
        private readonly IValidator<CreateUserRequest> _createUserRequestValidator;

        public UserController(
            IValidator<CreateUserRequest> createUserRequestValidator,
            ICreateUserService createUser)
        {
            _createUser = createUser;
            _createUserRequestValidator = createUserRequestValidator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserRequest request)
        {
            var validationResult = _createUserRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            await _createUser.Execute(request);

            return new ObjectResult(new object())
            {
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
