using System;
using System.IO;

class ReadCsvCountRows
{
    static void Main()
    {
        string filePath = "employees.csv";
        int recordCount = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            // Read and ignore header
            reader.ReadLine();

            // Read remaining lines
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                recordCount++;
            }
        }

        Console.WriteLine("Number of records (excluding header): " + recordCount);
    }
}
