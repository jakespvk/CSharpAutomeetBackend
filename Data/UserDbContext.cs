using Microsoft.EntityFrameworkCore;

namespace AutomeetBackend
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.DbAdapter)
                .WithOne();
        }
    }
}
