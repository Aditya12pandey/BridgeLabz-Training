using System;
using System.IO;

class WriteCsvExample
{
    static void Main()
    {
        string filePath = "employees.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write CSV header
            writer.WriteLine("ID,Name,Department,Salary");

            // Write employee records
            writer.WriteLine("1,Aditya,IT,60000");
            writer.WriteLine("2,Rahul,HR,45000");
            writer.WriteLine("3,Neha,Finance,55000");
            writer.WriteLine("4,Priya,Marketing,48000");
            writer.WriteLine("5,Amit,Operations,52000");
        }

        Console.WriteLine("CSV file created and data written successfully.");
    }
}
