
using System;
using System.Diagnostics;
using System.Reflection;

// Class whose methods will be timed
class Workload
{
    public void FastMethod()
    {
        for (int i = 0; i < 1_000_000; i++) { }
    }

    public void SlowMethod()
    {
        System.Threading.Thread.Sleep(400);
    }
}

// Utility to measure execution time
class MethodExecutionTimer
{
    public static void Measure(object obj)
    {
        Type type = obj.GetType();

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Console.WriteLine("Method Execution Time:\n");

        foreach (MethodInfo method in methods)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Invoke method dynamically
            method.Invoke(obj, null);

            stopwatch.Stop();

            Console.WriteLine($"{method.Name} executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}

// Test class
class MethodExecutionTiming
{
    static void Main()
    {
        Workload workload = new Workload();

        MethodExecutionTimer.Measure(workload);
    }
}
