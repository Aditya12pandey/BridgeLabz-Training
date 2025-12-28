using System;

class CustomReplace
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        Console.Write("Enter word to replace: ");
        string oldWord = Console.ReadLine();

        Console.Write("Enter new word: ");
        string newWord = Console.ReadLine();

        string result = ReplaceWord(sentence, oldWord, newWord);

        Console.WriteLine("Modified sentence:");
        Console.WriteLine(result);
    }

    static string ReplaceWord(string sentence, string oldWord, string newWord)
    {
        string[] words = sentence.Split(' ');
        string result = "";

        foreach (string word in words)
        {
            if (word == oldWord)
                result += newWord + " ";
            else
                result += word + " ";
        }

        return result.Trim();
    }
}
