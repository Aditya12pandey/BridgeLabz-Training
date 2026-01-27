using System;
using System.Reflection;

class Person
{
    private int age;

    public Person(int age)
    {
        this.age = age;
    }
}

class PrivateFieldReflection
{
    static void Main()
    {
        // Create object
        Person person = new Person(25);

        // Get Type information
        Type type = typeof(Person);

        // Access private field 'age'
        FieldInfo field = type.GetField(
            "age",
            BindingFlags.NonPublic | BindingFlags.Instance);

        // Modify private field value
        field.SetValue(person, 30);

        // Retrieve private field value
        int updatedAge = (int)field.GetValue(person);

        Console.WriteLine("Updated Age: " + updatedAge);
    }
}
