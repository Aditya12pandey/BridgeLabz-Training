using System;

class ReturnCharacters
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        char[] customChars = GetCharactersWithoutToCharArray(input);
        char[] builtInChars = input.ToCharArray();

        Console.WriteLine("\nCharacters using custom method:");
        PrintCharArray(customChars);

        Console.WriteLine("\nCharacters using ToCharArray():");
        PrintCharArray(builtInChars);

        Console.WriteLine("\nAre both character arrays equal? " +
                          AreCharArraysEqual(customChars, builtInChars));
    }

    static char[] GetCharactersWithoutToCharArray(string str)
    {
        char[] chars = new char[str.Length];

        for (int i = 0; i < str.Length; i++)
        {
            chars[i] = str[i];   
        }

        return chars;
    }

    static void PrintCharArray(char[] arr)
    {
        foreach (char c in arr)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine();
    }

    static bool AreCharArraysEqual(char[] a, char[] b)
    {
        if (a.Length != b.Length)
            return false;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
                return false;
        }
        return true;
    }
}
