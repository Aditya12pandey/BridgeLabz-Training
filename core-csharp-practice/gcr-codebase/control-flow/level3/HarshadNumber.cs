using System;

class HarshadNumber
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        int temp = number;

        while (temp != 0)
        {
            int digit = temp % 10; 
            sum += digit;           
            temp = temp / 10;       t
        }

        if (number % sum == 0)
        {
            Console.WriteLine(number + " is a Harshad Number.");
        }
        else
        {
            Console.WriteLine(number + " is not a Harshad Number.");
        }
    }
}
