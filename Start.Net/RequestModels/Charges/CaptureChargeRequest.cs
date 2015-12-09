using Newtonsoft.Json;

namespace Start.Net.RequestModels.Charges
{
    public class CaptureChargeRequest: RequestBase
    {
        public CaptureChargeRequest()
        {
            base.UriTemplate = "/charges/{0}/capture";
            base.HttpMethod = System.Net.WebRequestMethods.Http.Post;
        }

        private string chargeId;

        [JsonProperty("id")]
        public string ChargeId
        {
            get
            {
                return chargeId;
            }
            set
            {
                chargeId = value;
                base.Uri = string.Format(base.UriTemplate, chargeId);
            }
        }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
