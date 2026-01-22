using System;
using System.IO;

class ImageByteArrayConverter
{
    static void Main()
    {
        string originalImagePath = "original.jpg";   // Put your image name here
        string newImagePath = "copied.jpg";

        try
        {
            //  Check if original image exists
            if (!File.Exists(originalImagePath))
            {
                Console.WriteLine("Original image file not found!");
                return;
            }

            // Read image file into byte array
            byte[] imageBytes = File.ReadAllBytes(originalImagePath);

            // Write byte array into another image file using MemoryStream
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                File.WriteAllBytes(newImagePath, ms.ToArray());
            }

            Console.WriteLine(" Image converted to byte array and saved successfully!");
            Console.WriteLine("New Image File: " + newImagePath);

            //  Verify both images are identical
            bool isSame = AreFilesIdentical(originalImagePath, newImagePath);

            if (isSame)
                Console.WriteLine(" Verification Passed: Files are IDENTICAL!");
            else
                Console.WriteLine(" Verification Failed: Files are NOT identical!");
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

    static bool AreFilesIdentical(string file1, string file2)
    {
        byte[] bytes1 = File.ReadAllBytes(file1);
        byte[] bytes2 = File.ReadAllBytes(file2);

        if (bytes1.Length != bytes2.Length)
            return false;

        for (int i = 0; i < bytes1.Length; i++)
        {
            if (bytes1[i] != bytes2[i])
                return false;
        }

        return true;
    }
}
