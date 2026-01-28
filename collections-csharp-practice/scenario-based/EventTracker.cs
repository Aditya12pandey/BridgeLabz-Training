using System;
using System.Reflection;
using System.Text;

[AttributeUsage(AttributeTargets.Method)]
class AuditTrailAttribute : Attribute
{
    public string ActionName { get; }

    public AuditTrailAttribute(string actionName)
    {
        ActionName = actionName;
    }
}


class UserActivityService
{
    [AuditTrail("User Login")]
    public void Login()
    {
    }

    [AuditTrail("File Upload")]
    public void UploadFile()
    {
    }

    public void ViewProfile()
    {
    }

    [AuditTrail("File Delete")]
    public void DeleteFile()
    {
    }
}


class EventTracker
{
    static void Main()
    {
        Console.WriteLine("EventTracker – Auto Audit System");

        Console.Write("Enter class name to scan: ");
        string className = Console.ReadLine();

        Type targetType = Type.GetType(className);

        if (targetType == null)
        {
            Console.WriteLine("Class not found.");
            return;
        }

        MethodInfo[] methods = targetType.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        StringBuilder jsonOutput = new StringBuilder();
        jsonOutput.AppendLine("[");
        bool firstEntry = true;

        foreach (MethodInfo method in methods)
        {
            AuditTrailAttribute auditAttr =
                method.GetCustomAttribute<AuditTrailAttribute>();

            if (auditAttr != null)
            {
                if (!firstEntry)
                    jsonOutput.AppendLine(",");

                firstEntry = false;

                jsonOutput.AppendLine("  {");
                jsonOutput.AppendLine($"    \"Action\": \"{auditAttr.ActionName}\",");
                jsonOutput.AppendLine($"    \"MethodName\": \"{method.Name}\",");
                jsonOutput.AppendLine($"    \"ClassName\": \"{targetType.Name}\",");
                jsonOutput.AppendLine($"    \"Timestamp\": \"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\"");
                jsonOutput.Append("  }");
            }
        }

        jsonOutput.AppendLine();
        jsonOutput.AppendLine("]");

        Console.WriteLine("\nGenerated Audit Log (JSON):\n");
        Console.WriteLine(jsonOutput.ToString());

        Console.WriteLine("Audit scanning completed.");
    }
}
