using System;

class UppercaseConversion
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string asciiUpper = ConvertToUpperUsingASCII(input);
        string builtInUpper = input.ToUpper();

        Console.WriteLine("\nUppercase using ASCII logic: " + asciiUpper);
        Console.WriteLine("Uppercase using ToUpper(): " + builtInUpper);

        Console.WriteLine("\nAre both results equal? " +
                          asciiUpper.Equals(builtInUpper));
    }

    static string ConvertToUpperUsingASCII(string str)
    {
        char[] result = new char[str.Length];

        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];

            if (ch >= 'a' && ch <= 'z')
            {
                result[i] = (char)(ch - 32);  // ASCII conversion
            }
            else
            {
                result[i] = ch;  // Keep unchanged
            }
        }

        return new string(result);
    }
}
