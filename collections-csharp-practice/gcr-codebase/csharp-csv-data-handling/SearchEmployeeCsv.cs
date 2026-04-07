using System;
using System.IO;

class SearchEmployeeCsv
{
    static void Main()
    {
        string filePath = "employees.csv";

        Console.Write("Enter employee name to search: ");
        string searchName = Console.ReadLine();

        bool found = false;

        using (StreamReader reader = new StreamReader(filePath))
        {
            // Skip header
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                string name = data[1];

                if (name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Employee Found");
                    Console.WriteLine("Department: " + data[2]);
                    Console.WriteLine("Salary: " + data[3]);
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Employee not found.");
        }
    }
}
