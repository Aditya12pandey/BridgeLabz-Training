using System;
using System.IO;

class StudentBinaryFileApp
{
    static string filePath = "students.dat";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n Student Binary File Menu ");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;

                case "2":
                    DisplayStudents();
                    break;

                case "3":
                    Console.WriteLine(" Exiting...");
                    return;

                default:
                    Console.WriteLine(" Invalid choice!");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        try
        {
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            //  BinaryWriter writes primitive data into binary file
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(roll);
                writer.Write(name);
                writer.Write(gpa);
            }

            Console.WriteLine(" Student saved successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine(" Invalid input! Please enter correct values.");
        }
        catch (IOException ex)
        {
            Console.WriteLine(" File Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Error: " + ex.Message);
        }
    }

    static void DisplayStudents()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine(" No binary file found! Add students first.");
                return;
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                Console.WriteLine("\n Student List ");

                while (fs.Position < fs.Length)
                {
                    int roll = reader.ReadInt32();
                    string name = reader.ReadString();
                    double gpa = reader.ReadDouble();

                    Console.WriteLine("Roll Number : " + roll);
                    Console.WriteLine("Name        : " + name);
                    Console.WriteLine("GPA         : " + gpa);
                }
            }
        }
        catch (EndOfStreamException)
        {
            Console.WriteLine(" Reached end of file.");
        }
        catch (IOException ex)
        {
            Console.WriteLine(" File Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Error: " + ex.Message);
        }
    }
}
