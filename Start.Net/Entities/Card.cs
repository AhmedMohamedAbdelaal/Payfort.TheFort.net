using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.Entities
{
    public class Card
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        private string Object { get { return "card"; } }

        [JsonProperty("last4")]
        public string Last4 { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("exp_year")]
        public int ExpireYear { get; set; }

        [JsonProperty("exp_month")]
        public int ExpireMonth { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
