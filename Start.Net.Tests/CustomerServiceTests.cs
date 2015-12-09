using Microsoft.VisualStudio.TestTools.UnitTesting;
using Start.Net.Constants;
using Start.Net.Entities;
using Start.Net.Interfaces;
using Start.Net.RequestModels.Customers;
using Start.Net.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private IStartCustomerService _customerService;
        private CreateCustomerRequest _createCustomerRequest;
        private Card _cardDetails;

        public CustomerServiceTests()
        {
            _customerService = new StartCustomerService("test_sec_k_8512e94e69d6a46c67ab2");
            _createCustomerRequest = new CreateCustomerRequest() {
                Name = "Customer Name",
                Description = "Description",
                Email = "customer@email.com"
            };
            _cardDetails = new Card()
            {
                Name = "Abdullah Ahmed",
                Cvc = 123,
                ExpireMonth = 12,
                ExpireYear = 2020,
                Number = "4242424242424242"
            };
        }

        [TestMethod]
        public void CreateCustomer_UsingCardDetails_Success()
        {
            _createCustomerRequest.CardDetails = new Card()
           { 
                Name = "Abdullah Ahmed",
                Cvc = 123,
                ExpireMonth = 12,
                ExpireYear = 2020,
                Number = "4242424242424242"
            };

            ApiResponse<Customer> response = _customerService.CreateCustomer(_createCustomerRequest);

            Assert.IsFalse(response.IsError);
            Assert.IsTrue(!string.IsNullOrEmpty(response.Content.Id));
        }

        [TestMethod]
        public void CreateCustomer_EmailMissing_Fails()
        {
            _createCustomerRequest.CardDetails = _cardDetails;

            _createCustomerRequest.Email = string.Empty;

            ApiResponse<Customer> createCustomerResponse = _customerService.CreateCustomer(_createCustomerRequest);

            Assert.IsTrue(createCustomerResponse.IsError);
            Assert.IsTrue(createCustomerResponse.Error.Type == ErrorType.Request);
            Assert.AreEqual("Request params are invalid.", createCustomerResponse.Error.Message);
            Assert.IsTrue(createCustomerResponse.Error.Extras == "{\r\n  \"email\": [\r\n    \"can't be blank\"\r\n  ],\r\n  \"card\": []\r\n}");
            Assert.AreEqual(ErrorCode.UnprocessableEntity, createCustomerResponse.Error.Code);
        }

        [TestMethod]
        public void GetCustomer_Success()
        {
            _createCustomerRequest.CardDetails = _cardDetails;

            ApiResponse<Customer> createCustomerResponse = _customerService.CreateCustomer(_createCustomerRequest);

            ApiResponse<Customer> getCustomerResponse = _customerService.GetCustomer(new GetCustomerRequest() { CustomerId = createCustomerResponse.Content.Id });

            Assert.IsFalse(createCustomerResponse.IsError);
            Assert.IsFalse(getCustomerResponse.IsError);
            Assert.AreEqual(createCustomerResponse.Content.Id, getCustomerResponse.Content.Id);
            Assert.AreEqual(createCustomerResponse.Content.Cards[0].Brand, getCustomerResponse.Content.Cards[0].Brand);
            Assert.AreEqual(createCustomerResponse.Content.Cards[0].ExpireMonth, getCustomerResponse.Content.Cards[0].ExpireMonth);
            Assert.AreEqual(createCustomerResponse.Content.Cards[0].ExpireYear, getCustomerResponse.Content.Cards[0].ExpireYear);
            Assert.AreEqual(createCustomerResponse.Content.Cards[0].Id, getCustomerResponse.Content.Cards[0].Id);
            Assert.AreEqual(createCustomerResponse.Content.Cards[0].Last4, getCustomerResponse.Content.Cards[0].Last4);
            Assert.AreEqual(createCustomerResponse.Content.Cards[0].Name, getCustomerResponse.Content.Cards[0].Name);
            Assert.AreEqual(createCustomerResponse.Content.CreatedAt, getCustomerResponse.Content.CreatedAt);
            Assert.AreEqual(createCustomerResponse.Content.DefaultCardId, getCustomerResponse.Content.DefaultCardId);
            Assert.AreEqual(createCustomerResponse.Content.Description, getCustomerResponse.Content.Description);
            Assert.AreEqual(createCustomerResponse.Content.Email, getCustomerResponse.Content.Email);
            Assert.AreEqual(createCustomerResponse.Content.Name, getCustomerResponse.Content.Name);
            Assert.AreEqual(createCustomerResponse.Content.UpdatedAt, getCustomerResponse.Content.UpdatedAt);
        }

        [TestMethod]
        public void GetCustomer_NotFound_Fails()
        {
            var getCustomerRequest = new GetCustomerRequest() { CustomerId = "not_found" };
            ApiResponse<Customer> getCustomerResponse = _customerService.GetCustomer(getCustomerRequest);

            Assert.IsTrue(getCustomerResponse.IsError);
            Assert.IsTrue(getCustomerResponse.Error.Type == ErrorType.Request);
            Assert.AreEqual(string.Format("Couldn't find Customer with 'id'={0}.", getCustomerRequest.CustomerId), getCustomerResponse.Error.Message);
            Assert.AreEqual(ErrorCode.NotFound, getCustomerResponse.Error.Code);
        }

        [TestMethod]
        public void UpdateCustomer_Success()
        {
            _createCustomerRequest.CardDetails = _cardDetails;

            ApiResponse<Customer> createCustomerResponse = _customerService.CreateCustomer(_createCustomerRequest);

            UpdateCustomerRequest updateRequest = new UpdateCustomerRequest()
            {
                CustomerId = createCustomerResponse.Content.Id,
                Email = "modified@modified.com",
                Description = "updated",
                Name = "name updated",
                CardDetails = new Card()
                {
                    Name = "Abdullah Ahmed Updated",
                    Cvc = 456,
                    ExpireMonth = 1,
                    ExpireYear = 2018,
                    Number = "4000000000000101"
                }
            };

            ApiResponse<Customer> updateCustomerResponse = _customerService.UpdateCustomer(updateRequest);
            ApiResponse<Customer> getUpdatedCustomerResponse = _customerService.GetCustomer(new GetCustomerRequest() { CustomerId = updateCustomerResponse.Content.Id });

            Assert.IsFalse(createCustomerResponse.IsError);
            Assert.IsFalse(getUpdatedCustomerResponse.IsError);
            Assert.AreEqual(updateRequest.CustomerId, getUpdatedCustomerResponse.Content.Id);
            Assert.AreEqual(updateRequest.CardDetails.ExpireMonth, getUpdatedCustomerResponse.Content.Cards[0].ExpireMonth);
            Assert.AreEqual(updateRequest.CardDetails.ExpireYear, getUpdatedCustomerResponse.Content.Cards[0].ExpireYear);
            Assert.AreEqual(updateRequest.CardDetails.Name, getUpdatedCustomerResponse.Content.Cards[0].Name);
            Assert.AreEqual(updateRequest.CardDetails.Number.Substring(updateRequest.CardDetails.Number.Length - 4), getUpdatedCustomerResponse.Content.Cards[0].Last4);
            Assert.AreEqual(updateRequest.Description, getUpdatedCustomerResponse.Content.Description);
            Assert.AreEqual(updateRequest.Email, getUpdatedCustomerResponse.Content.Email);
            Assert.AreEqual(updateRequest.Name, getUpdatedCustomerResponse.Content.Name);
        }

        [TestMethod]
        public void UpdateCustomer_NotFound_Fails()
        {
            UpdateCustomerRequest updateRequest = new UpdateCustomerRequest()
            {
                CustomerId = "not_found",
                Description = "updated",
                CardDetails = new Card()
                {
                    Name = "Abdullah Ahmed Updated",
                    Cvc = 456,
                    ExpireMonth = 1,
                    ExpireYear = 2018,
                    Number = "4000000000000101"
                }
            };

            ApiResponse<Customer> updateCustomerResponse = _customerService.UpdateCustomer(updateRequest);
            Assert.IsTrue(updateCustomerResponse.IsError);
            Assert.IsTrue(updateCustomerResponse.Error.Type == ErrorType.Request);
            Assert.AreEqual(string.Format("Couldn't find Customer with 'id'={0}.", updateRequest.CustomerId), updateCustomerResponse.Error.Message);
            Assert.AreEqual(ErrorCode.NotFound, updateCustomerResponse.Error.Code);
        }

        [TestMethod]
        public void ListCustomers_Success()
        {
            _createCustomerRequest.CardDetails = _cardDetails;

            ApiResponse<Customer> createCustomerResponse = _customerService.CreateCustomer(_createCustomerRequest);
            _customerService.CreateCustomer(_createCustomerRequest);
            _customerService.CreateCustomer(_createCustomerRequest);

            ListCustomersRequest request = new ListCustomersRequest();
            PagedApiResponse<Customer> customers = _customerService.ListCustomers(request);

            Assert.IsFalse(customers.IsError);
            Assert.IsTrue(customers.Content.Count >= 3);
        }

        [TestMethod]
        public void ListCustomers_PagedBefore_Success()
        {
            _createCustomerRequest.CardDetails = _cardDetails;
            ApiResponse<Customer> createCustomerResponse = _customerService.CreateCustomer(_createCustomerRequest);

            ListCustomersRequest request = new ListCustomersRequest();
            DateTime beforeFilter = DateTime.Now.ToUniversalTime();
            request.Before = beforeFilter;

            PagedApiResponse<Customer> customers = _customerService.ListCustomers(request);

            Assert.IsFalse(customers.IsError);
            Assert.IsFalse(customers.Content.Any(c => c.Id == createCustomerResponse.Content.Id)); // customer should be missing because of pagination
        }

        [TestMethod]
        public void ListCustomers_PagedAfter_Success()
        {
            DateTime afterFilter = DateTime.Now.ToUniversalTime();
            _createCustomerRequest.CardDetails = _cardDetails;
            ApiResponse<Customer> createCustomerResponse = _customerService.CreateCustomer(_createCustomerRequest);

            ListCustomersRequest request = new ListCustomersRequest();
            request.After = afterFilter;

            PagedApiResponse<Customer> customers = _customerService.ListCustomers(request);

            Assert.IsFalse(customers.IsError);
            Assert.IsTrue(customers.Content.Any(c => c.Id == createCustomerResponse.Content.Id)); // customer should be there because of pagination
        }
    }
}
