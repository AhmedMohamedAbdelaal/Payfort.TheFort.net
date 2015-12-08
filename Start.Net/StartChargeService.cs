using Start.Net.Interfaces;
using Start.Net.RequestModels;
using Start.Net.ResponseModels;
using Start.Net.Entities;
using System.Collections.Generic;

namespace Start.Net
{
    public class StartChargeService : BaseService, IStartChargeService
    {
        public StartChargeService(string privateKey): base(privateKey)
        {
         
        }

        public ApiResponse<Charge> CreateCharge(CreateChargeRequest request)
        {
            ApiResponse<Charge> response = SendApiRequest<CreateChargeRequest, Charge>(request);
            return response;
        }

        public ApiResponse<Charge> GetCharge(GetChargeRequest request)
        {
            ApiResponse<Charge> response = SendApiRequest<GetChargeRequest, Charge>(request);
            return response;
        }

        public ApiResponse<CaptureChargeResponse> CaptureCharge(CaptureChargeRequest request)
        {
            ApiResponse<CaptureChargeResponse> response = SendApiRequest<CaptureChargeRequest, CaptureChargeResponse>(request);
            return response;
        }

        public PagedApiResponse<Charge> ListCharges(ListChargesRequest request)
        {
            PagedApiResponse<Charge> response = GetPagedApiResponse<ListChargesRequest, Charge>(request);
            return response;
        }
    } 
}
