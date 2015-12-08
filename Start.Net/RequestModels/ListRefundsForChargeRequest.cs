using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.RequestModels
{
    public class ListRefundsForChargeRequest: RequestBase
    {
        public ListRefundsForChargeRequest()
        {
            base.UriTemplate = "/charges/{0}/refunds?pagination[after]={1}&pagination[before]={2}";
            base.Uri = string.Format(base.UriTemplate,"{0}", "", ""); //default with no pagination
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
                base.Uri = string.Format(base.UriTemplate, chargeId, After.HasValue ? After.Value.ToString("o") : "", Before.HasValue ? Before.Value.ToString("o") : "");
            }
        }

        private DateTime? before;

        public DateTime? Before
        {
            get
            {
                return before;
            }
            set
            {
                before = value;
                base.Uri = string.Format(base.UriTemplate, chargeId, After.HasValue ? After.Value.ToString("o") : "", before.HasValue ? before.Value.ToString("o") : "");
            }
        }

        private DateTime? after;

        public DateTime? After
        {
            get
            {
                return after;
            }
            set
            {
                after = value;
                base.Uri = string.Format(base.UriTemplate, chargeId, after.HasValue ? after.Value.ToString("o") : "", Before.HasValue ? Before.Value.ToString("o") : "");
            }
        }
    }
}
