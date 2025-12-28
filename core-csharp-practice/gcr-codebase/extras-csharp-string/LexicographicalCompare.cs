using System;

class LexicographicalCompare
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string s1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string s2 = Console.ReadLine();

        int minLength = s1.Length < s2.Length ? s1.Length : s2.Length;
        bool areEqual = true;

        for (int i = 0; i < minLength; i++)
        {
            if (s1[i] < s2[i])
            {
                Console.WriteLine($"\"{s1}\" comes before \"{s2}\" in lexicographical order");
                return;
            }
            else if (s1[i] > s2[i])
            {
                Console.WriteLine($"\"{s1}\" comes after \"{s2}\" in lexicographical order");
                return;
            }
        }

        if (s1.Length < s2.Length)
            Console.WriteLine($"\"{s1}\" comes before \"{s2}\" in lexicographical order");
        else if (s1.Length > s2.Length)
            Console.WriteLine($"\"{s1}\" comes after \"{s2}\" in lexicographical order");
        else
            Console.WriteLine("Both strings are equal");
    }
}
