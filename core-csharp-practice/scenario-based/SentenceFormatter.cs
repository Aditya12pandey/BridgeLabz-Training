using System;
//This program formats a given paragraph by correcting spacing and capitalization without using any built-in string functions.
// It removes extra spaces, ensures only one space between words.
// Capitalizes the first letter of each sentence using ASCII character logic.
// The program also guarantees that exactly one space appears after sentence-ending punctuation marks such as period (.), question mark (?), and exclamation mark (!).
// It demonstrates the use of strings, loops, switch–case statements, conditional logic, and methods in C#.
class SentenceFormatter
{ 
    public static void Main()
    {
        SentenceFormatter fs = new SentenceFormatter();
        Console.WriteLine("Enter a paragraph");
        string input = Console.ReadLine();
        string formatted = fs.FormattedString(input);
        Console.WriteLine("\n formatted paragraph :");
        Console.WriteLine(formatted);
    }

    private string FormattedString(string paragraph)
    {
        string result = "";

        bool capitalizeNext = true;
        bool lastWasSpace = true; // removes leading & extra spaces
        for (int i = 0; i < paragraph.Length; i++)
        {
            char ch = paragraph[i];
            if (ch == ' ')
            {
                if (!lastWasSpace)
                {
                    result += ' ';
                    lastWasSpace = true;
                }
                continue;
            }
            lastWasSpace = false;
            // Capitalize first letter of sentence (ASCII logic)
            if (capitalizeNext && ch >= 'a' && ch <= 'z')
            {
                ch = (char)(ch - 32);
                capitalizeNext = false;
            }

            result += ch;
            switch (ch)
            {
                case '.':
                case '?':
                case '!':
                    capitalizeNext = true;

                    // Ensure exactly one space after punctuation
                    if (i + 1 < paragraph.Length && paragraph[i + 1] != ' ')
                    {
                        result += ' ';
                        lastWasSpace = true;
                    }
                    break;
            }

        }
        if (result.Length > 0 && result[result.Length - 1] == ' ')
        {
            string temp = "";
            for (int i = 0; i < result.Length - 1; i++)
            {
                temp += result[i];
            }
            result = temp;
        }

        return result;


    }
}