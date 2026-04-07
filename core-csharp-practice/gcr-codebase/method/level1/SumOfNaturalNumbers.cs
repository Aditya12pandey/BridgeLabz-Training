using System;

class SumOfNaturalNumbers
{
    static int CalculateSum(int n)
    {
        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        return sum;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int result = CalculateSum(n);

        Console.WriteLine("The sum of first {0} natural numbers is {1}", n, result);
    }
}
