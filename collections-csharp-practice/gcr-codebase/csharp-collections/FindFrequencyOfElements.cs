using System;
using System.Collections.Generic;

class FindFrequencyOfElements
{
    static void Main()
    {
        List<string> fruits = new List<string>() { "apple", "banana", "apple", "orange" };

        Dictionary<string, int> freq = new Dictionary<string, int>();

        // Counting frequency
        foreach (string item in fruits)
        {
            if (freq.ContainsKey(item))
                freq[item]++;   // if already exists, increase count
            else
                freq[item] = 1; // first time seen
        }

        // Printing result
        Console.WriteLine("Frequency of Elements:");
        foreach (var pair in freq)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}
