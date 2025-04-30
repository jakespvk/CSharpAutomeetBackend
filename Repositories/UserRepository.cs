using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutomeetBackend.Data;
using AutomeetBackend.Models;

namespace AutomeetBackend.Repositories
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

        /* 
           can't remember specific pattern to handle nonexistant (try to get
           entity with incorrect params, no such entity)

           another approach: always return collection, empty or 1 or more
           -- doesn't change much

           in ORM that Policy uses, own custom unit of work and Service
           call inService 
           on the repository level here
           in Policy case separated from each repository
           dedicated unit of work (unit of work is a pattern)
            between repository and dbcontext, services can also
            access if they *need* to directly


           */
    }
}
