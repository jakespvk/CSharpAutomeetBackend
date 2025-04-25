using System.Text.Json.Serialization;

namespace AutomeetBackend
{
    public enum PollFrequency
    {
        Monthly,
        Weekly,
        Daily,
    }

    public class Subscription
    {
        public bool Subscribed { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
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
