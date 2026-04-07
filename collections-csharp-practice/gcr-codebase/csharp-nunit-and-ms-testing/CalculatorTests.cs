using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    internal class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Divide_ByZero_ShouldThrowArithmeticException()
        {
            Assert.Throws<ArithmeticException>(() => _calculator.Divide(10, 0));
        }
    }
}
