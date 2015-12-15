using Start.Net.Infrastructure;

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

        public StartApiErrorResponse Error { get; internal set; }

        public T Content { get; internal set; }
    }
}
