using System;

class NullReferenceDemo
{
    static void Main()
    {
        DemonstrateNullReferenceException();
    }

    static void DemonstrateNullReferenceException()
    {
        string message = null;

        try
        {
            int length = message.Length;

            Console.WriteLine("Length: " + length);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Exception caught: NullReferenceException");
            Console.WriteLine("Message: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Program execution completed.");
        }
    }
}
