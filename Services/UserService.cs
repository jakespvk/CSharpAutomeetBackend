namespace AutomeetBackend
{
    public sealed class UserService
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(string email)
        {
            User user = new User(email);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> UpdateUserSubscriptionAsync(
                string email,
                Subscription subscription
            )
        {
            User? user = await _context.Users.FindAsync(email);
            if (user == null) return false;

            user.Subscription = subscription;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserDbAsync(
                string email,
                DbAdapter dbAdapter
            )
        {
            User? user = await _context.Users.FindAsync(email);
            if (user == null) return false;

            user.DbAdapter = dbAdapter;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
