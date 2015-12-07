using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.ResponseModels
{
    public class CaptureChargeResponse
    {
        [JsonProperty("id")]
        public string ChargeId { get; set; }

        [JsonProperty("amount")]
        public int ChargeAmount { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("captured_amount")]
        public int CapturedAmount { get; set; }
    }
}
