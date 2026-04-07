using System;
using System.Reflection;

// 1️Define the Todo attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class TodoAttribute : Attribute
{
    public string Task { get; }
    public string AssignedTo { get; }
    public string Priority { get; }

    public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

// 2️Apply the attribute to multiple methods
class ProjectModule
{
    [Todo("Implement login feature", "Aditya", "HIGH")]
    [Todo("Add input validation", "Aditya")]
    public void UserAuthentication()
    {
        Console.WriteLine("User authentication module");
    }

    [Todo("Optimize database queries", "Rahul", "LOW")]
    public void DataProcessing()
    {
        Console.WriteLine("Data processing module");
    }
}

// 3️Retrieve and print all pending tasks
class TodoAttribute
{
    static void Main()
    {
        Type type = typeof(ProjectModule);
        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Console.WriteLine("Pending Tasks:\n");

        foreach (MethodInfo method in methods)
        {
            TodoAttribute[] todos =
                (TodoAttribute[])Attribute.GetCustomAttributes(
                    method, typeof(TodoAttribute));

            foreach (TodoAttribute todo in todos)
            {
                Console.WriteLine($"Method     : {method.Name}");
                Console.WriteLine($"Task       : {todo.Task}");
                Console.WriteLine($"AssignedTo : {todo.AssignedTo}");
                Console.WriteLine($"Priority   : {todo.Priority}");
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
