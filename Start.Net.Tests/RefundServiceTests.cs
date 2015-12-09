using Start.Net.Constants;
using Start.Net.ResponseModels;
using Start.Net.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Start.Net.Interfaces;
using Start.Net.RequestModels.Charges;
using Start.Net.RequestModels.Refunds;

namespace Start.Net.Tests
{
    [TestClass]
    public class RefundServiceTests
    {
        private IStartRefundService _refundService;
        private IStartChargeService _chargeService;

        private CreateChargeRequest _createChargeRequest;
        private Card _workingCard; 

        public RefundServiceTests()
        {
            _refundService = new StartRefundService("test_sec_k_63b07e79c620fcfee5a24");
            _chargeService = new StartChargeService("test_sec_k_63b07e79c620fcfee5a24");

            _workingCard = new Card()
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
        public void RefundCharge_Success()
        {
            _createChargeRequest.CardDetails = _workingCard;
            _createChargeRequest.Capture = true;

            ApiResponse<Charge> response = _chargeService.CreateCharge(_createChargeRequest);

            Assert.IsTrue(!string.IsNullOrEmpty(response.Content.Id));
            Assert.IsTrue(response.Content.State == ChargeState.Captured);

            RefundChargeRequest refundRequest = new RefundChargeRequest();
            refundRequest.ChargeId = response.Content.Id;
            refundRequest.Amount = response.Content.CapturedAmount;
            refundRequest.Reason = RefundReason.RequestedByCustomer;

            ApiResponse<Refund> refundResponse = _refundService.RefundCharge(refundRequest);

            Charge charge = _chargeService.GetCharge(new GetChargeRequest() { ChargeId = response.Content.Id }).Content;
            Assert.IsTrue(!string.IsNullOrEmpty(refundResponse.Content.Id));
            Assert.IsTrue(charge.State == ChargeState.Refunded);
        }

        [TestMethod]
        public void RefundCharge_Partially_Success()
        {
            _createChargeRequest.CardDetails = _workingCard;
            _createChargeRequest.Capture = true;

            ApiResponse<Charge> response = _chargeService.CreateCharge(_createChargeRequest);

            Assert.IsTrue(!string.IsNullOrEmpty(response.Content.Id));
            Assert.IsTrue(response.Content.State == ChargeState.Captured);

            RefundChargeRequest refundRequest = new RefundChargeRequest();
            refundRequest.ChargeId = response.Content.Id;
            refundRequest.Amount = response.Content.CapturedAmount - 200;
            refundRequest.Reason = RefundReason.RequestedByCustomer;

            ApiResponse<Refund> refundResponse = _refundService.RefundCharge(refundRequest);

            Charge charge = _chargeService.GetCharge(new GetChargeRequest() { ChargeId = response.Content.Id }).Content;
            Assert.IsTrue(!string.IsNullOrEmpty(refundResponse.Content.Id));
            Assert.IsTrue(charge.State == ChargeState.PartiallyRefunded);
        }

        [TestMethod]
        public void ListRefundsOfCharge_Success()
        {
            _createChargeRequest.CardDetails = _workingCard;
            _createChargeRequest.Capture = true;
            _createChargeRequest.Amount = 10000;

            ApiResponse<Charge> response = _chargeService.CreateCharge(_createChargeRequest);

            RefundChargeRequest refundRequest = new RefundChargeRequest();
            refundRequest.ChargeId = response.Content.Id;
            refundRequest.Amount = 100;

            ApiResponse<Refund> refundResponse = _refundService.RefundCharge(refundRequest);
            _refundService.RefundCharge(refundRequest);
            _refundService.RefundCharge(refundRequest);

            PagedApiResponse<Refund> apiResponse = _refundService.ListRefundsForCharge(new ListRefundsForChargeRequest() { ChargeId = refundRequest.ChargeId });

            Assert.IsTrue(apiResponse.Content.Count == 3);
        }
    }
}
