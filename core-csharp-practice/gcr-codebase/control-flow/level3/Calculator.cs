using System;

class Calculator
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double first = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double second = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter an operator (+, -, *, /): ");
        string op = Console.ReadLine();

        double result;

        switch (op)
        {
            case "+":
                result = first + second;
                Console.WriteLine("Result: " + result);
                break;

            case "-":
                result = first - second;
                Console.WriteLine("Result: " + result);
                break;

            case "*":
                result = first * second;
                Console.WriteLine("Result: " + result);
                break;

            case "/":
                if (second != 0)
                {
                    result = first / second;
                    Console.WriteLine("Result: " + result);
                }
                else
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                }
                break;

            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
