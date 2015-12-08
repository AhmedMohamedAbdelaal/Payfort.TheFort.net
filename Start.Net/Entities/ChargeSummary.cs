using Newtonsoft.Json;
using System;

namespace Start.Net.Entities
{
    public class ChargeSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("captured_amount")]
        public int CapturedAmount { get; set; }

        [JsonProperty("refunded_amount")]
        public int RefundedAmount { get; set; }
    }
}
