using System;

class Handshakes
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

        Console.WriteLine("The maximum number of handshakes is " + handshakes);
    }
}
