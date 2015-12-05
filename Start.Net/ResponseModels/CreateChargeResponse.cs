using Newtonsoft.Json;
using Start.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.ResponseModels
{
    public class CreateChargeResponse : ResponseBase
    {
        [JsonProperty("charge")]
        public Charge Charge { get; internal set; }
    }
}
