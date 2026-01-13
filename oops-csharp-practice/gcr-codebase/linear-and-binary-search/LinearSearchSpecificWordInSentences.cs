using System;

class SentenceWordSearcher
{
    public int FindFirstSentenceContainingWord(string[] sentences, string word)
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].ToLower().Contains(word.ToLower()))
                return i; // index of first matching sentence
        }
        return -1; // not found
    }
}

class LinearSearchSpecificWordInSentences
{
    static void Main()
    {
        Console.Write("Enter number of sentences: ");
        int n = int.Parse(Console.ReadLine());

        string[] sentences = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter sentence {i + 1}: ");
            sentences[i] = Console.ReadLine();
        }

        Console.Write("\nEnter word to search: ");
        string word = Console.ReadLine();

        SentenceWordSearcher searcher = new SentenceWordSearcher();
        int index = searcher.FindFirstSentenceContainingWord(sentences, word);

        if (index == -1)
            Console.WriteLine("\n No sentence contains the given word.");
        else
            Console.WriteLine($"\n First sentence containing '{word}' is at index {index}:\n{sentences[index]}");
    }
}
