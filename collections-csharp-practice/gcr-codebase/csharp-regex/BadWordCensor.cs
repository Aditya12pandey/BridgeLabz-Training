using System;
using System.Text.RegularExpressions;

class BadWordCensor
{
    static void Main()
    {
        string input = "This is a damn bad example with some stupid words.";
        string pattern = @"\b(damn|stupid)\b";

        string result = Regex.Replace(
            input,
            pattern,
            "****",
            RegexOptions.IgnoreCase
        );

        Console.WriteLine(result);
    }
}
