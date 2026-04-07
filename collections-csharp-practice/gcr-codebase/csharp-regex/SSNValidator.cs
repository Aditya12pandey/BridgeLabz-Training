using System;
using System.Text.RegularExpressions;

class SSNValidator
{
    static void Main()
    {
        string[] inputs =
        {
            "My SSN is 123-45-6789.",
            "Invalid SSN: 123456789"
        };

        string pattern = @"\b\d{3}-\d{2}-\d{4}\b";

        foreach (string text in inputs)
        {
            Match match = Regex.Match(text, pattern);

            if (match.Success)
                Console.WriteLine($" \"{match.Value}\" is valid");
            else
                Console.WriteLine(" Invalid SSN format");
        }
    }
}
