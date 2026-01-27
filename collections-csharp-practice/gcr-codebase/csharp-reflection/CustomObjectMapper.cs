using System;
using System.Collections.Generic;
using System.Reflection;

class Student
{
    public int Id;
    public string Name;
    public int Age;
}

class ObjectMapper
{
    // Custom object mapper
    public static T ToObject<T>(Type clazz, Dictionary<string, object> properties)
    {
        // Create instance dynamically
        object obj = Activator.CreateInstance(clazz);

        foreach (var item in properties)
        {
            // Get field by name
            FieldInfo field = clazz.GetField(
                item.Key,
                BindingFlags.Public | BindingFlags.Instance);

            if (field != null)
            {
                // Set field value
                field.SetValue(obj, Convert.ChangeType(item.Value, field.FieldType));
            }
        }

        return (T)obj;
    }
}

class CustomObjectMapper
{
    static void Main()
    {
        // Dictionary with field values
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            { "Id", 101 },
            { "Name", "Aditya" },
            { "Age", 22 }
        };

        // Map dictionary to object
        Student student = ObjectMapper.ToObject<Student>(
            typeof(Student), data);

        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
    }
}
