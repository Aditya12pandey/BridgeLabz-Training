using System;
using System.Reflection;

class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }
}

class DynamicMethodInvocation
{
    static void Main()
    {
        MathOperations math = new MathOperations();
        Type type = typeof(MathOperations);

        Console.Write("Enter method name (Add / Subtract / Multiply): ");
        string methodName = Console.ReadLine();

        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        // Get method dynamically
        MethodInfo method = type.GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine("Invalid method name.");
            return;
        }

        // Invoke method dynamically
        object result = method.Invoke(math, new object[] { a, b });

        Console.WriteLine($"Result: {result}");
    }
}
