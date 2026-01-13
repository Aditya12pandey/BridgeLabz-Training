using System;
using System.Text;

class DuplicateRemover
{
    public string RemoveDuplicates(string input)
    {
        StringBuilder result = new StringBuilder();
        bool[] seen = new bool[256]; // ASCII characters

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (!seen[ch])
            {
                seen[ch] = true;
                result.Append(ch);
            }
        }

        return result.ToString();
    }
}

class RemoveDuplicates
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        DuplicateRemover remover = new DuplicateRemover();
        string output = remover.RemoveDuplicates(input);

        Console.WriteLine("String after removing duplicates: " + output);
    }
}
