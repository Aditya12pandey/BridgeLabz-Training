using System;
using System.Collections.Generic;

class InvertAMap
{
    static void Main()
    {
        Dictionary<string, int> original = new Dictionary<string, int>()
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 1 }
        };

        Dictionary<int, List<string>> inverted = new Dictionary<int, List<string>>();

        foreach (var pair in original)
        {
            string key = pair.Key;
            int value = pair.Value;

            if (!inverted.ContainsKey(value))
            {
                inverted[value] = new List<string>();
            }

            inverted[value].Add(key);
        }

        Console.WriteLine("Inverted Map:");
        foreach (var item in inverted)
        {
            Console.Write(item.Key + " = [");

            for (int i = 0; i < item.Value.Count; i++)
            {
                Console.Write(item.Value[i]);
                if (i < item.Value.Count - 1)
                    Console.Write(", ");
            }

            Console.WriteLine("]");
        }
    }
}
