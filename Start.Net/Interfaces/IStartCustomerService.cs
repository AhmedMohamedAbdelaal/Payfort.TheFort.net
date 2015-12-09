using Start.Net.Entities;
using Start.Net.RequestModels.Customers;
using Start.Net.ResponseModels;

namespace Start.Net.Interfaces
{
    public interface IStartCustomerService
    {
        ApiResponse<Customer> CreateCustomer(CreateCustomerRequest request);
        ApiResponse<Customer> GetCustomer(GetCustomerRequest request);
        ApiResponse<Customer> UpdateCustomer(UpdateCustomerRequest request);
        PagedApiResponse<Customer> ListCustomers(ListCustomersRequest request);
    }
}
