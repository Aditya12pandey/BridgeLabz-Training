using System;
using System.Text.RegularExpressions;

class LinkExtractor
{
    static void Main()
    {
        string text = "Visit https://www.google.com and http://example.org for more info.";
        string pattern = @"https?:\/\/[^\s""]+";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
