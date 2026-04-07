using System;

class MostFrequentCharacter
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        int[] freq = new int[256];   

        foreach (char ch in input)
        {
            freq[ch]++;
        }

        char mostFrequent = '\0';
        int maxCount = 0;

        foreach (char ch in input)
        {
            if (freq[ch] > maxCount)
            {
                maxCount = freq[ch];
                mostFrequent = ch;
            }
        }

        Console.WriteLine($"Most Frequent Character: '{mostFrequent}'");
    }
}
