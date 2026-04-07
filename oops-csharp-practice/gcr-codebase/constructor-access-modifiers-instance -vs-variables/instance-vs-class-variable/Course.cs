using System;

class Course
{
    // Instance variables
    public string courseName;
    public int duration;   // duration in months
    public double fee;

    // Class (static) variable
    public static string instituteName = "BridgeLabz";

    // Constructor
    public Course(string courseName, int duration, double fee)
    {
        this.courseName = courseName;
        this.duration = duration;
        this.fee = fee;
    }

    // Instance method
    public void DisplayCourseDetails()
    {
        Console.WriteLine("Institute Name : " + instituteName);
        Console.WriteLine("Course Name    : " + courseName);
        Console.WriteLine("Duration       : " + duration + " months");
        Console.WriteLine("Fee            : ₹" + fee);
        Console.WriteLine();
    }

    // Class (static) method
    public static void UpdateInstituteName(string newName)
    {
        instituteName = newName;
    }
}

class Program
{
    public static void Main()
    {
        Course c1 = new Course("Core C#", 3, 15000);
        Course c2 = new Course("Java Full Stack", 6, 30000);

        // Display course details
        c1.DisplayCourseDetails();
        c2.DisplayCourseDetails();

        // Update institute name
        Course.UpdateInstituteName("BridgeLabz Solutions");

        Console.WriteLine("After Updating Institute Name:\n");

        // Display again to show change reflects for all courses
        c1.DisplayCourseDetails();
        c2.DisplayCourseDetails();
    }
}
