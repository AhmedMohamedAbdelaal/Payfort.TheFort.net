using Newtonsoft.Json;
using Start.Net.Entities;
using System.Diagnostics;

namespace Start.Net.RequestModels.Customers
{
    public class CreateCustomerRequest: RequestBase
    {
        public CreateCustomerRequest()
        {
            base.Uri = "/customers";
            base.HttpMethod = System.Net.WebRequestMethods.Http.Post;
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
