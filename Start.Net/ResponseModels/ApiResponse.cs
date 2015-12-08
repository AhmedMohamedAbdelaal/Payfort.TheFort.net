using Start.Net.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.ResponseModels
{
    public class ApiResponse<T> where T : class, new()
    {
        public ApiResponse()
        {
            this.Content = new T();
        }

        public bool IsError
        {
            get { return Error != null; }
        }

        public StartApiErrorResponse Error { get; set; }

        public T Content { get; internal set; }
    }
}
