using System;
using System.Text.RegularExpressions;

class CreditCardValidator
{
    static void Main()
    {
        string[] cards =
        {
            "4123456789012345", // Visa
            "5123456789012345", // MasterCard
            "6123456789012345", // Invalid
            "412345678901234",  // Too short
            "51234abcd9012345"  // Invalid characters
        };

        string pattern = @"^(4\d{15}|5\d{15})$";

        foreach (string card in cards)
        {
            if (Regex.IsMatch(card, pattern))
                Console.WriteLine($"{card} → Valid");
            else
                Console.WriteLine($"{card} → Invalid");
        }
    }
}
