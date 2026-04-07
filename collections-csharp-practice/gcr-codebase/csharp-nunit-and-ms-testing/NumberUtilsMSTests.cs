using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Tests
{
    internal class NumberUtilsMSTests
    {
        private NumberUtils _numberUtils;

        [TestInitialize]
        public void Setup()
        {
            _numberUtils = new NumberUtils();
        }

        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_ShouldReturnExpectedResult(int number, bool expected)
        {
            bool result = _numberUtils.IsEven(number);

            Assert.AreEqual(expected, result);
        }
    }
}
