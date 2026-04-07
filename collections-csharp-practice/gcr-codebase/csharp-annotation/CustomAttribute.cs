using System;
using System.Reflection;

// 1️Define a custom attribute
[AttributeUsage(AttributeTargets.Method)]
class TaskInfoAttribute : Attribute
{
    public string Priority { get; }
    public string AssignedTo { get; }

    public TaskInfoAttribute(string priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

// 2️Apply the attribute to a method
class TaskManager
{
    [TaskInfo("High", "Aditya")]
    public void CompleteTask()
    {
        Console.WriteLine("Task completed successfully.");
    }
}

// 3️etrieve attribute data using Reflection
class CustomAttribute
{
    static void Main()
    {
        Type type = typeof(TaskManager);
        MethodInfo method = type.GetMethod("CompleteTask");

        TaskInfoAttribute taskInfo =
            (TaskInfoAttribute)Attribute.GetCustomAttribute(
                method, typeof(TaskInfoAttribute));

        Console.WriteLine("Task Information:");
        Console.WriteLine($"Priority    : {taskInfo.Priority}");
        Console.WriteLine($"Assigned To : {taskInfo.AssignedTo}");
    }
}
