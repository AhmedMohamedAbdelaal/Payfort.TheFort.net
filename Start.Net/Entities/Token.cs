using Newtonsoft.Json;

namespace Start.Net.Entities
{
    public class Token
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("created_at")]
        public string Created_At { get; set; }

        [JsonProperty("used")]
        public bool Used { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }
    }
}
 