using Start.Net.Entities;
using Start.Net.RequestModels;
using Start.Net.RequestModels.Refunds;
using Start.Net.ResponseModels;

namespace Start.Net.Interfaces
{
    public interface IStartRefundService
    {
        ApiResponse<Refund> RefundCharge(RefundChargeRequest request);

        PagedApiResponse<Refund> ListRefundsForCharge(ListRefundsForChargeRequest request);
    }
}
