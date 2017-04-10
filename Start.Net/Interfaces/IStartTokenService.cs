using Start.Net.Entities;
using Start.Net.RequestModels;
using Start.Net.RequestModels.Charges;
using Start.Net.ResponseModels;

namespace Start.Net.Interfaces
{
    public interface IStartTokenService
    {

        ApiResponse<Token> CreateToken(CreateTokenRequest request);
    }
}
