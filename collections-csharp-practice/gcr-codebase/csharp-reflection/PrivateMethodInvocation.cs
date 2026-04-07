using System;
using System.Reflection;

class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}

class PrivateMethodInvocation
{
    static void Main()
    {
        // Create object of Calculator
        Calculator calculator = new Calculator();

        // Get type information
        Type type = typeof(Calculator);

        // Access private method Multiply
        MethodInfo method = type.GetMethod(
            "Multiply",
            BindingFlags.NonPublic | BindingFlags.Instance);

        // Invoke the private method
        object result = method.Invoke(calculator, new object[] { 5, 4 });

        Console.WriteLine("Result of multiplication: " + result);
    }
}
