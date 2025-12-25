using System;

class HandshakeProgram2
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

        Console.WriteLine(
            "The maximum number of possible handshakes among {0} students is {1}",
            numberOfStudents, handshakes
        );
    }
}
