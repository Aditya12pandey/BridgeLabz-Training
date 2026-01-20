using System;
using System.Collections.Generic;

//  1) Abstract Class 
// Common base for all evaluation types
abstract class CourseType
{
    public string CourseName { get; set; }
    public string Department { get; set; }

    public CourseType(string courseName, string department)
    {
        CourseName = courseName;
        Department = department;
    }

    public abstract void EvaluationMethod(); // child must define this
}

//  2) Exam Based Course 
class ExamCourse : CourseType
{
    public int TotalMarks { get; set; }

    public ExamCourse(string courseName, string department, int totalMarks)
        : base(courseName, department)
    {
        TotalMarks = totalMarks;
    }

    public override void EvaluationMethod()
    {
        Console.WriteLine($"Evaluation: Exam Based | Total Marks: {TotalMarks}");
    }
}

//  3) Assignment Based Course 
class AssignmentCourse : CourseType
{
    public int AssignmentsCount { get; set; }

    public AssignmentCourse(string courseName, string department, int assignmentsCount)
        : base(courseName, department)
    {
        AssignmentsCount = assignmentsCount;
    }

    public override void EvaluationMethod()
    {
        Console.WriteLine($"Evaluation: Assignment Based | Assignments: {AssignmentsCount}");
    }
}

//  4) Generic Class with Constraint 
class Course<T> where T : CourseType
{
    private List<T> courseList = new List<T>();

    public void AddCourse(T course)
    {
        courseList.Add(course);
        Console.WriteLine($" Added Course: {course.CourseName} ({course.Department})");
    }

    public void ShowAllCourses()
    {
        Console.WriteLine("\n All Courses List:");
        foreach (T c in courseList)
        {
            Console.WriteLine($"\nCourse Name: {c.CourseName}");
            Console.WriteLine($"Department : {c.Department}");
            c.EvaluationMethod();
        }
    }

    public List<T> GetCourses()
    {
        return courseList;
    }
}

//  5) Variance Example 
// out = covariance (child can be used as parent)
interface ICourseProvider<out T> where T : CourseType
{
    T GetCourse();
}

// Provider returning ExamCourse
class ExamCourseProvider : ICourseProvider<ExamCourse>
{
    public ExamCourse GetCourse()
    {
        return new ExamCourse("Data Structures", "CSE", 100);
    }
}

//  Main Program 
class UniversityCourseManagementSystem
{
    static void Main()
    {
        Console.WriteLine("=== Multi-Level University Course Management System ===\n");

        // 1) Manage Exam Courses
        Course<ExamCourse> examCourseManager = new Course<ExamCourse>();

        examCourseManager.AddCourse(new ExamCourse("Operating System", "CSE", 100));
        examCourseManager.AddCourse(new ExamCourse("Thermodynamics", "ME", 70));

        examCourseManager.ShowAllCourses();

        // 2) Manage Assignment Courses
        Course<AssignmentCourse> assignmentCourseManager = new Course<AssignmentCourse>();

        assignmentCourseManager.AddCourse(new AssignmentCourse("Mini Project", "CSE", 3));
        assignmentCourseManager.AddCourse(new AssignmentCourse("Circuit Design Lab", "ECE", 5));

        assignmentCourseManager.ShowAllCourses();

        // 3) Variance Example (ExamCourse -> CourseType)
        Console.WriteLine("\n=== Variance Demo ===");

        ICourseProvider<ExamCourse> provider1 = new ExamCourseProvider();

        // Because of "out T", ExamCourse provider can be treated as CourseType provider
        ICourseProvider<CourseType> provider2 = provider1;

        CourseType course = provider2.GetCourse();

        Console.WriteLine("\n✅ Course from Provider:");
        Console.WriteLine($"Course Name: {course.CourseName}");
        Console.WriteLine($"Department : {course.Department}");
        course.EvaluationMethod();

        Console.WriteLine("\n✅ Program Finished");
    }
}
