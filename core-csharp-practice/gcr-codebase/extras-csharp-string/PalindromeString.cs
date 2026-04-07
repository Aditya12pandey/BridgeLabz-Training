using System;

class PalindromeString
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine().ToLower();

        bool isPalindrome = true;
        int start = 0;
        int end = input.Length - 1;

        while (start < end)
        {
            if (input[start] != input[end])
            {
                isPalindrome = false;
                break;
            }
            start++;
            end--;
        }

        if (isPalindrome)
            Console.WriteLine("The string is a Palindrome.");
        else
            Console.WriteLine("The string is NOT a Palindrome.");
    }
}
