namespace AutomeetBackend
{
    sealed class ActiveCampaignAdapter : DbAdapter
    {
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }

        public override Guid UserId { get; set; }
        public override List<string>? Columns { get; set; }
        public override List<string>? ActiveColumns { get; set; }

        public ActiveCampaignAdapter(string apiUrl, string apiKey)
        {
            ApiUrl = apiUrl;
            ApiKey = apiKey;
        }

        public override async Task getColumns()
        {
            // call api and get columns list
            Columns = new List<string> { "id", "name", "email" };
        }

        public override async Task<string> getContactData()
        {
            return await new Task<string>(() => "here in getContactData AC");
        }
    }
}
