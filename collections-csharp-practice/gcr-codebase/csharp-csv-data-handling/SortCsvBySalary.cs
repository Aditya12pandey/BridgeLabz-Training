using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class SortCsvBySalary
{
    static void Main()
    {
        string filePath = "employees.csv";

        // Read all lines and skip header
        List<string[]> records = File.ReadAllLines(filePath)
                                      .Skip(1)
                                      .Select(line => line.Split(','))
                                      .ToList();

        // Sort by Salary (descending)
        var sortedRecords = records
            .OrderByDescending(r => double.Parse(r[3]))
            .Take(5);

        Console.WriteLine("Top 5 Highest-Paid Employees:");
        Console.WriteLine("ID\tName\tDepartment\tSalary");

        foreach (var r in sortedRecords)
        {
            Console.WriteLine($"{r[0]}\t{r[1]}\t{r[2]}\t{r[3]}");
        }
    }
}
