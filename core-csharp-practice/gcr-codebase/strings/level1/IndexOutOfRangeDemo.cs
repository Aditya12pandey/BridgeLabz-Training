using System;

class IndexOutOfRangeDemo
{
    static void Main()
    {
        GenerateIndexOutOfRangeException();
        HandleIndexOutOfRangeException();
    }

    // Method to generate the exception
    static void GenerateIndexOutOfRangeException()
    {
        string text = "Hello";

        // This will throw IndexOutOfRangeException
        char ch = text[10];

        Console.WriteLine(ch);
    }

    // Method to handle the exception using try-catch
    static void HandleIndexOutOfRangeException()
    {
        string text = "Hello";

        try
        {
            char ch = text[10];   // Invalid index
            Console.WriteLine("Character: " + ch);
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
