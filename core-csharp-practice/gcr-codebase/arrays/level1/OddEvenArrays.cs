using System;

class OddEvenArrays
{
    static void Main()
    {
        Console.Write("Enter a natural number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Error: Please enter a natural number greater than 0.");
            return;
        }

        int[] evenNumbers = new int[number / 2 + 1];
        int[] oddNumbers = new int[number / 2 + 1];

        int evenIndex = 0;
        int oddIndex = 0;

        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                evenNumbers[evenIndex] = i;
                evenIndex++;
            }
            else
            {
                oddNumbers[oddIndex] = i;
                oddIndex++;
            }
        }

        Console.WriteLine("\nOdd Numbers:");
        for (int i = 0; i < oddIndex; i++)
        {
            Console.Write(oddNumbers[i] + " ");
        }

        Console.WriteLine("\n\nEven Numbers:");
        for (int i = 0; i < evenIndex; i++)
        {
            Console.Write(evenNumbers[i] + " ");
        }
    }
}
