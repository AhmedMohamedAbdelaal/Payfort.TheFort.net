using Start.Net.RequestModels;
using Start.Net.Constants;
using Start.Net.ResponseModels;
using Start.Net.Entities;
using NUnit.Framework;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Start.Net.Tests
{
    [TestClass]
    [TestFixture]
    public class ChargeServiceTests
    {
        private StartChargeService _service;
        private CardDetails workingCard; 

        public ChargeServiceTests()
        {
            _service = new StartChargeService("test_sec_k_63b07e79c620fcfee5a24");
            workingCard = new CardDetails()
            {
                Name = "Abdullah Ahmed",
                Cvc = 123,
                ExpireMonth = 12,
                ExpireYear = 2020,
                Number = "4242424242424242"
            };
        }

        [Test]
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

            NUnit.Framework.Assert.IsFalse(response.IsError);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(response.IsError);
        }

        [Test]
        [TestMethod]
        public void CreateCharge_UsingCardDetails_Success()
        {
            CreateChargeRequest request = new CreateChargeRequest()
            {
                Amount = 50000,
                Currency = Currency.USD,
                Email = "john.doe@gmail.com"
            };

            request.CardDetails = workingCard;

            CreateChargeResponse response = _service.CreateCharge(request).Response;

            NUnit.Framework.Assert.IsTrue(!string.IsNullOrEmpty(response.Id));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(!string.IsNullOrEmpty(response.Id));
        }

        [Test]
        [TestMethod]
        public void CreateCharge_UsingCardDetails_Fails()
        {
            CreateChargeRequest request = new CreateChargeRequest()
            {
                Amount = 50000,
                Currency = Currency.USD,
                Email = "john.doe@gmail.com"
            };

            request.CardDetails = workingCard;
            request.CardDetails.ExpireYear = 2013;

            CreateChargeResponse response = _service.CreateCharge(request).Response;

            NUnit.Framework.Assert.IsTrue(response.IsError);
            NUnit.Framework.Assert.IsTrue(string.IsNullOrEmpty(response.Id));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(response.IsError);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(string.IsNullOrEmpty(response.Id));
        }
    }
}
