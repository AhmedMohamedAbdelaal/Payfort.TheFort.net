using Newtonsoft.Json;

namespace Start.Net.ResponseModels
{
    public class DeleteCustomerResponse
    {
        [JsonProperty("id")]
        public string CustomerId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}
