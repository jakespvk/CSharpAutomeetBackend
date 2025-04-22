namespace AutomeetBackend
{
    public enum PollFrequency
    {
        Monthly,
        Weekly,
        Daily,
    }

    public sealed class Subscription
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid UserId { get; set; }
        public bool Subscribed { get; set; }
        public PollFrequency PollFrequency { get; set; }

        public Subscription()
        {
            Subscribed = false;
            PollFrequency = PollFrequency.Monthly;
        }

        public Subscription(bool subscribed, PollFrequency pollFrequency)
        {
            Subscribed = subscribed;
            PollFrequency = pollFrequency;
        }
    }
}
