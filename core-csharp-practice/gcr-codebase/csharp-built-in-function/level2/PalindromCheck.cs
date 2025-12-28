using System;

class PalindromCheck
{
    static string GetInput()
    {
        Console.Write("Enter a string to check for palindrome: ");
        return Console.ReadLine();
    }

    static bool IsPalindrome(string str)
    {
        str = str.Replace(" ", "").ToLower();

        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    static void DisplayResult(string str, bool result)
    {
        if (result)
            Console.WriteLine($"\"{str}\" is a palindrome.");
        else
            Console.WriteLine($"\"{str}\" is not a palindrome.");
    }

    static void Main()
    {
        string input = GetInput();
        bool result = IsPalindrome(input);
        DisplayResult(input, result);
    }
}
