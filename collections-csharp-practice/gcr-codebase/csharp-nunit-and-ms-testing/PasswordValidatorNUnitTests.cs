using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    internal class PasswordValidatorNUnitTests
    {
        private PasswordValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PasswordValidator();
        }

        [TestCase("Password1", true)]    // valid
        [TestCase("Abcdefg1", true)]     // valid
        [TestCase("password1", false)]  // no uppercase
        [TestCase("Password", false)]   // no digit
        [TestCase("Pass1", false)]      // too short
        [TestCase("", false)]            // empty
        public void IsValid_ShouldReturnExpectedResult(string password, bool expected)
        {
            bool result = _validator.IsValid(password);

            Assert.AreEqual(expected, result);
        }
    }
}
