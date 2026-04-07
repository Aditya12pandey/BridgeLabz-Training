using System;
using System.Text.RegularExpressions;

class SpaceNormalizer
{
    static void Main()
    {
        string input = "This   is    an example   with   multiple   spaces.";
        string pattern = @"\s+";

        string result = Regex.Replace(input, pattern, " ");

        Console.WriteLine(result);
    }
}
