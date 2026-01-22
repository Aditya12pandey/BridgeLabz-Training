using System;
using System.IO;

class LargeFileErrorFinder
{
    static void Main()
    {
        string filePath = "largefile.txt"; // change file name/path

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                long lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;

                    //  Case-insensitive search
                    if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine($"Line {lineNumber}: {line}");
                    }
                }
            }

            Console.WriteLine("\n Done reading file.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
