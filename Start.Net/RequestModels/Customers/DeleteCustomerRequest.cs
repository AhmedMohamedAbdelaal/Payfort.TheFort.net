using Newtonsoft.Json;

namespace Start.Net.RequestModels.Customers
{
    public class DeleteCustomerRequest: RequestBase
    {
        public DeleteCustomerRequest()
        {
            base.UriTemplate = "/customers/{0}";
            base.HttpMethod = "DELETE";
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
