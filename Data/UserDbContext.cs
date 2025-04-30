using AutomeetBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomeetBackend.Data
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
                .OwnsOne(u => u.Subscription);
            // modelBuilder.Entity<User>()
            //     .OwnsOne(u => u.DbAdapter, nav =>
            //     {
            //         nav.HasDiscriminator<string>("AdapterType")
            //         .HasValue<AttioAdapter>("Attio")
            //         .HasValue<ActiveCampaignAdapter>("ActiveCampaign");
            //     });

            modelBuilder.Entity<User>()
                .HasOne(u => u.DbAdapter)
                .WithOne()
                .HasForeignKey<DbAdapter>(d => d.UserId);

            modelBuilder.Entity<DbAdapter>()
                .HasDiscriminator<string>("AdapterType")
                .HasValue<AttioAdapter>("Attio")
                .HasValue<ActiveCampaignAdapter>("ActiveCampaign");
        }
    }
}
