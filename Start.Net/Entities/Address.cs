using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.Entities
{
    public class Address
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
