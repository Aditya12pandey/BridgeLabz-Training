using System;
using System.Text.RegularExpressions;

class LicensePlateValidator
{
    static void Main()
    {
        string[] plates = { "AB1234", "A12345", "ab1234", "XY9999" };
        string pattern = @"^[A-Z]{2}[0-9]{4}$";

        foreach (string plate in plates)
        {
            if (Regex.IsMatch(plate, pattern))
                Console.WriteLine($"{plate} → Valid");
            else
                Console.WriteLine($"{plate} → Invalid");
        }
    }
}
