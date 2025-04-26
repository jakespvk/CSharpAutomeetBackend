using Microsoft.EntityFrameworkCore;

namespace AutomeetBackend
{
    public class UserRepository
    {
        private UserDbContext _context;

        public UserRepository(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }

        // pure repository responsibility
        public async Task<User> CreateUserAsync(string email)
        {
            User user = new User(email);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // change to return User 
        // two options: fail with exception
        // or return default user (create new user or default user)
        public async Task<User?> GetUserAsync(string email)
        {
            return await _context
                .Users
                .Include(u => u.DbAdapter)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
