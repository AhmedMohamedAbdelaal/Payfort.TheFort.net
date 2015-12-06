using Start.Net.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.ResponseModels
{
    public class ResponseBase
    {
        public bool IsError
        {
            get { return Error == null; }
        }

        public StartApiErrorResponse Error { get; set; }
    }
}
