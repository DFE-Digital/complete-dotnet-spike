using Dfe.ManageFreeSchoolProjects.API.Contracts.Users;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Users
{
    public record CreateUserResult
    {
        public UserCreateState UserCreateState { get; set; }
    }

    public enum UserCreateState
    {
        New = 1,
        Exists = 2
    }

    public interface ICreateUserService
    {
        public CreateUserResult Execute(CreateUserRequest request);
    }

    public class CreateUserService : ICreateUserService
    {
        private readonly MfspContext _context;

        public CreateUserService(MfspContext context, ILogger<CreateUserService> logger)
        {
            _context = context;
        }

        public CreateUserResult Execute(CreateUserRequest request)
        {
            var dbUser = new User()
            {
                Email = request.Email.ToLower().Trim()
            };

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == dbUser.Email);

            if (existingUser != null) 
            {
                return new CreateUserResult() { UserCreateState = UserCreateState.Exists };
            }

            _context.Users.Add(dbUser);

            _context.SaveChanges();

            return new CreateUserResult() { UserCreateState = UserCreateState.New };
        }
    }
}
