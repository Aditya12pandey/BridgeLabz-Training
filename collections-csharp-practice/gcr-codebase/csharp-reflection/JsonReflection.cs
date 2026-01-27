using System;
using System.Reflection;
using System.Text;

class Person
{
    public int Id;
    public string Name;
    public int Age;
}

class JsonGenerator
{
    public static string ToJson(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(
            BindingFlags.Public | BindingFlags.Instance);

        StringBuilder json = new StringBuilder();
        json.Append("{");

        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo field = fields[i];
            object value = field.GetValue(obj);

            json.Append($"\"{field.Name}\": ");

            // Handle string vs non-string values
            if (value is string)
                json.Append($"\"{value}\"");
            else
                json.Append(value);

            if (i < fields.Length - 1)
                json.Append(", ");
        }

        json.Append("}");
        return json.ToString();
    }
}

class JsonReflection
{
    static void Main()
    {
        Person person = new Person
        {
            Id = 1,
            Name = "Aditya",
            Age = 22
        };

        string json = JsonGenerator.ToJson(person);
        Console.WriteLine(json);
    }
}
