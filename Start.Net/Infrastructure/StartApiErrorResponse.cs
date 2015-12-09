using Newtonsoft.Json;

namespace Start.Net.Infrastructure
{
    public class StartApiErrorResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("extras")]
        public string Extras { get; set; }
    }
}
