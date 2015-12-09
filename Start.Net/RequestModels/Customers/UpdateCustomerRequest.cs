using Newtonsoft.Json;
using Start.Net.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.RequestModels.Customers
{
    public class UpdateCustomerRequest: RequestBase
    {
        public UpdateCustomerRequest()
        {
            base.UriTemplate = "/customers/{0}";
            base.HttpMethod = System.Net.WebRequestMethods.Http.Put;
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

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("card")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private object Card { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool usesToken = true;

        [JsonIgnore]
        public string CardToken
        {
            get
            {
                if (usesToken)
                    return (string)Card;
                else
                    return string.Empty;
            }
            set
            {
                Card = value;
                usesToken = true;
            }
        }

        [JsonIgnore]
        public Card CardDetails
        {
            get
            {
                if (usesToken)
                    return null;
                else
                    return (Card)Card;
            }
            set
            {
                Card = value;
                usesToken = false;
            }
        }

    }
}
