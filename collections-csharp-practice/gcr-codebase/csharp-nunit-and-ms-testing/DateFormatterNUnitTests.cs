using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    internal class DateFormatterNUnitTests
    {
        private DateFormatter _formatter;

        [SetUp]
        public void Setup()
        {
            _formatter = new DateFormatter();
        }

        [TestCase("2024-01-15", "15-01-2024")]
        [TestCase("1999-12-31", "31-12-1999")]
        public void FormatDate_ValidDate_ShouldReturnFormattedDate(
            string input, string expected)
        {
            string result = _formatter.FormatDate(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase("15-01-2024")]
        [TestCase("2024/01/15")]
        [TestCase("invalid-date")]
        [TestCase("")]
        public void FormatDate_InvalidDate_ShouldThrowFormatException(string input)
        {
            Assert.Throws<FormatException>(() =>
            {
                _formatter.FormatDate(input);
            });
        }
    }
}
