using System;

// Superclass
class Animal
{
    public string Name;
    public int Age;

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Virtual method
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

// Subclass Dog
class Dog : Animal
{
    public Dog(string name, int age) : base(name, age)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

// Subclass Cat
class Cat : Animal
{
    public Cat(string name, int age) : base(name, age)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}

// Subclass Bird
class Bird : Animal
{
    public Bird(string name, int age) : base(name, age)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Bird chirps");
    }
}

// Demo class
class InheritancePolymorphismDemo
{
    static void Main()
    {
        // Polymorphism: superclass reference, subclass objects
        Animal a1 = new Dog("Buddy", 3);
        Animal a2 = new Cat("Kitty", 2);
        Animal a3 = new Bird("Tweety", 1);

        a1.MakeSound(); // Dog barks
        a2.MakeSound(); // Cat meows
        a3.MakeSound(); // Bird chirps
    }
}
