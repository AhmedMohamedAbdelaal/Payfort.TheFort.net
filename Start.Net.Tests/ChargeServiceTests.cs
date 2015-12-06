using Start.Net.RequestModels;
using Start.Net.Constants;
using Start.Net.ResponseModels;
using Start.Net.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Start.Net.Tests
{
    [TestClass]
    public class ChargeServiceTests
    {
        private StartChargeService _service;
        private CreateChargeRequest _createChargeRequest;
        private CardDetails _workingCard; 

        public ChargeServiceTests()
        {
            _service = new StartChargeService("test_sec_k_63b07e79c620fcfee5a24");
            _workingCard = new CardDetails()
            {
                Name = "Abdullah Ahmed",
                Cvc = 123,
                ExpireMonth = 12,
                ExpireYear = 2020,
                Number = "4242424242424242"
            };
            _createChargeRequest = new CreateChargeRequest()
            {
                Amount = 10000,
                Currency = Currency.AED,
                Email = "john.doe@gmail.com"
            };
        }

        [TestMethod]
        public void CreateCharge_UsingToken_FailsWithTokenAlreadyUsed()
        {
            _createChargeRequest = new CreateChargeRequest() {
                 Amount = 10000,
                 Currency = Currency.AED,
                Email = "john.doe@gmail.com"
            };

            _createChargeRequest.CardToken = "tok_99af1278b71929fb6c2268fce091";

            CreateChargeResponse response = _service.CreateCharge(_createChargeRequest).Response;

            Assert.IsTrue(response.IsError);
            Assert.IsTrue(string.IsNullOrEmpty(response.Id));
            Assert.IsTrue(response.Error.Type == ErrorType.Request);
        }

        [TestMethod]
        public void CreateCharge_UsingCardDetails_Success()
        {
            _createChargeRequest.CardDetails = _workingCard;

            CreateChargeResponse response = _service.CreateCharge(_createChargeRequest).Response;

            Assert.IsTrue(!string.IsNullOrEmpty(response.Id));
        }

        [TestMethod]
        public void CreateCharge_FailsWithRequestError()
        {
            _createChargeRequest.CardDetails = _workingCard;
            _createChargeRequest.CardDetails.ExpireYear = 2013;

            CreateChargeResponse response = _service.CreateCharge(_createChargeRequest).Response;

            Assert.IsTrue(response.IsError);
            Assert.IsTrue(string.IsNullOrEmpty(response.Id));
            Assert.IsTrue(response.Error.Type == ErrorType.Request);
        }

        [TestMethod]
        public void CreateCharge_FailsWithBankingError()
        {
            _createChargeRequest.CardDetails = _workingCard;
            _createChargeRequest.CardDetails.Number = "4000000000000002";

            CreateChargeResponse response = _service.CreateCharge(_createChargeRequest).Response;

            Assert.IsTrue(response.IsError);
            Assert.IsTrue(string.IsNullOrEmpty(response.Id));
            Assert.IsTrue(response.Error.Type == ErrorType.Banking);
        }


        [TestMethod]
        public void CreateCharge_FailsWithAuthError()
        {
            _service = new StartChargeService("wrong_key");

            _createChargeRequest.CardDetails = _workingCard;

            CreateChargeResponse response = _service.CreateCharge(_createChargeRequest).Response;

            Assert.IsTrue(response.IsError);
            Assert.IsTrue(string.IsNullOrEmpty(response.Id));
            Assert.IsTrue(response.Error.Type == ErrorType.Authentication);
        }

        [TestMethod]
        public void CreateCharge_FailsWith500Error()
        {
            _createChargeRequest.CardDetails = _workingCard;
            _createChargeRequest.CardDetails.Number = "4000000000000127";

            CreateChargeResponse response = _service.CreateCharge(_createChargeRequest).Response;

            Assert.IsTrue(response.IsError);
            Assert.IsTrue(string.IsNullOrEmpty(response.Id));
            Assert.IsTrue(response.Error.Type == ErrorType.Processing);
        }
    }
}
