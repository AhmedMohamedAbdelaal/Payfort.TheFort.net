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
        public bool IsValid
        {
            get { return Errors == null || Errors.Count() == 0; }
        }

        public List<ValidationError> Errors { get; set; }
    }
}
