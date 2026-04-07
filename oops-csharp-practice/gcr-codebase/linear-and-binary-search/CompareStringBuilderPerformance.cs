using System;
using System.Diagnostics;
using System.Text;

class StringBuilderPerformanceComparer
{
    public void ComparePerformance(int repetitions)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        string normalResult = "";
        for (int i = 0; i < repetitions; i++)
        {
            normalResult += "Hello";
        }
        sw.Stop();
        long normalTime = sw.ElapsedMilliseconds;

        sw.Reset();
        sw.Start();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < repetitions; i++)
        {
            sb.Append("Hello");
        }
        string sbResult = sb.ToString();
        sw.Stop();
        long sbTime = sw.ElapsedMilliseconds;

        Console.WriteLine("\n Performance Comparison:");
        Console.WriteLine($"Using Normal String (+)   : {normalTime} ms");
        Console.WriteLine($"Using StringBuilder       : {sbTime} ms");
    }
}

class CompareStringBuilderPerformance
{
    static void Main()
    {
        Console.Write("Enter number of repetitions: ");
        int repetitions = int.Parse(Console.ReadLine());

        StringBuilderPerformanceComparer comparer = new StringBuilderPerformanceComparer();
        comparer.ComparePerformance(repetitions);
    }
}
