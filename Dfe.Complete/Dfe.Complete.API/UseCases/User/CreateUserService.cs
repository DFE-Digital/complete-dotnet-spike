using Dfe.Complete.API.Contracts.User;
using Dfe.Complete.Data;

namespace Dfe.Complete.API.UseCases.User
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
        private readonly CompleteContext _context;

        public CreateUserService(CompleteContext context, ILogger<CreateUserService> logger)
        {
            _context = context;
        }

        public CreateUserResult Execute(CreateUserRequest request)
        {
            var dbUser = new Data.Entities.User()
            {
                Email = request.Email.ToLower().Trim(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
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
