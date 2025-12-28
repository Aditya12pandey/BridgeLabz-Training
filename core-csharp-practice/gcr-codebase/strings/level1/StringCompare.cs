using System;

class StringCompare
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        bool charAtResult = CompareUsingCharAt(str1, str2);
        bool equalsResult = str1.Equals(str2);

        Console.WriteLine("\nComparison using CharAt logic: " + charAtResult);
        Console.WriteLine("Comparison using string.Equals(): " + equalsResult);
    }

    static bool CompareUsingCharAt(string s1, string s2)
    {
        if (s1.Length != s2.Length)
        {
            return false;
        }

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                return false;
            }
        }

        return true;
    }
}
