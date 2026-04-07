using System;
using System.IO;

class TextFileCopier
{
    static void Main()
    {
        string sourcePath = "source.txt";
        string destinationPath = "destination.txt";

        try
        {
            //  Check if source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist!");
                return;
            }

            //  Read source file using FileStream
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                //  Create destination file if it does not exist
                using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    int data;
                    while ((data = sourceStream.ReadByte()) != -1)
                    {
                        destinationStream.WriteByte((byte)data);
                    }
                }
            }

            Console.WriteLine("File copied successfully!");
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error Occurred: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
