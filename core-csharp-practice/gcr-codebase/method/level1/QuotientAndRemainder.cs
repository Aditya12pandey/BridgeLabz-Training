using System;

class QuotientAndRemainder
{
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int quotient = number / divisor;
        int remainder = number % divisor;

        return new int[] { quotient, remainder };
    }

    static void Main()
    {
        Console.Write("Enter the number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the divisor: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(number, divisor);

        Console.WriteLine("Quotient is: " + result[0]);
        Console.WriteLine("Remainder is: " + result[1]);
    }
}
