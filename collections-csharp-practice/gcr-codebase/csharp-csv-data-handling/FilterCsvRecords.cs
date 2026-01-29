using System;
using System.IO;

class FilterCsvRecords
{
    static void Main()
    {
        string filePath = "students.csv";

        using (StreamReader reader = new StreamReader(filePath))
        {
            // Read and skip header
            string header = reader.ReadLine();

            Console.WriteLine("Students scoring more than 80 marks:");
            Console.WriteLine(header);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                int marks = int.Parse(data[2]);

                if (marks > 80)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
