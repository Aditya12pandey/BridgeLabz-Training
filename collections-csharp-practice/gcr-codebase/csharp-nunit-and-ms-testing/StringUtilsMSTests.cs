using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace MS.Tests
{
    [TestClass]
    public class StringUtilsMSTests
    {
        private StringUtils stringUtils;

        [TestInitialize]
        public void Setup()
        {
            stringUtils = new StringUtils();
        }

        [TestMethod]
        public void Reverse_ReturnsReversedString()
        {
            Assert.AreEqual("olleH", stringUtils.Reverse("Hello"));
        }

        
    }
}
