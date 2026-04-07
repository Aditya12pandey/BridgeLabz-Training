using System;
using System.Text.RegularExpressions;

class ProgrammingLanguageExtractor
{
    static void Main()
    {
        string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";
        string pattern = @"\b(Java|Python|JavaScript|Go)\b";

        MatchCollection matches = Regex.Matches(
            text,
            pattern,
            RegexOptions.IgnoreCase
        );

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
