using System;
using System.Text;

class StringConcatenator
{
    public string ConcatenateStrings(string[] arr)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i]);
        }

        return sb.ToString();
    }
}

class ConcatenateStrings
{
    static void Main()
    {
        Console.Write("Enter number of strings: ");
        int n = int.Parse(Console.ReadLine());

        string[] arr = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter string {i + 1}: ");
            arr[i] = Console.ReadLine();
        }

        StringConcatenator concatenator = new StringConcatenator();
        string result = concatenator.ConcatenateStrings(arr);

        Console.WriteLine("\nConcatenated String: " + result);
    }
}
