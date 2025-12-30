//This program analyzes paragraph of text without using any built-in string functions.
// It counts the total number of words.
// It identifies the longest word in the paragraph.
// replace occurrence of a specified word with another word in a case-insensitive manner using ASCII comparison
// Also program handles edge cases such as empty input and only spaces. 
using System;
class ParagraphAnalyzer
{
    static bool IsSameWord(string w1, string w2)
    {
        if (w1.Length != w2.Length)
            return false;

        for (int i = 0; i < w1.Length; i++)
        {
            char c1 = w1[i];
            char c2 = w2[i];

            // Convert both to lowercase using ASCII
            if (c1 >= 'A' && c1 <= 'Z') c1 = (char)(c1 + 32);
            if (c2 >= 'A' && c2 <= 'Z') c2 = (char)(c2 + 32);

            if (c1 != c2)
                return false;
        }
        return true;
    }

    static void AnalyzeParagraph(string paragraph, string oldWord, string newWord)
    {
        if (paragraph.Length == 0)
        {
            Console.WriteLine("Empty paragraph.");
            return;
        }

        int wordCount = 0;
        string longestWord = "";
        string currentWord = "";
        string result = "";

        bool hasLetter = false;

        for (int i = 0; i <= paragraph.Length; i++)
        {
            char ch = (i < paragraph.Length) ? paragraph[i] : ' ';

            if (ch != ' ')
            {
                currentWord += ch;
                hasLetter = true;
            }
            else
            {
                if (currentWord.Length > 0)
                {
                    wordCount++;

                    // Longest word check
                    if (currentWord.Length > longestWord.Length)
                        longestWord = currentWord;

                    // Replace word (case-insensitive)
                    if (IsSameWord(currentWord, oldWord))
                        result += newWord;
                    else
                        result += currentWord;

                    result += ' ';
                    currentWord = "";
                }
            }
        }

        if (!hasLetter)
        {
            Console.WriteLine("Paragraph contains only spaces.");
            return;
        }

        // Remove last space manually
        string finalResult = "";
        for (int i = 0; i < result.Length - 1; i++)
            finalResult += result[i];

        Console.WriteLine("\nWord Count: " + wordCount);
        Console.WriteLine("Longest Word: " + longestWord);
        Console.WriteLine("Modified Paragraph:");
        Console.WriteLine(finalResult);
    }

    static void Main()
    {
        Console.WriteLine("Enter paragraph:");
        string paragraph = Console.ReadLine();

        Console.WriteLine("Enter word to replace:");
        string oldWord = Console.ReadLine();

        Console.WriteLine("Enter new word:");
        string newWord = Console.ReadLine();

        AnalyzeParagraph(paragraph, oldWord, newWord);
    }
}
