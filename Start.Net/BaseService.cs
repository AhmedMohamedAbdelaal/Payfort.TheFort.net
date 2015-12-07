using Newtonsoft.Json.Linq;
using Start.Net.Infrastructure;
using Start.Net.RequestModels;
using Start.Net.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net
{
    public class BaseService
    {
        private string EndpointBase = @"https://api.start.payfort.com";
        private HttpClient _apiClient { get; set; }

        public BaseService(string privateKey)
        {
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(EndpointBase);
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", GetAuthorizationHeaderValue(privateKey));

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected ApiResponse<ResponseType> SendApiRequest<RequestType, ResponseType>(RequestType request)
            where RequestType : RequestBase, new()
            where ResponseType : class, new()

        {
            ApiResponse<ResponseType> apiResponse = new ApiResponse<ResponseType>();
            HttpResponseMessage httpResponse = null;

            switch (request.HttpMethod)
            {
                case "POST":
                    {
                        httpResponse = _apiClient.PostAsJsonAsync<RequestType>(request.Uri, request).Result;
                        break;
                    }
                case "GET":
                    {
                        httpResponse = _apiClient.GetAsync(request.Uri).Result;
                        break;
                    }
            }

            if (httpResponse.IsSuccessStatusCode)
                apiResponse.Response = httpResponse.Content.ReadAsAsync<ResponseType>().Result;
            else
            {
                apiResponse.Error = new StartApiErrorResponse();
                string responseString = httpResponse.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(responseString);
                apiResponse.Error.Type = json["error"]["type"].ToString();
                apiResponse.Error.Message = json["error"]["message"].ToString();
                apiResponse.Error.Code = json["error"]["code"].ToString();
                apiResponse.Error.Extras = json["error"]["extras"].ToString();
            }

            return apiResponse;
        }

        private string GetAuthorizationHeaderValue(string apiKey)
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", apiKey)));
            return string.Format("Basic {0}", token);
        }
    }
}
