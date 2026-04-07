using System;

class ToggleCase
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (char.IsUpper(ch))
                result[i] = char.ToLower(ch);
            else if (char.IsLower(ch))
                result[i] = char.ToUpper(ch);
            else
                result[i] = ch;
        }

        Console.WriteLine("Toggled string: " + new string(result));
    }
}
