using System;

class VowelConsonantCount
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine().ToLower();

        int vowels = 0, consonants = 0;

        foreach (char ch in input)
        {
            if (char.IsLetter(ch))
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || 
                    ch == 'o' || ch == 'u')
                {
                    vowels++;
                }
                else
                {
                    consonants++;
                }
            }
        }

        Console.WriteLine("Vowels count: " + vowels);
        Console.WriteLine("Consonants count: " + consonants);
    }
}
