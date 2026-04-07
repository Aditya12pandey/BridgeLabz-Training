using System;

class Person
{
    // Attributes
    public string name;
    public int age;

    // Parameterized constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Copy constructor
    public Person(Person other)
    {
        this.name = other.name;
        this.age = other.age;
    }

    // Method to display details
    public void Display()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age : " + age);
        Console.WriteLine();
    }
}

class Program
{
    public static void Main()
    {
        // Original object
        Person p1 = new Person("Aditya", 22);
        Console.WriteLine("Original Person:");
        p1.Display();

        // Copied object
        Person p2 = new Person(p1);
        Console.WriteLine("Copied Person:");
        p2.Display();
    }
}
