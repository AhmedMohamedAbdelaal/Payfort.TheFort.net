using Newtonsoft.Json;

namespace Start.Net.Entities
{
    public class Card
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("exp_year")]
        public int ExpireYear { get; set; }

        [JsonProperty("exp_month")]
        public int ExpireMonth { get; set; }

        [JsonProperty("cvc")]
        public int Cvc { get; set; }
    }
}
