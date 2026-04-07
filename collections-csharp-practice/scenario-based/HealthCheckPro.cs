using System;
using System.Reflection;


[AttributeUsage(AttributeTargets.Method)]
class PublicAPIAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Method)]
class RequiresAuthAttribute : Attribute
{
}


class LabTestController
{
    [PublicAPI]
    public void GetAllLabTests()
    {
    }

    [PublicAPI]
    [RequiresAuth]
    public void BookLabTest()
    {
    }

    public void DeleteLabTest()
    {
    }
}


class HealthCheckPro
{
    static void Main()
    {
        Console.WriteLine("HealthCheckPro – API Metadata Validator");

        Console.Write("Enter controller class name: ");
        string className = Console.ReadLine();

        Type controllerType = Type.GetType(className);

        if (controllerType == null)
        {
            Console.WriteLine("Controller class not found.");
            return;
        }

        Console.WriteLine("\nAPI Documentation\n");

        MethodInfo[] methods = controllerType.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (MethodInfo method in methods)
        {
            bool isPublicApi = method.IsDefined(typeof(PublicAPIAttribute), false);
            bool requiresAuth = method.IsDefined(typeof(RequiresAuthAttribute), false);

            Console.WriteLine("Method Name: " + method.Name);
            Console.WriteLine("Public API: " + (isPublicApi ? "Yes" : "No"));
            Console.WriteLine("Requires Authentication: " + (requiresAuth ? "Yes" : "No"));

            if (!isPublicApi)
            {
                Console.WriteLine("Warning: Missing PublicAPI annotation");
            }

        }

        Console.WriteLine("Validation completed.");
    }
}
