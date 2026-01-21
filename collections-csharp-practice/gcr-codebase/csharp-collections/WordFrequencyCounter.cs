using System;
using System.Collections.Generic;
using System.IO;

class WordFrequencyCounter
{
    static void Main()
    {
        Console.Write("Enter file path: ");
        string path = Console.ReadLine();

        if (!File.Exists(path))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string text = File.ReadAllText(path);

        // Convert to lowercase
        text = text.ToLower();

        // Split words (removing common symbols)
        char[] separators = { ' ', '\n', '\r', '\t', ',', '.', '!', '?', ';', ':', '"', '(', ')', '[', ']', '{', '}' };

        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> freq = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (freq.ContainsKey(word))
                freq[word]++;
            else
                freq[word] = 1;
        }

        Console.WriteLine("\nWord Frequencies:");
        foreach (var item in freq)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}
