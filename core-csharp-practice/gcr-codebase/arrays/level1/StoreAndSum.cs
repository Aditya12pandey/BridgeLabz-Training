using System;

class StoreAndSum
{
    static void Main()
    {
        double[] numbers = new double[10];
        double total = 0.0;
        int index = 0;

        Console.WriteLine("Enter numbers (Enter 0 or negative number to stop):");

        while (true)
        {
            Console.Write("Enter a number: ");
            double input = Convert.ToDouble(Console.ReadLine());

            if (input <= 0)
            {
                break;
            }

            if (index == 10)
            {
                Console.WriteLine("Maximum limit of 10 numbers reached.");
                break;
            }

            numbers[index] = input;
            index++;
        }

        Console.WriteLine("\nStored Numbers:");
        for (int i = 0; i < index; i++)
        {
            Console.WriteLine(numbers[i]);
            total += numbers[i];
        }

        Console.WriteLine($"\nTotal Sum = {total}");
    }
}
