using Start.Net.Interfaces;
using Start.Net.Entities;
using Start.Net.RequestModels.Customers;
using Start.Net.ResponseModels;

namespace Start.Net
{
    public class StartCustomerService : BaseService, IStartCustomerService
    {
        public StartCustomerService(string privateKey): base(privateKey)
        {

        }

        public ApiResponse<Customer> CreateCustomer(CreateCustomerRequest request)
        {
            ApiResponse<Customer> response = SendApiRequest<CreateCustomerRequest, Customer>(request);
            return response;
        }
        public ApiResponse<Customer> GetCustomer(GetCustomerRequest request)
        {
            ApiResponse<Customer> response = SendApiRequest<GetCustomerRequest, Customer>(request);
            return response;
        }
        public ApiResponse<Customer> UpdateCustomer(UpdateCustomerRequest request)
        {
            ApiResponse<Customer> response = SendApiRequest<UpdateCustomerRequest, Customer>(request);
            return response;

        }

        public ApiResponse<DeleteCustomerResponse> DeleteCustomer(DeleteCustomerRequest request)
        {
            ApiResponse<DeleteCustomerResponse> response = SendApiRequest<DeleteCustomerRequest, DeleteCustomerResponse>(request);
            return response;
        }

        public PagedApiResponse<Customer> ListCustomers(ListCustomersRequest request)
        {
            PagedApiResponse<Customer> response = GetPagedApiResponse<ListCustomersRequest, Customer>(request);
            return response;
        }

    }
}
