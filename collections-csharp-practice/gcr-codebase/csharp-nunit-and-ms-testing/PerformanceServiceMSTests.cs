using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Tests
{
    internal class PerformanceServiceMSTests
    {
        private PerformanceService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new PerformanceService();
        }

        [TestMethod]
        [Timeout(2000)] // 2 seconds
        public void LongRunningTask_ShouldFailIfTakesTooLong()
        {
            string result = _service.LongRunningTask();

            Assert.AreEqual("Completed", result);
        }
    }
}
