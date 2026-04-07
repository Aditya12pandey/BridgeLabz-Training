using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordFrequencyCounter
{
    static void Main()
    {
        string filePath = "input.txt";  // Change file name/path

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            int totalWords = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    //  Split line into words (removes spaces + punctuation)
                    string[] words = line
                        .ToLower()
                        .Split(new char[] { ' ', '\t', ',', '.', '!', '?', ';', ':', '-', '(', ')', '"', '\'' },
                               StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        totalWords++;

                        if (wordCount.ContainsKey(word))
                            wordCount[word]++;
                        else
                            wordCount[word] = 1;
                    }
                }
            }

            Console.WriteLine(" Total Words: " + totalWords);

            //  Sort dictionary by frequency (descending) and take top 5
            var top5 = wordCount
                .OrderByDescending(x => x.Value)
                .Take(5);

            Console.WriteLine("\n Top 5 Most Frequent Words:");
            foreach (var item in top5)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
