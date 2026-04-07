using System;
using System.Text.RegularExpressions;

class DateExtractor
{
    static void Main()
    {
        string text = "The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020.";
        string pattern = @"\b\d{2}/\d{2}/\d{4}\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
