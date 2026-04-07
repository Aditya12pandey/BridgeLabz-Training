using System;

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        char[] chars = input.ToCharArray();
        int start = 0;
        int end = chars.Length - 1;

        while (start < end)
        {
            char temp = chars[start];
            chars[start] = chars[end];
            chars[end] = temp;

            start++;
            end--;
        }

        string reversed = new string(chars);
        Console.WriteLine("Reversed string: " + reversed);
    }
}
