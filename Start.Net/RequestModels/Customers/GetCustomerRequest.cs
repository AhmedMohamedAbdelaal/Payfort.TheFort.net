using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.RequestModels.Customers
{
    public class GetCustomerRequest: RequestBase
    {
        public GetCustomerRequest()
        {
            base.UriTemplate = "/customers/{0}";
            base.HttpMethod = System.Net.WebRequestMethods.Http.Get;
        }

        private string customerId;

        [JsonProperty("id")]
        public string CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
                base.Uri = string.Format(base.UriTemplate, customerId);
            }
        }
    }
}
