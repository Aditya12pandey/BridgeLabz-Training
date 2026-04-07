using System;

class ExceptionPropagationDemo
{
    static void Method1()
    {
        int x = 10 / 0; // Throws ArithmeticException (DivideByZeroException)
    }

    static void Method2()
    {
        Method1(); // Calling Method1()
    }

    static void Main()
    {
        try
        {
            Method2(); // Calling Method2()
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Handled exception in Main");
        }
    }
}
