using System;

class RemoveSpecificCharacter
{
    static void Main()
    {
        Console.Write("Enter the string: ");
        string input = Console.ReadLine();

        Console.Write("Enter the character to remove: ");
        char removeChar = Console.ReadLine()[0];

        string result = "";

        foreach (char ch in input)
        {
            if (ch != removeChar)
            {
                result += ch;
            }
        }

        Console.WriteLine("Modified String: " + result);
    }
}
