using System;

class WordLengthDemo
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string input = Console.ReadLine();

        string[,] result = SplitWordsAndLengths(input);

        Console.WriteLine("\nWord\tLength");
        Console.WriteLine("----------------");
        for (int i = 0; i < result.GetLength(0); i++)
        {
            Console.WriteLine(result[i, 0] + "\t" + result[i, 1]);
        }
    }

    static string[,] SplitWordsAndLengths(string text)
    {
        string[] words = ExtractWords(text);
        string[,] output = new string[words.Length, 2];

        for (int i = 0; i < words.Length; i++)
        {
            output[i, 0] = words[i];
            output[i, 1] = GetLengthWithoutLength(words[i]).ToString();
        }

        return output;
    }

    static string[] ExtractWords(string text)
    {
        string temp = "";
        int count = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != ' ')
            {
                temp += text[i];
            }
            else if (temp != "")
            {
                count++;
                temp = "";
            }
        }
        if (temp != "") count++;

        string[] words = new string[count];
        temp = "";
        int index = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != ' ')
            {
                temp += text[i];
            }
            else if (temp != "")
            {
                words[index++] = temp;
                temp = "";
            }
        }
        if (temp != "")
        {
            words[index] = temp;
        }

        return words;
    }

    static int GetLengthWithoutLength(string str)
    {
        int length = 0;

        try
        {
            while (true)
            {
                char c = str[length];
                length++;
            }
        }
        catch (IndexOutOfRangeException)
        {
            // Stop when index is out of range
        }

        return length;
    }
}
