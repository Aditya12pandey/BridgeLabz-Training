using System;

class ChocolateDistribution
{
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int quotient = number / divisor;
        int remainder = number % divisor;

        return new int[] { quotient, remainder };
    }

    static void Main()
    {
        Console.Write("Enter number of chocolates: ");
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of children: ");
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(numberOfChocolates, numberOfChildren);

        Console.WriteLine("Each child will get {0} chocolates.", result[0]);
        Console.WriteLine("Remaining chocolates are {0}.", result[1]);
    }
}
