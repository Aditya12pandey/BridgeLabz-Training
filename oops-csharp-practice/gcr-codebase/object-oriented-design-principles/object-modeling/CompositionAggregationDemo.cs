using System;
using System.Collections.Generic;

class Faculty
{
    public string FacultyName;

    public Faculty(string facultyName)
    {
        FacultyName = facultyName;
    }

    public void ShowFaculty()
    {
        Console.WriteLine("Faculty Member: " + FacultyName);
    }
}

// Department class (Composition: cannot exist without University)
class Department
{
    public string DepartmentName;

    public Department(string departmentName)
    {
        DepartmentName = departmentName;
    }

    public void ShowDepartment()
    {
        Console.WriteLine("Department: " + DepartmentName);
    }
}

// University class (Owner class)
class University
{
    public string UniversityName;

    // Composition: University owns Departments
    private List<Department> departments;

    // Aggregation: University uses Faculty
    private List<Faculty> faculties;

    public University(string universityName)
    {
        UniversityName = universityName;
        departments = new List<Department>();
        faculties = new List<Faculty>();
    }

    // Composition behavior
    public void AddDepartment(string departmentName)
    {
        departments.Add(new Department(departmentName));
    }

    // Aggregation behavior
    public void AddFaculty(Faculty faculty)
    {
        faculties.Add(faculty);
    }

    public void ShowUniversityDetails()
    {
        Console.WriteLine("\nUniversity: " + UniversityName);

        Console.WriteLine("\nDepartments:");
        foreach (Department dept in departments)
        {
            dept.ShowDepartment();
        }

        Console.WriteLine("\nFaculties:");
        foreach (Faculty faculty in faculties)
        {
            faculty.ShowFaculty();
        }
    }
}

// Concept-focused main class
class CompositionAggregationDemo
{
    static void Main()
    {
        // Faculty exists independently
        Faculty f1 = new Faculty("Dr. Sharma");
        Faculty f2 = new Faculty("Prof. Mehta");

        // University created
        University university = new University("National University");

        // Composition: departments created inside university
        university.AddDepartment("Computer Science");
        university.AddDepartment("Mechanical Engineering");

        // Aggregation: faculty added to university
        university.AddFaculty(f1);
        university.AddFaculty(f2);

        // Display university structure
        university.ShowUniversityDetails();

        // University deleted (end of scope)
        university = null;

        Console.WriteLine("\nUniversity deleted.");
        Console.WriteLine("Departments are also deleted (composition).");

        Console.WriteLine("\nFaculty still exist independently:");
        f1.ShowFaculty();
        f2.ShowFaculty();
    }
}
