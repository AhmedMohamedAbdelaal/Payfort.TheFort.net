using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.RequestModels
{
    public class RequestBase
    {
        internal string Uri { get; set; }
        internal string HttpMethod { get; set; }
    }
}
