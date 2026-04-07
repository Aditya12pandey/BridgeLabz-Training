using System;
using System.Diagnostics;
using System.Reflection;

// 1️Define the attribute
[AttributeUsage(AttributeTargets.Method)]
class LogExecutionTimeAttribute : Attribute
{
}

// 2️Apply the attribute to methods
class PerformanceTasks
{
    [LogExecutionTime]
    public void FastTask()
    {
        for (int i = 0; i < 1_000_000; i++) { }
    }

    [LogExecutionTime]
    public void SlowTask()
    {
        System.Threading.Thread.Sleep(500);
    }
}

// 3️Measure execution time using Reflection + Stopwatch
class LogExecutionTime
{
    static void Main()
    {
        PerformanceTasks tasks = new PerformanceTasks();
        Type type = typeof(PerformanceTasks);

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Console.WriteLine("Method Execution Time:\n");

        foreach (MethodInfo method in methods)
        {
            if (method.GetCustomAttribute<LogExecutionTimeAttribute>() != null)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                method.Invoke(tasks, null);   // Execute method

                stopwatch.Stop();

                Console.WriteLine($"{method.Name} executed in {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}
