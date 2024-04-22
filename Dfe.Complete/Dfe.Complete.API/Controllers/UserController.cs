using Dfe.ManageFreeSchoolProjects.API.Contracts.Users;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Users;
using Dfe.ManageFreeSchoolProjects.Logging;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client/users")]
    [ApiController]
    public class UserController
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
