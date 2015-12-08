using Start.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Start.Net.Entities;
using Start.Net.RequestModels;
using Start.Net.ResponseModels;

namespace Start.Net
{
    public class StartRefundService : BaseService, IStartRefundService
    {
        public StartRefundService(string privateKey) : base(privateKey)
        {

        }

        public ApiResponse<Refund> RefundCharge(RefundChargeRequest request)
        {
            ApiResponse<Refund> response = SendApiRequest<RefundChargeRequest, Refund>(request);
            return response;
        }

        public PagedApiResponse<Refund> ListRefundsForCharge(ListRefundsForChargeRequest request)
        {
            PagedApiResponse<Refund> response = GetPagedApiResponse<ListRefundsForChargeRequest, Refund>(request);
            return response;
        }
    }
}
