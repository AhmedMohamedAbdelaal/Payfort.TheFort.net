using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.Infrastructure
{
    public class StartApiErrorResponse
    {
        [JsonProperty("type")]
        public string Type { get; set;}

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("extas")]
        public Dictionary<string,string> Extras { get; set; }
    }
}
