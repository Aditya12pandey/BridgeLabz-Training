using System;

class CountDigits
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int count = 0;
        int temp = number; 

        while (temp != 0)
        {
            temp = temp / 10; 
            count++;           
        }

        Console.WriteLine("Number of digits in " + number + " is: " + count);
    }
}
