namespace AutomeetBackend
{
    public class AttioAdapter : DbAdapter
    {
        public string AccessToken { get; set; }

        public override Guid UserId { get; set; }
        public override List<string>? Columns { get; set; }
        public override List<string>? ActiveColumns { get; set; }

        public AttioAdapter(Guid userId, string accessToken)
        {
            UserId = userId;
            AccessToken = accessToken;
        }

        public async override Task getColumns()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.attio.com/v2/objects");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(AccessToken);
            var response = await client.GetAsync("/people");
            Console.WriteLine(response.Content);
            this.Columns = await response.Content.ReadFromJsonAsync<List<string>>();
        }

        public override Task<string> getContactData()
        {
            return new Task<string>(() => "here in getContactData");
        }
    }
}
