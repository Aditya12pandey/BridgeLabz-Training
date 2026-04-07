using System;
using System.Collections.Generic;

// Course class
class Course
{
    public string CourseName;
    public Professor AssignedProfessor;
    private List<Student> enrolledStudents;

    public Course(string courseName)
    {
        CourseName = courseName;
        enrolledStudents = new List<Student>();
    }

    // Association: Professor teaches Course
    public void AssignProfessor(Professor professor)
    {
        AssignedProfessor = professor;
        Console.WriteLine(
            "Professor " + professor.ProfessorName +
            " assigned to course " + CourseName
        );
    }

    // Association: Student enrolls in Course
    public void AddStudent(Student student)
    {
        enrolledStudents.Add(student);
    }

    public void ShowCourseDetails()
    {
        Console.WriteLine("\nCourse: " + CourseName);
        Console.WriteLine(
            "Professor: " +
            (AssignedProfessor != null ? AssignedProfessor.ProfessorName : "Not Assigned")
        );

        Console.WriteLine("Enrolled Students:");
        foreach (Student student in enrolledStudents)
        {
            Console.WriteLine("- " + student.StudentName);
        }
    }
}

// Student class
class Student
{
    public string StudentName;
    private List<Course> courses;

    public Student(string studentName)
    {
        StudentName = studentName;
        courses = new List<Course>();
    }

    // Communication method
    public void EnrollCourse(Course course)
    {
        courses.Add(course);
        course.AddStudent(this);

        Console.WriteLine(
            "Student " + StudentName +
            " enrolled in course " + course.CourseName
        );
    }

    public void ShowEnrolledCourses()
    {
        Console.WriteLine("\nCourses enrolled by " + StudentName + ":");
        foreach (Course course in courses)
        {
            Console.WriteLine("- " + course.CourseName);
        }
    }
}

// Professor class
class Professor
{
    public string ProfessorName;
    private List<Course> teachingCourses;

    public Professor(string professorName)
    {
        ProfessorName = professorName;
        teachingCourses = new List<Course>();
    }

    // Communication method
    public void TeachCourse(Course course)
    {
        teachingCourses.Add(course);
        course.AssignProfessor(this);
    }

    public void ShowTeachingCourses()
    {
        Console.WriteLine("\nCourses taught by " + ProfessorName + ":");
        foreach (Course course in teachingCourses)
        {
            Console.WriteLine("- " + course.CourseName);
        }
    }
}

// University class (Aggregation)
class University
{
    public string UniversityName;
    private List<Student> students;
    private List<Professor> professors;
    private List<Course> courses;

    public University(string universityName)
    {
        UniversityName = universityName;
        students = new List<Student>();
        professors = new List<Professor>();
        courses = new List<Course>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void AddProfessor(Professor professor)
    {
        professors.Add(professor);
    }

    public void AddCourse(Course course)
    {
        courses.Add(course);
    }

    public void ShowUniversityDetails()
    {
        Console.WriteLine("\nUniversity: " + UniversityName);

        Console.WriteLine("\nStudents:");
        foreach (Student s in students)
            Console.WriteLine("- " + s.StudentName);

        Console.WriteLine("\nProfessors:");
        foreach (Professor p in professors)
            Console.WriteLine("- " + p.ProfessorName);

        Console.WriteLine("\nCourses:");
        foreach (Course c in courses)
            Console.WriteLine("- " + c.CourseName);
    }
}

// Concept-focused main class
class UniversityAssociationAggregationDemo
{
    static void Main()
    {
        // University
        University university = new University("Global Tech University");

        // Students
        Student s1 = new Student("Rahul");
        Student s2 = new Student("Priya");

        // Professors
        Professor p1 = new Professor("Dr. Sharma");
        Professor p2 = new Professor("Dr. Mehta");

        // Courses
        Course c1 = new Course("Computer Science");
        Course c2 = new Course("Mathematics");

        // Aggregation
        university.AddStudent(s1);
        university.AddStudent(s2);
        university.AddProfessor(p1);
        university.AddProfessor(p2);
        university.AddCourse(c1);
        university.AddCourse(c2);

        // Association + Communication
        s1.EnrollCourse(c1);
        s2.EnrollCourse(c1);
        s2.EnrollCourse(c2);

        p1.TeachCourse(c1);
        p2.TeachCourse(c2);

        // Display details
        university.ShowUniversityDetails();

        s1.ShowEnrolledCourses();
        s2.ShowEnrolledCourses();

        p1.ShowTeachingCourses();
        p2.ShowTeachingCourses();

        c1.ShowCourseDetails();
        c2.ShowCourseDetails();
    }
}
