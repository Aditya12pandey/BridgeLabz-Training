using System;

class SubstringUsingCharAt
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Console.Write("Enter start index: ");
        int startIndex = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter end index: ");
        int endIndex = Convert.ToInt32(Console.ReadLine());

        string charAtSubstring = CreateSubstringUsingCharAt(input, startIndex, endIndex);
        string builtInSubstring = input.Substring(startIndex, endIndex - startIndex);

        Console.WriteLine("\nSubstring using CharAt logic: " + charAtSubstring);
        Console.WriteLine("Substring using Substring(): " + builtInSubstring);

        Console.WriteLine("\nAre both substrings equal? " +
                          charAtSubstring.Equals(builtInSubstring));
    }

    static string CreateSubstringUsingCharAt(string str, int start, int end)
    {
        string result = "";

        for (int i = start; i < end; i++)
        {
            result += str[i];   
        }

        return result;
    }
}
