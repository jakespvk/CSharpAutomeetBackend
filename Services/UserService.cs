using Microsoft.EntityFrameworkCore;

namespace AutomeetBackend
{
    public sealed class UserService
    {
        private readonly UserDbContext _context;

        // shouldn't know about the db
        public UserService(UserDbContext context)
        {
            _context = context;
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

        // "this method smells" -Kostya
        // promises to update user sub
        // some mysterious reason can return false
        // should be "TryUpdateUserSubscriptionAsync"
        public async Task<bool> TryUpdateUserSubscriptionAsync(
                string email,
                Subscription subscription
            )
        {
            User? user = await _context
                .Users
                .Include(u => u.DbAdapter)
                .FirstOrDefaultAsync(x => x.Email == email);

            // gray area - maybe belong in UserRepository, maybe not
            // keep in service, kind of business logic
            if (user == null) 
            { 
                return false; 
            }

            user.Subscription = subscription;
            await _context.SaveChangesAsync();
            return true;
        }

        // keep in service, kind of business logic
        public async Task<bool> UpdateUserDbAsync(
                string email,
                DbAdapter dbAdapter,
                List<string>? columns = null,
                List<string>? activeColumns = null
            )
        {
            User? user = await _context
                .Users
                .Include(u => u.DbAdapter)
                .FirstOrDefaultAsync(x => x.Email == email);
            if (user == null) return false;

            user.DbAdapter = dbAdapter;
            if (columns is not null) user.DbAdapter.Columns = columns;
            if (activeColumns is not null) user.DbAdapter.ActiveColumns = activeColumns;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserDbAsync(
                string email
            )
        {
            User? user = await _context
                .Users
                .Include(u => u.DbAdapter)
                .FirstOrDefaultAsync(x => x.Email == email);
            if (user == null) return false;

            user.DbAdapter = null;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
