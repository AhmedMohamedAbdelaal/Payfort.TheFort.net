using Newtonsoft.Json;

namespace Start.Net.RequestModels.Charges
{
    public class GetChargeRequest : RequestBase
    {
        public GetChargeRequest()
        {
            base.UriTemplate = "/charges/{0}";
            base.HttpMethod = System.Net.WebRequestMethods.Http.Get;
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
    }
}

