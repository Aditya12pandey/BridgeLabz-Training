using System;
using System.Reflection;
using System.Text;

// 1️ Define JsonField attribute
[AttributeUsage(AttributeTargets.Field)]
class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }
}

// 2️ Apply attribute to fields
class User
{
    [JsonField(Name = "user_name")]
    private string Username;

    [JsonField(Name = "user_age")]
    private int Age;

    public User(string username, int age)
    {
        Username = username;
        Age = age;
    }
}

// 3️ Custom JSON serializer using Reflection
class JsonSerializer
{
    public static string ToJson(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(
            BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder json = new StringBuilder();
        json.Append("{");

        bool firstField = true;

        foreach (FieldInfo field in fields)
        {
            JsonFieldAttribute attribute =
                field.GetCustomAttribute<JsonFieldAttribute>();

            if (attribute != null)
            {
                if (!firstField)
                    json.Append(", ");

                string key = attribute.Name;
                object value = field.GetValue(obj);

                json.Append($"\"{key}\": ");

                // Handle string vs non-string values
                if (value is string)
                    json.Append($"\"{value}\"");
                else
                    json.Append(value);

                firstField = false;
            }
        }

        json.Append("}");
        return json.ToString();
    }
}

// 4 Test the serialization
class JsonFieldAttribute
{
    static void Main()
    {
        User user = new User("Aditya", 22);

        string json = JsonSerializer.ToJson(user);
        Console.WriteLine(json);
    }
}
