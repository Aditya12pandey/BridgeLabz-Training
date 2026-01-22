using System;
using System.Diagnostics;
using System.IO;

class LargeFileCopyComparer
{
    static void Main()
    {
        string sourcePath = "bigfile.dat";  // Example: 100MB file
        string destUnbuffered = "copy_unbuffered.dat";
        string destBuffered = "copy_buffered.dat";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist!");
            return;
        }

        Console.WriteLine("Copying file: " + sourcePath);

        //  Unbuffered Copy
        long unbufferedTime = CopyUsingUnbufferedStream(sourcePath, destUnbuffered);

        //  Buffered Copy
        long bufferedTime = CopyUsingBufferedStream(sourcePath, destBuffered);

        Console.WriteLine("\n Performance Result:");
        Console.WriteLine("Unbuffered Time : " + unbufferedTime + " ms");
        Console.WriteLine("Buffered Time   : " + bufferedTime + " ms");

        if (bufferedTime < unbufferedTime)
            Console.WriteLine(" BufferedStream is Faster!");
        else
            Console.WriteLine(" Unbuffered FileStream is Faster (rare case).");
    }

    static long CopyUsingUnbufferedStream(string source, string destination)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        try
        {
            using (FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destination, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096]; //  4KB chunk
                int bytesRead;

                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Unbuffered Copy Error: " + ex.Message);
        }

        sw.Stop();
        Console.WriteLine("Unbuffered copy completed in: " + sw.ElapsedMilliseconds + " ms");
        return sw.ElapsedMilliseconds;
    }

    static long CopyUsingBufferedStream(string source, string destination)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        try
        {
            using (FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destination, FileMode.Create, FileAccess.Write))
            using (BufferedStream bufferedInput = new BufferedStream(sourceStream))
            using (BufferedStream bufferedOutput = new BufferedStream(destinationStream))
            {
                byte[] buffer = new byte[4096]; //  4KB chunk
                int bytesRead;

                while ((bytesRead = bufferedInput.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bufferedOutput.Write(buffer, 0, bytesRead);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Buffered Copy Error: " + ex.Message);
        }

        sw.Stop();
        Console.WriteLine("Buffered copy completed in: " + sw.ElapsedMilliseconds + " ms");
        return sw.ElapsedMilliseconds;
    }
}
