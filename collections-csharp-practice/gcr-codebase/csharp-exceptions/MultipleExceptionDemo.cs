using System;

class MultipleExceptionDemo
{
    static void Main()
    {
        try
        {
            // Example array (you can set it to null to test NullReferenceException)
            int[] arr = { 10, 20, 30, 40, 50 };

            Console.Write("Enter index number: ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Value at index " + index + ": " + arr[index]);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Array is not initialized!");
        }
    }
}
