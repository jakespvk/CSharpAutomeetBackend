using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace AutomeetBackend.Models
{
    public class AttioAdapter : DbAdapter
    {
        public string AccessToken { get; set; }

        public override System.Guid UserId { get; set; }
        public override List<string>? Columns { get; set; }
        public override List<string>? ActiveColumns { get; set; }

        public AttioAdapter(Guid userId, string accessToken)
        {
            UserId = userId;
            AccessToken = accessToken;
        }

        public async override Task getColumns()
        {
            // make a service class that will give me what I need from HttpClient
            HttpClient client = new HttpClient();
            // client.BaseAddress = new Uri("https://api.attio.com/v2/objects");
            client.BaseAddress = new Uri("http://localhost:5224/v2/objects");
            // client.DefaultRequestHeaders.Authorization =
            //     new System.Net.Http.Headers.AuthenticationHeaderValue(AccessToken);
            var response = await client.GetAsync("/people");
            Console.WriteLine(response.Content);
            this.Columns = await response.Content.ReadFromJsonAsync<List<string>>();
        }

        public async override Task<string> getContactData()
        {
            return await new Task<string>(() => "here in getContactData");
        }
    }
}
