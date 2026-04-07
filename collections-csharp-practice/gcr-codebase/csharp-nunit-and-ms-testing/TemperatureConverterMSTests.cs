using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Tests
{
    internal class TemperatureConverterMSTests
    {
        private TemperatureConverter _converter;

        [TestInitialize]
        public void Setup()
        {
            _converter = new TemperatureConverter();
        }

        [DataTestMethod]
        [DataRow(0, 32)]
        [DataRow(100, 212)]
        [DataRow(-40, -40)]
        public void CelsiusToFahrenheit_ShouldReturnCorrectValue(double celsius, double expected)
        {
            double result = _converter.CelsiusToFahrenheit(celsius);

            Assert.AreEqual(expected, result, 0.01);
        }

        [DataTestMethod]
        [DataRow(32, 0)]
        [DataRow(212, 100)]
        [DataRow(-40, -40)]
        public void FahrenheitToCelsius_ShouldReturnCorrectValue(double fahrenheit, double expected)
        {
            double result = _converter.FahrenheitToCelsius(fahrenheit);

            Assert.AreEqual(expected, result, 0.01);
        }
    }
}
