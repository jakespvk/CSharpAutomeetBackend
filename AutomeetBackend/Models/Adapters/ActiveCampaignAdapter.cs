using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomeetBackend.Models
{
    public class ActiveCampaignAdapter : DbAdapter
    {
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }

        public override System.Guid UserId { get; set; }
        public override List<string>? Columns { get; set; }
        public override List<string>? ActiveColumns { get; set; }

        public ActiveCampaignAdapter(Guid userId, string apiUrl, string apiKey)
        {
            UserId = userId;
            ApiUrl = apiUrl;
            ApiKey = apiKey;
        }

        public override async Task getColumns()
        {
            // call api and get columns list
            await Task.Run(() => "hi");
            Columns = new List<string> { "id", "name", "email" };
        }

        public override async Task<string> getContactData()
        {
            return await new Task<string>(() => "here in getContactData AC");
        }
    }
}
