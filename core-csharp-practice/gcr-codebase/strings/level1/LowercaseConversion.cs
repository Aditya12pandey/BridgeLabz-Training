using System;

class LowercaseConversion
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string asciiLower = ConvertToLowerUsingASCII(input);
        string builtInLower = input.ToLower();

        Console.WriteLine("\nLowercase using ASCII logic: " + asciiLower);
        Console.WriteLine("Lowercase using ToLower(): " + builtInLower);

        Console.WriteLine("\nAre both results equal? " +
                          asciiLower.Equals(builtInLower));
    }

    static string ConvertToLowerUsingASCII(string str)
    {
        char[] result = new char[str.Length];

        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];

            if (ch >= 'A' && ch <= 'Z')
            {
                result[i] = (char)(ch + 32);  // ASCII conversion
            }
            else
            {
                result[i] = ch;  // Keep unchanged
            }
        }

        return new string(result);
    }
}
