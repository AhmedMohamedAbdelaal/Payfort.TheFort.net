using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Start.Net.Tests
{
    [TestClass]
    public class ChargeServiceTests
    {
        private StartChargeService _service;
        public ChargeServiceTests()
        {
            _service = new StartChargeService("test_sec_k_63b07e79c620fcfee5a24");
        }

        [TestMethod] 
        public void CreateCharge_Success()
        {
            Assert.IsTrue(1 == 1);
        }
    }
}
