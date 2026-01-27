using System;
using System.Reflection;

// 1 Define Inject attribute
[AttributeUsage(AttributeTargets.Field)]
class InjectAttribute : Attribute
{
}

// 2️ Define services
class Logger
{
    public void Log(string message)
    {
        Console.WriteLine("[LOG] " + message);
    }
}

class UserService
{
    [Inject]
    private Logger logger;

    public void CreateUser(string name)
    {
        logger.Log($"User '{name}' created successfully.");
    }
}

// 3️ Simple DI Container
class SimpleDIContainer
{
    public static T Resolve<T>() where T : new()
    {
        // Create main object
        T instance = new T();

        // Scan fields
        FieldInfo[] fields = typeof(T).GetFields(
            BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            // Check for [Inject]
            if (field.GetCustomAttribute<InjectAttribute>() != null)
            {
                // Create dependency dynamically
                object dependency = Activator.CreateInstance(field.FieldType);

                // Inject dependency
                field.SetValue(instance, dependency);
            }
        }

        return instance;
    }
}

// 4️Test DI
class DependencyInjection
{
    static void Main()
    {
        // Resolve UserService with dependencies injected
        UserService userService = SimpleDIContainer.Resolve<UserService>();

        userService.CreateUser("Aditya");
    }
}
