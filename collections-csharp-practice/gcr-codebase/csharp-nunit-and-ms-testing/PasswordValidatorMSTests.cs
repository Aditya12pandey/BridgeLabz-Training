using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Tests
{
    internal class PasswordValidatorMSTests
    {
        private PasswordValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new PasswordValidator();
        }

        [DataTestMethod]
        [DataRow("Password1", true)]
        [DataRow("Abcdefg1", true)]
        [DataRow("password1", false)]
        [DataRow("Password", false)]
        [DataRow("Pass1", false)]
        [DataRow("", false)]
        public void IsValid_ShouldReturnExpectedResult(string password, bool expected)
        {
            bool result = _validator.IsValid(password);

            Assert.AreEqual(expected, result);
        }
    }
}
