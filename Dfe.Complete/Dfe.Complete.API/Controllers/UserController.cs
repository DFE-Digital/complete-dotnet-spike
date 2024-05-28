using Dfe.Complete.API.Contracts.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Dfe.Complete.Logging;
using Dfe.Complete.API.UseCases.User;

namespace Dfe.Complete.API.Controllers
{
    [Route("api/v{version:apiVersion}/client/users")]
    [ApiController]
    [Tags("User (Client only)")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserService _createUser;
        private readonly IValidator<CreateUserRequest> _createUserRequestValidator;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IValidator<CreateUserRequest> createUserRequestValidator,
            ICreateUserService createUser,
            ILogger<UserController> logger)
        {
            _createUser = createUser;
            _createUserRequestValidator = createUserRequestValidator;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserRequest request)
        {
            _logger.LogMethodEntered();

            var validationResult = _createUserRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            var result = _createUser.Execute(request);

            if (result.UserCreateState == UserCreateState.Exists)
            {
                _logger.LogInformation("User exists, no record has been created");

                return new OkResult();
            }

            _logger.LogInformation("User has been created");

            return new ObjectResult(null)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
