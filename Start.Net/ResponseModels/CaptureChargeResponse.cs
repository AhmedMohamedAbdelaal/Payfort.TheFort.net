using Newtonsoft.Json;

namespace Start.Net.ResponseModels
{
    public class CaptureChargeResponse
    {
        [JsonProperty("id")]
        public string ChargeId { get; internal set; }

        [JsonProperty("amount")]
        public int ChargeAmount { get; internal set; }

        [JsonProperty("state")]
        public string State { get; internal set; }

        [JsonProperty("captured_amount")]
        public int CapturedAmount { get; internal set; }
    }
}
