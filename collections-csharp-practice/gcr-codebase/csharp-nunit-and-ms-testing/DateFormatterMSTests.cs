using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Tests
{
    internal class DateFormatterMSTests
    {
        private DateFormatter _formatter;

        [TestInitialize]
        public void Setup()
        {
            _formatter = new DateFormatter();
        }

        [DataTestMethod]
        [DataRow("2024-01-15", "15-01-2024")]
        [DataRow("1999-12-31", "31-12-1999")]
        public void FormatDate_ValidDate_ShouldReturnFormattedDate(
            string input, string expected)
        {
            string result = _formatter.FormatDate(input);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("15-01-2024")]
        [DataRow("2024/01/15")]
        [DataRow("invalid-date")]
        [DataRow("")]
        public void FormatDate_InvalidDate_ShouldThrowFormatException(string input)
        {
            Assert.Throws<FormatException>(() =>
            {
                _formatter.FormatDate(input);
            });
        }
    }
}
