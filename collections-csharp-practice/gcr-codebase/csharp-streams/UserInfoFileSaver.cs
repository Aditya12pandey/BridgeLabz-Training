using System;
using System.IO;

class UserInfoFileSaver
{
    static void Main()
    {
        string filePath = "UserInfo.txt";

        try
        {
            //  StreamReader for Console Input
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            Console.Write("Enter your Name: ");
            string name = reader.ReadLine();

            Console.Write("Enter your Age: ");
            string age = reader.ReadLine();

            Console.Write("Enter your Favorite Programming Language: ");
            string language = reader.ReadLine();

            //  StreamWriter to write data into file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(" User Information ");
                writer.WriteLine("Name     : " + name);
                writer.WriteLine("Age      : " + age);
                writer.WriteLine("Language : " + language);
                writer.WriteLine();
            }

            Console.WriteLine("\n Data saved successfully into: " + filePath);
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
