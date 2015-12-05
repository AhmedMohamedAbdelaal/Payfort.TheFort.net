using Newtonsoft.Json;
using Start.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.RequestModels
{
    public class CreateChargeRequest: RequestBase
    {
        public CreateChargeRequest()
        {
            base.Uri = "/charges";
            base.HttpMethod = System.Net.WebRequestMethods.Http.Post;
        }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("card")]

        public string Card { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }

        [JsonProperty("capture")]
        public bool Capture { get; set; }

        [JsonProperty("shopping_cart")]
        public string ShoppingCart { get; set; }
    }
}
