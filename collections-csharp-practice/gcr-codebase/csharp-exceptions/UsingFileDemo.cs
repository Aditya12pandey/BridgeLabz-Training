using System;
using System.IO;

class UsingFileDemo
{
    static void Main()
    {
        string filePath = "info.txt";

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();
                Console.WriteLine("First Line: " + firstLine);
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file");
        }
    }
}
