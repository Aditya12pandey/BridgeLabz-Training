using System;
using System.Collections.Generic;

// Course class (Associated with Student)
class Course
{
    public string CourseName;
    private List<Student> enrolledStudents;

    public Course(string courseName)
    {
        CourseName = courseName;
        enrolledStudents = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        enrolledStudents.Add(student);
    }

    public void ShowEnrolledStudents()
    {
        Console.WriteLine("\nStudents enrolled in " + CourseName + ":");
        foreach (Student student in enrolledStudents)
        {
            Console.WriteLine("- " + student.StudentName);
        }
    }
}

// Student class (Associated with Course)
class Student
{
    public string StudentName;
    private List<Course> enrolledCourses;

    public Student(string studentName)
    {
        StudentName = studentName;
        enrolledCourses = new List<Course>();
    }

    // Association (many-to-many)
    public void EnrollCourse(Course course)
    {
        enrolledCourses.Add(course);
        course.AddStudent(this);
    }

    public void ViewCourses()
    {
        Console.WriteLine("\nCourses enrolled by " + StudentName + ":");
        foreach (Course course in enrolledCourses)
        {
            Console.WriteLine("- " + course.CourseName);
        }
    }
}

// School class (Aggregates Students)
class School
{
    public string SchoolName;
    private List<Student> students;

    public School(string schoolName)
    {
        SchoolName = schoolName;
        students = new List<Student>();
    }

    // Aggregation
    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void ShowStudents()
    {
        Console.WriteLine("\nStudents in " + SchoolName + ":");
        foreach (Student student in students)
        {
            Console.WriteLine("- " + student.StudentName);
        }
    }
}

// Concept-focused main class
class AssociationAggregationDemo
{
    static void Main()
    {
        // School (Aggregation)
        School school = new School("Green Valley School");

        // Students (independent objects)
        Student s1 = new Student("Rahul");
        Student s2 = new Student("Priya");

        // Courses (independent objects)
        Course c1 = new Course("Mathematics");
        Course c2 = new Course("Computer Science");

        // Aggregation: school has students
        school.AddStudent(s1);
        school.AddStudent(s2);

        // Association: students enroll in courses (many-to-many)
        s1.EnrollCourse(c1);
        s1.EnrollCourse(c2);

        s2.EnrollCourse(c2);

        // Display outputs
        school.ShowStudents();
        s1.ViewCourses();
        s2.ViewCourses();
        c1.ShowEnrolledStudents();
        c2.ShowEnrolledStudents();
    }
}
