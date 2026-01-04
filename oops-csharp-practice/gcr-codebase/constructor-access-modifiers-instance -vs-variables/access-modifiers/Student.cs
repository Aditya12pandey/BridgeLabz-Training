using System;

class Student
{
    // Access Modifiers
    public int rollNumber;      // Public
    protected string name;      // Protected
    private double CGPA;        // Private

    // Constructor
    public Student(int rollNumber, string name, double cgpa)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.CGPA = cgpa;
    }

    public double GetCGPA()
    {
        return CGPA;
    }

    public void SetCGPA(double cgpa)
    {
        if (cgpa >= 0 && cgpa <= 10)
        {
            CGPA = cgpa;
        }
        else
        {
            Console.WriteLine("Invalid CGPA value");
        }
    }

    public void DisplayStudent()
    {
        Console.WriteLine("Roll Number : " + rollNumber);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("CGPA        : " + CGPA);
    }
}

class PostgraduateStudent : Student
{
    public string specialization;

    public PostgraduateStudent(int rollNumber, string name, double cgpa, string specialization)
        : base(rollNumber, name, cgpa)
    {
        this.specialization = specialization;
    }

    public void DisplayPGStudent()
    {
        Console.WriteLine("Postgraduate Student Details:");
        Console.WriteLine("Name           : " + name); // protected member
        Console.WriteLine("Specialization : " + specialization);
        Console.WriteLine("CGPA           : " + GetCGPA());
    }
}

class Program
{
    public static void Main()
    {
        Student s1 = new Student(101, "Aditya", 8.2);
        s1.DisplayStudent();

        Console.WriteLine();

        // Modify CGPA using public method
        s1.SetCGPA(8.8);
        Console.WriteLine("Updated CGPA: " + s1.GetCGPA());

        Console.WriteLine();

        PostgraduateStudent pg = new PostgraduateStudent(201, "Rahul", 9.1, "Computer Science");
        pg.DisplayPGStudent();
    }
}
