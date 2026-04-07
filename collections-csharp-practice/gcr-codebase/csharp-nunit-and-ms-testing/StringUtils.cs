

namespace ClassLibrary
{

    public class StringUtils
    {
        public string Reverse(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public bool IsPalindrome(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            string reversed = Reverse(str);
            return str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        public string ToUpperCase(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            return str.ToUpper();
        }
    }
}
