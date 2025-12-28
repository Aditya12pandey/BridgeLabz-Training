using System;

class MaximumOfThree
{
    static void Main()
    {
        Console.WriteLine("Find the Maximum of Three Numbers");

        int num1 = GetInput("Enter the first number: ");
        int num2 = GetInput("Enter the second number: ");
        int num3 = GetInput("Enter the third number: ");

        int max = FindMaximum(num1, num2, num3);

        Console.WriteLine("The maximum number is: " + max);
    }

    static int GetInput(string message)
    {
        Console.Write(message);
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid input! Please enter an integer: ");
        }
        return value;
    }

    static int FindMaximum(int a, int b, int c)
    {
        int max = a;

        if (b > max)
            max = b;
        if (c > max)
            max = c;

        return max;
    }
}
