using System;

class SubstringOccurrence
{
    static void Main()
    {
        Console.Write("Enter the main string: ");
        string text = Console.ReadLine();

        Console.Write("Enter the substring: ");
        string sub = Console.ReadLine();

        int count = 0;

        for (int i = 0; i <= text.Length - sub.Length; i++)
        {
            bool match = true;

            for (int j = 0; j < sub.Length; j++)
            {
                if (text[i + j] != sub[j])
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                count++;
            }
        }

        Console.WriteLine("Substring occurrences: " + count);
    }
}
