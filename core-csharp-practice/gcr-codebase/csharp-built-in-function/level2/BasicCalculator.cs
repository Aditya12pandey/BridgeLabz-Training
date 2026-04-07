using System;

class BasicCalculator
{
    public static double GetNumber(string prompt)
    {
        double number;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input! Please enter a number: ");
        }
        return number;
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Cannot divide by zero!");
            return double.NaN; // Return Not-a-Number
        }
        return a / b;
    }

    public static void DisplayResult(double result)
    {
        Console.WriteLine($"Result: {result}");
    }

    static void Main()
    {
        Console.WriteLine("Basic Calculator");
        Console.WriteLine("Select operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        int choice;
        Console.Write("Enter choice (1-4): ");
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.Write("Invalid choice! Enter a number between 1 and 4: ");
        }

        double num1 = GetNumber("Enter first number: ");
        double num2 = GetNumber("Enter second number: ");
        double result = 0;

        switch (choice)
        {
            case 1:
                result = Add(num1, num2);
                break;
            case 2:
                result = Subtract(num1, num2);
                break;
            case 3:
                result = Multiply(num1, num2);
                break;
            case 4:
                result = Divide(num1, num2);
                break;
        }

        DisplayResult(result);
    }
}
