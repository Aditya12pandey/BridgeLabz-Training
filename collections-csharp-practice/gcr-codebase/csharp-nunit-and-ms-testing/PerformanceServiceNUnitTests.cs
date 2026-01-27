using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    internal class PerformanceServiceNUnitTests
    {
        private PerformanceService _service;

        [SetUp]
        public void Setup()
        {
            _service = new PerformanceService();
        }

        [Test]
        [Timeout(2000)] // 2 seconds
        public void LongRunningTask_ShouldFailIfTakesTooLong()
        {
            string result = _service.LongRunningTask();

            Assert.AreEqual("Completed", result);
        }
    }
}
