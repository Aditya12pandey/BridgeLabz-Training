using System;

class FormatExceptionDemo
{
    static void Main()
    {
        DemonstrateFormatException();
    }

    static void DemonstrateFormatException()
    {
        string input = "abc123";   

        try
        {
            int number = int.Parse(input);

            Console.WriteLine("Number: " + number);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Exception caught: FormatException");
            Console.WriteLine("Message: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Exception handling completed.");
        }
    }
}
