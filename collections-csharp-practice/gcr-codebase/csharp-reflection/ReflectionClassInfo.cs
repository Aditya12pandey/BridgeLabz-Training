using System;
using System.Reflection;

class ReflectionClassInfo
{
    static void Main()
    {
        Console.Write("Enter class name (e.g., System.String): ");
        string className = Console.ReadLine();

        Type type = Type.GetType(className);

        if (type == null)
        {
            Console.WriteLine("Class not found.");
            return;
        }

        Console.WriteLine("\n--- Fields ---");
        foreach (FieldInfo field in type.GetFields(
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static))
        {
            Console.WriteLine($"{field.FieldType.Name} {field.Name}");
        }

        Console.WriteLine("\n--- Methods ---");
        foreach (MethodInfo method in type.GetMethods(
            BindingFlags.Public | BindingFlags.Instance |
            BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            Console.WriteLine(method.Name);
        }

        Console.WriteLine("\n--- Constructors ---");
        foreach (ConstructorInfo ctor in type.GetConstructors())
        {
            Console.WriteLine(ctor);
        }
    }
}
