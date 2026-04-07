using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class LargeFileReadComparison
{
    static void ReadUsingStreamReader(string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            while (reader.ReadLine() != null)
            {
                // Just reading line by line
            }
        }
    }

    static void ReadUsingFileStream(string path)
    {
        byte[] buffer = new byte[1024 * 1024]; // 1MB buffer

        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            int bytesRead;
            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Raw byte reading (no conversion needed for speed test)
            }
        }
    }

    static void Main()
    {
        Console.Write("Enter file path to read (example: D:\\bigfile.txt): ");
        string path = Console.ReadLine();

        if (!File.Exists(path))
        {
            Console.WriteLine(" File not found!");
            return;
        }

        Stopwatch sw = new Stopwatch();

        // StreamReader Timing
        sw.Start();
        ReadUsingStreamReader(path);
        sw.Stop();
        Console.WriteLine($"\n StreamReader Time: {sw.ElapsedMilliseconds} ms");

        sw.Reset();

        // FileStream Timing
        sw.Start();
        ReadUsingFileStream(path);
        sw.Stop();
        Console.WriteLine($" FileStream Time  : {sw.ElapsedMilliseconds} ms");

        Console.WriteLine("\n File reading comparison completed.");
    }
}
