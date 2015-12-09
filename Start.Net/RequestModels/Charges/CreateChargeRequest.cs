using Newtonsoft.Json;
using Start.Net.Entities;
using System.Diagnostics;

namespace Start.Net.RequestModels.Charges
{
    public class CreateChargeRequest : RequestBase
    {
        public CreateChargeRequest()
        {
            base.Uri = "/charges";
            base.HttpMethod = System.Net.WebRequestMethods.Http.Post;
        }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("card")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]

        private object Card { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }

        [JsonProperty("capture")]
        public bool Capture { get; set; }

        [JsonProperty("shopping_cart")]
        public ShoppingCart ShoppingCart { get; set; }

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
