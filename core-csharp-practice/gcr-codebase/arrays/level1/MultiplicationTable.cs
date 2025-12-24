using System;

class MultiplicationTable
{
    static void Main()
    {
        int number;
        int[] table = new int[10];

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            table[i - 1] = number * i;
        }

        Console.WriteLine("\nMultiplication Table:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{number} * {i} = {table[i - 1]}");
        }
    }
}
