using System;

class VotingEligibility
{
    static void Main()
    {
        int age;

        Console.Write("Enter the age: ");
        age = int.Parse(Console.ReadLine());

        if (age >= 18)
        {
            Console.WriteLine("The person's age is " + age + " and can vote.");
        }
        else
        {
            Console.WriteLine("The person's age is " + age + " and cannot vote.");
        }
    }
}
