using Start.Net.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Start.Net.RequestModels;
using Start.Net.ResponseModels;
using System.Net;

namespace Start.Net
{
    public class StartChargeService : IStartChargeService
    {
        private string EndpointBase = @"https://api.start.payfort.com";
        private HttpClient _apiClient { get; set; }

        private string PrivateKey {get; set;}

        public StartChargeService(string privateKey)
        {
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(EndpointBase);
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", GetAuthorizationHeaderValue(privateKey));

            PrivateKey = privateKey;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public ApiResponse<CreateChargeResponse> CreateCharge(CreateChargeRequest request)
        {
            ApiResponse<CreateChargeResponse> response = SendApiRequest<CreateChargeRequest, CreateChargeResponse>(request);
            return response;
        }

        private ApiResponse<ResponseType> SendApiRequest<RequestType, ResponseType>(RequestType request)
            where ResponseType : ResponseBase, new()
            where RequestType : RequestBase, new()
        {
            ApiResponse<ResponseType> apiResponse = new ApiResponse<ResponseType>();

            switch(request.HttpMethod)
            {
                case "POST":
                    {
                        HttpResponseMessage response = _apiClient.PostAsJsonAsync<RequestType>(request.Uri, request).Result;
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        apiResponse.Response = response.Content.ReadAsAsync<ResponseType>().Result;

                        break;
                    }
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
