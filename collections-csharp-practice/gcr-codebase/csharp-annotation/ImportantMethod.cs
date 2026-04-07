using System;
using System.Reflection;

// 1️Define the custom attribute
[AttributeUsage(AttributeTargets.Method)]
class ImportantMethodAttribute : Attribute
{
    public string Level { get; }

    // Optional parameter with default value
    public ImportantMethodAttribute(string level = "HIGH")
    {
        Level = level;
    }
}

// 2️Apply the attribute to methods
class Service
{
    [ImportantMethod] // Uses default level HIGH
    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment...");
    }

    [ImportantMethod("MEDIUM")]
    public void GenerateReport()
    {
        Console.WriteLine("Generating report...");
    }

    public void HelperMethod()
    {
        Console.WriteLine("Helper method (not important)");
    }
}

// 3️Retrieve and print annotated methods
class ImportantMethod
{
    static void Main()
    {
        Type type = typeof(Service);
        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Console.WriteLine("Important Methods:");

        foreach (MethodInfo method in methods)
        {
            ImportantMethodAttribute attribute =
                method.GetCustomAttribute<ImportantMethodAttribute>();

            if (attribute != null)
            {
                Console.WriteLine($"- {method.Name} (Level: {attribute.Level})");
            }
        }
    }
}
