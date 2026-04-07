using System;
using System.Reflection;

// 1️Define a repeatable attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class BugReportAttribute : Attribute
{
    public string Description { get; }

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

// 2️Apply the attribute multiple times
class IssueTracker
{
    [BugReport("Null reference occurs on startup")]
    [BugReport("UI freezes when clicking submit")]
    public void ProcessData()
    {
        Console.WriteLine("Processing data...");
    }
}

// 3️Retrieve and print all bug reports
class RepeatableAttribute
{
    static void Main()
    {
        Type type = typeof(IssueTracker);
        MethodInfo method = type.GetMethod("ProcessData");

        BugReportAttribute[] bugReports =
            (BugReportAttribute[])Attribute.GetCustomAttributes(
                method, typeof(BugReportAttribute));

        Console.WriteLine("Bug Reports:");
        foreach (BugReportAttribute bug in bugReports)
        {
            Console.WriteLine($"- {bug.Description}");
        }
    }
}
