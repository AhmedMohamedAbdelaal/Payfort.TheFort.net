using Microsoft.VisualStudio.TestTools.UnitTesting;
using Start.Net.RequestModels;
using Start.Net.Constants;
using Start.Net.ResponseModels;
using Start.Net.Entities;

namespace Start.Net.Tests
{
    [TestClass]
    public class ChargeServiceTests
    {
        private StartChargeService _service;
        private CardDetails workingCard; 

        public ChargeServiceTests()
        {
            _service = new StartChargeService("test_sec_k_9bceb341a433a9a5344fe");
            workingCard = new CardDetails()
            {
                Name = "Abdullah Ahmed",
                Cvc = 123,
                ExpireMonth = 12,
                ExpireYear = 2020,
                Number = "4242424242424242"
            };
        }

        [TestMethod]
        public void CreateCharge_UsingToken_Success()
        {
            CreateChargeRequest request = new CreateChargeRequest() {
                 Amount = 10000,
                 Currency = Currency.AED,
                Email = "john.doe@gmail.com"
            };

            request.CardToken = "tok_99af1278b71929fb6c2268fce091";

            CreateChargeResponse response = _service.CreateCharge(request).Response;
            Assert.IsFalse(response.IsError);
        }

        [TestMethod]
        public void CreateCharge_UsingCardDetails_Success()
        {
            CreateChargeRequest request = new CreateChargeRequest()
            {
                Amount = 10000,
                Currency = Currency.USD,
                Email = "john.doe@gmail.com"
            };

            request.CardDetails = workingCard;

            CreateChargeResponse response = _service.CreateCharge(request).Response;

            Assert.IsTrue(!string.IsNullOrEmpty(response.Id));
        }
    }
}
