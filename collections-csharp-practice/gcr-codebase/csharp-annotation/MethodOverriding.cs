using System;

class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a sound");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("The dog barks");
    }
}

class MethodOverriding
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.MakeSound();
    }
}
