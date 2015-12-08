using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.Entities
{
    public class Item
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
