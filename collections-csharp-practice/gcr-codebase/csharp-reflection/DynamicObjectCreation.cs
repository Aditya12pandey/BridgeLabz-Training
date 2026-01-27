using System;
using System.Reflection;

class Student
{
    public int Id;
    public string Name;

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }
}

class DynamicObjectCreation
{
    static void Main()
    {
        // Get Type information
        Type type = typeof(Student);

        // Create object dynamically (no 'new' keyword)
        object obj = Activator.CreateInstance(type, 101, "Aditya");

        // Cast object to Student
        Student student = (Student)obj;

        // Call method
        student.Display();
    }
}
