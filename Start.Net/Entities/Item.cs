using Newtonsoft.Json;

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
