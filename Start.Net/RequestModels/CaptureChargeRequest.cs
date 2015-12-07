using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.RequestModels
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
