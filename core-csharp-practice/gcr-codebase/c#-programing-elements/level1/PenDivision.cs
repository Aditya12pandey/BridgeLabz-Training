using System;

class PenDivision
{
    public static void Main(string[] args)
    {
        int totalPens = 14;
        int students = 3;

        int pensPerStudent = totalPens / students;
        int remainingPens = totalPens % students;

        Console.WriteLine("The Pen Per Student is " + pensPerStudent +" and the remaining pen not distributed is " + remainingPens);
    }
}
