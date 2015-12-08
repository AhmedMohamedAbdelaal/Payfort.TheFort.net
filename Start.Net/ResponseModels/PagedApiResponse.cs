using Newtonsoft.Json;
using Start.Net.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.ResponseModels
{
    public class PagedApiResponse<T> where T : class, new()
    {
        public bool IsError
        {
            get { return Error != null; }
        }

        public StartApiErrorResponse Error { get; set; }

        public List<T> Content { get; internal set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public class Meta
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("before")]
        public DateTime? Before { get; set; }

        [JsonProperty("after")]
        public DateTime? After { get; set; }
    }
}
