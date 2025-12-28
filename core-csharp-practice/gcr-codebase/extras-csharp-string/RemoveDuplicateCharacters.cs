using System;

class RemoveDuplicateCharacters
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string result = "";

        foreach (char ch in input)
        {
            if (!result.Contains(ch))
            {
                result += ch;
            }
        }

        Console.WriteLine("String after removing duplicates: " + result);
    }
}
