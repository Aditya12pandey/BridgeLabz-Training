using System;

class GCDAndLCMCalculator
{
    public static void GetInput(out int num1, out int num2)
    {
        Console.Write("Enter the first number: ");
        while (!int.TryParse(Console.ReadLine(), out num1) || num1 <= 0)
        {
            Console.Write("Invalid input! Please enter a positive integer: ");
        }

        Console.Write("Enter the second number: ");
        while (!int.TryParse(Console.ReadLine(), out num2) || num2 <= 0)
        {
            Console.Write("Invalid input! Please enter a positive integer: ");
        }
    }

    public static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static int CalculateLCM(int a, int b, int gcd)
    {
        return (a * b) / gcd;
    }

    public static void DisplayResult(int num1, int num2, int gcd, int lcm)
    {
        Console.WriteLine($"GCD of {num1} and {num2} is: {gcd}");
        Console.WriteLine($"LCM of {num1} and {num2} is: {lcm}");
    }

    static void Main()
    {
        GetInput(out int number1, out int number2);          // Input
        int gcd = CalculateGCD(number1, number2);           // GCD calculation
        int lcm = CalculateLCM(number1, number2, gcd);      // LCM calculation
        DisplayResult(number1, number2, gcd, lcm);          // Output
    }
}
