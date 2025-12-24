using System;

class NumberCheck
{
    static void Main()
    {
        int[] numbers = new int[5];

        Console.WriteLine("Enter 5 numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("\nNumber Analysis:");

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > 0)
            {
                if (numbers[i] % 2 == 0)
                    Console.WriteLine($"{numbers[i]} is Positive and Even");
                else
                    Console.WriteLine($"{numbers[i]} is Positive and Odd");
            }
            else if (numbers[i] < 0)
            {
                Console.WriteLine($"{numbers[i]} is Negative");
            }
            else
            {
                Console.WriteLine($"{numbers[i]} is Zero");
            }
        }

        Console.WriteLine("\nComparison of first and last elements:");

        if (numbers[0] == numbers[4])
            Console.WriteLine("First and last elements are Equal");
        else if (numbers[0] > numbers[4])
            Console.WriteLine("First element is Greater than last element");
        else
            Console.WriteLine("First element is Less than last element");
    }
}
