using Start.Net.Interfaces;
using Start.Net.ResponseModels;
using Start.Net.Entities;
using Start.Net.RequestModels.Charges;

namespace Start.Net
{
    public class StartTokenService : BaseService, IStartTokenService
    {
        public StartTokenService(string privateKey): base(privateKey)
        {
         
        }        

        public ApiResponse<Token> CreateToken(CreateTokenRequest request)
        {
            ApiResponse<Token> response = SendApiRequest<CreateTokenRequest, Token>(request);
            return response;
        }
         
    } 
}
