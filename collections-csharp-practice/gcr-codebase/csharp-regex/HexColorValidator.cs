using System;
using System.Text.RegularExpressions;

class HexColorValidator
{
    static void Main()
    {
        string[] colors = { "#FFA500", "#ff4500", "#123", "#ZZZZZZ" };
        string pattern = @"^#[0-9A-Fa-f]{6}$";

        foreach (string color in colors)
        {
            if (Regex.IsMatch(color, pattern))
                Console.WriteLine($"{color} → Valid");
            else
                Console.WriteLine($"{color} → Invalid");
        }
    }
}
