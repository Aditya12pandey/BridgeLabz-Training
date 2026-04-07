namespace ClassLibrary
{
    [TestClass]
    public sealed class CalculatorMSTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Add_ReturnsCorrectSum()
        {
            Assert.AreEqual(10, calculator.Add(6, 4));
        }

        [TestMethod]
        public void Subtract_ReturnsCorrectDifference()
        {
            Assert.AreEqual(2, calculator.Subtract(6, 4));
        }

        [TestMethod]
        public void Multiply_ReturnsCorrectProduct()
        {
            Assert.AreEqual(24, calculator.Multiply(6, 4));
        }

        [TestMethod]
        public void Divide_ReturnsCorrectQuotient()
        {
            Assert.AreEqual(3, calculator.Divide(12, 4));
        }

        
    }
}
