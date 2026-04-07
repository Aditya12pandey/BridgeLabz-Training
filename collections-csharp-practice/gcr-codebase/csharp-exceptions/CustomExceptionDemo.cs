using System;

class InvalidAgeException : Exception
{
    public InvalidAgeException() : base("Age must be 18 or above") { }
}

class CustomExceptionDemo
{
    static void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException();
        }
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            ValidateAge(age);

            Console.WriteLine("Access granted!");
        }
        catch (InvalidAgeException)
        {
            Console.WriteLine("Age must be 18 or above");
        }
    }
}
