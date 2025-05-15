using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.IO;
using System.Threading;

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
            client.BaseAddress = new Uri("http://localhost:5224");
            // client.DefaultRequestHeaders.Authorization =
            //     new System.Net.Http.Headers.AuthenticationHeaderValue(AccessToken);
            HttpResponseMessage response = await client.PostAsync("/v2/objects/people", null);

            string str_response = await response.Content.ReadAsStringAsync();
            // Console.WriteLine(str_response);
            JObject json_obj = JObject.Parse(str_response);
            Console.WriteLine(json_obj["data"]?[0]?["id"]);
            // Columns = await response.Content.ReadFromJsonAsync<List<string>>();
        }

        public async override Task<string> getContactData()
        {
            return await new Task<string>(() => "here in getContactData");
        }
    }
}
