using Newtonsoft.Json;
using Start.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.ResponseModels
{
    public class CreateChargeResponse : ResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        private string Object { get { return "charge"; } }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("captured_amount")]
        public int CapturedAmount { get; set; }

        [JsonProperty("refunded_amount")]
        public int RefundedAmount { get; set; }

        [JsonProperty("failure_reason")]
        public string FailureReason { get; set; }

        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("card")]
        public CardSummary Card { get; set; }
    }
}
