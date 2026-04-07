using System;
using System.IO;
using System.Text;

class UpperToLowerFileConverter
{
    static void Main()
    {
        string sourcePath = "input.txt";
        string destinationPath = "output.txt";

        try
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found!");
                return;
            }

            //  Open FileStreams
            using (FileStream sourceFileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream destinationFileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))

            //  BufferedStream for efficiency
            using (BufferedStream bufferedInput = new BufferedStream(sourceFileStream))
            using (BufferedStream bufferedOutput = new BufferedStream(destinationFileStream))

            //  StreamReader + StreamWriter with Encoding
            using (StreamReader reader = new StreamReader(bufferedInput, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(bufferedOutput, Encoding.UTF8))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line.ToLower());
                }
            }

            Console.WriteLine(" Conversion completed successfully!");
            Console.WriteLine("Output File Created: " + destinationPath);
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
