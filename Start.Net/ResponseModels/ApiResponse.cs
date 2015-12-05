using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.ResponseModels
{
    public class ApiResponse<T> where T : ResponseBase, new()
    {
        public ApiResponse()
        {
            this.Response = new T();
        }

        public T Response { get; internal set; }
    }
}
