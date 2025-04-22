namespace AutomeetBackend
{
    public sealed class User
    {
        private Guid id = Guid.NewGuid();

        public Guid Id { get; set; }
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
