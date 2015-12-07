using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.RequestModels
{
    public class ListChargesRequest: RequestBase
    {
        public ListChargesRequest()
        {
            base.Uri = "/charges";
            base.HttpMethod = System.Net.WebRequestMethods.Http.Get;
        }
    }
}
