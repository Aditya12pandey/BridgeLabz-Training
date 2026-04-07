using System;
using System.IO;

class UpdateCsvSalary
{
    static void Main()
    {
        string inputFile = "employees.csv";
        string outputFile = "employees_updated.csv";

        using (StreamReader reader = new StreamReader(inputFile))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            // Read and write header
            string header = reader.ReadLine();
            writer.WriteLine(header);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                string department = data[2];
                double salary = double.Parse(data[3]);

                // Increase salary by 10% for IT department
                if (department.Equals("IT", StringComparison.OrdinalIgnoreCase))
                {
                    salary = salary * 1.10;
                }

                // Write updated record
                writer.WriteLine($"{data[0]},{data[1]},{department},{salary}");
            }
        }

        Console.WriteLine("Salary updated successfully. New file created: employees_updated.csv");
    }
}
