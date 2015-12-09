namespace Start.Net.RequestModels
{
    public class RequestBase
    {
        internal string Uri { get; set; }
        internal string HttpMethod { get; set; }
        protected internal string UriTemplate { get; set; }
    }
}
