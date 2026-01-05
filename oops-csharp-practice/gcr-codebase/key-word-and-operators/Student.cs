using System;

class Student
{
    // static members
    public static string UniversityName = "ABC University";
    private static int totalStudents = 0;

    // readonly field
    public readonly int RollNumber;

    // instance variables
    public string Name;
    public char Grade;

    // constructor using this
    public Student(string name, int rollNumber, char grade)
    {
        this.Name = name;
        this.RollNumber = rollNumber;
        this.Grade = grade;
        totalStudents++;
    }

    // static method
    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students Enrolled: " + totalStudents);
    }

    public void DisplayStudent()
    {
        Console.WriteLine("\nUniversity : " + UniversityName);
        Console.WriteLine("Name       : " + Name);
        Console.WriteLine("Roll No    : " + RollNumber);
        Console.WriteLine("Grade      : " + Grade);
    }
}

class UniversityApp
{
    public static void Main()
    {
        Student s1 = new Student("Rahul", 101, 'A');
        Student s2 = new Student("Priya", 102, 'B');

        if (s1 is Student)
            s1.DisplayStudent();

        if (s2 is Student)
            s2.DisplayStudent();

        Student.DisplayTotalStudents();
    }
}
