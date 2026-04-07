using System;

class ArgumentOutOfRangeDemo
{
    static void Main()
    {
        DemonstrateArgumentOutOfRangeException();
    }

    static void DemonstrateArgumentOutOfRangeException()
    {
        string text = "HelloWorld";

        try
        {
            int startIndex = 8;
            int endIndex = 3;

            // This will throw ArgumentOutOfRangeException
            string result = text.Substring(startIndex, endIndex - startIndex);

            Console.WriteLine("Substring: " + result);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Exception caught: ArgumentOutOfRangeException");
            Console.WriteLine("Message: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Exception handling completed.");
        }
    }
}
