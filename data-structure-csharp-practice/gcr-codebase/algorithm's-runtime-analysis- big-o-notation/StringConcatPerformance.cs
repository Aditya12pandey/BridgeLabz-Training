using System;
using System.Diagnostics;
using System.Text;

class StringConcatPerformance
{
    static void Main()
    {
        Console.Write("Enter number of concatenations (e.g. 1000, 10000, 1000000): ");
        int n = int.Parse(Console.ReadLine());

        Stopwatch sw = new Stopwatch();

        //  Using string 
        // NOTE: For very large n, this becomes extremely slow
        if (n > 200000)
        {
            Console.WriteLine("\n Skipping string concatenation because it's too slow for large N.");
        }
        else
        {
            sw.Start();
            string result1 = "";
            for (int i = 0; i < n; i++)
            {
                result1 += "A";   // creates new object each time
            }
            sw.Stop();
            Console.WriteLine($"\n string concat time: {sw.ElapsedMilliseconds} ms");
            sw.Reset();
        }

        //  Using StringBuilder 
        sw.Start();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append("A");
        }
        string result2 = sb.ToString();
        sw.Stop();
        Console.WriteLine($" StringBuilder time : {sw.ElapsedMilliseconds} ms");

        Console.WriteLine("\n Performance comparison completed.");
    }
}
