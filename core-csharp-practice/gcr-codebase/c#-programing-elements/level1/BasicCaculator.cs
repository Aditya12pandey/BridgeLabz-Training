using System;

public class BasicCalculator
{
    public static void Main(string[] args)
    {
        double number1, number2;

        // Take user input
        Console.Write("Enter first number: ");
        number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        number2 = Convert.ToDouble(Console.ReadLine());

        // Perform calculations
        double addition = number1 + number2;
        double subtraction = number1 - number2;
        double multiplication = number1 * number2;
        double division = number1 / number2;

        Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers " +number1 + " and " + number2 + " is " +addition + ", " + subtraction + ", " +multiplication + ", and " + division);
    }
}
