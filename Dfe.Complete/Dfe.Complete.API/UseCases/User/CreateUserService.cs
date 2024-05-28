using Dfe.Complete.API.Contracts.User;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.Data;

namespace Dfe.Complete.API.UseCases.User
{
    public interface ICreateUserService
    {
        public Task Execute(CreateUserRequest request);
    }

    public class CreateUserService : ICreateUserService
    {
        private readonly CompleteContext _context;

        public CreateUserService(CompleteContext context, ILogger<CreateUserService> logger)
        {
            _context = context;
        }

        public async Task Execute(CreateUserRequest request)
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
                throw new ResourceConflictException("User with email already exists, no record has been created");
            }

            _context.Users.Add(dbUser);

            await _context.SaveChangesAsync();
        }
    }
}
