using System;

class FactorialUsingRecursion
{
    public static int GetInput()
    {
        int number;
        Console.Write("Enter a non-negative integer: ");
        while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.Write("Invalid input! Please enter a non-negative integer: ");
        }
        return number;
    }

    public static long Factorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        return n * Factorial(n - 1);
    }

    public static void DisplayResult(int number, long factorial)
    {
        Console.WriteLine($"Factorial of {number} is: {factorial}");
    }

    static void Main()
    {
        int number = GetInput();           // Input
        long result = Factorial(number);   // Calculation
        DisplayResult(number, result);     // Output
    }
}
