using System;
using System.IO;

class ReadStudentCSV
{
    static void Main()
    {
        Console.WriteLine(" Student CSV Reader \n");

        Console.Write("Enter the CSV file name (with path if needed): ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("\n File not found. Please check the file name and path.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            Console.WriteLine("\n Student Records:\n");

            // Skip header row
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                Console.WriteLine($"Student ID   : {data[0]}");
                Console.WriteLine($"Name         : {data[1]}");
                Console.WriteLine($"Age          : {data[2]}");
                Console.WriteLine($"Marks        : {data[3]}");
                Console.WriteLine(new string('-', 30));
            }

            Console.WriteLine("\n Data displayed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n Error while reading file: " + ex.Message);
        }
    }
}
