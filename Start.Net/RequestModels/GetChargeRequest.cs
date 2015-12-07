using Newtonsoft.Json;
using Start.Net.Entities;
using System.Diagnostics;

namespace Start.Net.RequestModels
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

