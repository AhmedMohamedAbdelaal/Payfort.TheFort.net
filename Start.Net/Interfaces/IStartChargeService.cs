using Start.Net.Entities;
using Start.Net.RequestModels;
using Start.Net.RequestModels.Charges;
using Start.Net.ResponseModels;

namespace Start.Net.Interfaces
{
    public interface IStartChargeService
    {
        ApiResponse<Charge> CreateCharge(CreateChargeRequest request);

        ApiResponse<Charge> GetCharge(GetChargeRequest request);

        PagedApiResponse<Charge> ListCharges(ListChargesRequest request);
    }
}
