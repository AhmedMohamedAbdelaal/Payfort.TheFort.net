using Newtonsoft.Json;

namespace Start.Net.RequestModels
{
    public class RefundChargeRequest: RequestBase
    {
        public RefundChargeRequest()
        {
            base.UriTemplate = "/charges/{0}/refunds";
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

        [JsonProperty("reson")]
        public string Reason { get; set; }
    }
}
