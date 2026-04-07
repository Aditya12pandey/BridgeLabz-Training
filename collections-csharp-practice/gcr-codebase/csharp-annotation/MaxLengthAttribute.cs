
using System;
using System.Reflection;

// 1️ Define the MaxLength attribute
[AttributeUsage(AttributeTargets.Field)]
class MaxLengthAttribute : Attribute
{
    public int Value { get; }

    public MaxLengthAttribute(int value)
    {
        Value = value;
    }
}

// 2️ Apply the attribute to a field
class User
{
    [MaxLength(10)]
    private string Username;

    public User(string username)
    {
        // Get field info using reflection
        FieldInfo field = typeof(User).GetField(
            "Username",
            BindingFlags.NonPublic | BindingFlags.Instance);

        MaxLengthAttribute attribute =
            field.GetCustomAttribute<MaxLengthAttribute>();

        // Validate length
        if (attribute != null && username.Length > attribute.Value)
        {
            throw new ArgumentException(
                $"Username cannot exceed {attribute.Value} characters.");
        }

        Username = username;
        Console.WriteLine("User created successfully.");
    }
}

// 3️ Test the validation
class MaxLengthAttribute
{
    static void Main()
    {
        try
        {
            User user1 = new User("Aditya");       // Valid
            User user2 = new User("VeryLongUserName"); // Invalid
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
