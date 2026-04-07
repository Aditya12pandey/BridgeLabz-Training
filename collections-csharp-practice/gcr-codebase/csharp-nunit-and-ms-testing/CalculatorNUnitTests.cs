using ClassLibrary;

namespace NUnit.Tests
{
    public class Tests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ReturnsCorrectSum()
        {
            Assert.AreEqual(10, calculator.Add(6, 4));
        }

        [Test]
        public void Subtract_ReturnsCorrectDifference()
        {
            Assert.AreEqual(2, calculator.Subtract(6, 4));
        }

        [Test]
        public void Multiply_ReturnsCorrectProduct()
        {
            Assert.AreEqual(24, calculator.Multiply(6, 4));
        }

        [Test]
        public void Divide_ReturnsCorrectQuotient()
        {
            Assert.AreEqual(3, calculator.Divide(12, 4));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}