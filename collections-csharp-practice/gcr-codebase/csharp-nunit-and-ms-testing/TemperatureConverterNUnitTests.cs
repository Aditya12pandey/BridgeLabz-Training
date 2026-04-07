using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    internal class TemperatureConverterNUnitTests
    {
        private TemperatureConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new TemperatureConverter();
        }

        [TestCase(0, 32)]
        [TestCase(100, 212)]
        [TestCase(-40, -40)]
        public void CelsiusToFahrenheit_ShouldReturnCorrectValue(double celsius, double expected)
        {
            double result = _converter.CelsiusToFahrenheit(celsius);

            Assert.AreEqual(expected, result, 0.01);
        }

        [TestCase(32, 0)]
        [TestCase(212, 100)]
        [TestCase(-40, -40)]
        public void FahrenheitToCelsius_ShouldReturnCorrectValue(double fahrenheit, double expected)
        {
            double result = _converter.FahrenheitToCelsius(fahrenheit);

            Assert.AreEqual(expected, result, 0.01);
        }
    }
}
