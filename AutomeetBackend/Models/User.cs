using System;

namespace AutomeetBackend.Models
{
    public sealed class User
    {
        public Guid Id { get; set; } = new Guid();
        public string Email { get; set; }
        public Subscription Subscription { get; set; }
        public DbAdapter? DbAdapter { get; set; }

        public User()
        {
            Email = "";
            Subscription = new Subscription();
        }

        public User(string email)
        {
            Email = email;
            Subscription = new Subscription();
        }
    }
}
