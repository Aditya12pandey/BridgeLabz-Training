
using NUnit.Framework;
using ClassLibrary;

namespace NUnit.Tests
{
    public class StringUtilsNUnitTests
    {
        private StringUtils stringUtils;

        [SetUp]
        public void Setup()
        {
            stringUtils = new StringUtils();
        }

        [Test]
        public void Reverse_ReturnsReversedString()
        {
            Assert.AreEqual("olleH", stringUtils.Reverse("Hello"));
        }

        [Test]
        public void IsPalindrome_ReturnsTrue_ForPalindrome()
        {
            Assert.IsTrue(stringUtils.IsPalindrome("Madam"));
        }

        [Test]
        public void ToUpperCase_ReturnsUpperCase()
        {
            Assert.AreEqual("HELLO", stringUtils.ToUpperCase("hello"));
        }

        [Test]
        public void Reverse_Null_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => stringUtils.Reverse(null));
        }
    }
}
