using System;

class MultiplicationTableRange
{
    static void Main()
    {
        int number;
        int[] multiplicationResult = new int[4]; // for 6,7,8,9

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        int index = 0;
        for (int i = 6; i <= 9; i++)
        {
            multiplicationResult[index] = number * i;
            index++;
        }

        Console.WriteLine("\nMultiplication Table (6 to 9):");
        index = 0;
        for (int i = 6; i <= 9; i++)
        {
            Console.WriteLine($"{number} * {i} = {multiplicationResult[index]}");
            index++;
        }
    }
}
