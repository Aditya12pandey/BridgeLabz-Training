using System;

class ArrayIndexOutOfRangeDemo
{
    static void Main()
    {
        DemonstrateArrayIndexOutOfRangeException();
    }

    static void DemonstrateArrayIndexOutOfRangeException()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        try
        {
            int value = numbers[10];

            Console.WriteLine("Value: " + value);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Exception caught: IndexOutOfRangeException");
            Console.WriteLine("Message: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Exception handling completed.");
        }
    }
}
