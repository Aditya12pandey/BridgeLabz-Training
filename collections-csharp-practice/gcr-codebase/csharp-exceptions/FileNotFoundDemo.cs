using System;
using System.IO;

class FileNotFoundDemo
{
    static void Main()
    {
        string filePath = "data.txt";

        try
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine("File Content:");
            Console.WriteLine(content);
        }
        catch (IOException)
        {
            Console.WriteLine("File not found");
        }
    }
}
