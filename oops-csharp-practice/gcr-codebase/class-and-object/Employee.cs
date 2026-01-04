using System;

class Employee
{
    
    public string name;
    public int id;
    public double salary;

    // Method to display details
    public void DisplayDetails()
    {
        Console.WriteLine("Employee Details:");
        Console.WriteLine("Name   : " + name);
        Console.WriteLine("ID     : " + id);
        Console.WriteLine("Salary : " + salary);
    }
}

class Program
{
    public static void Main()
    {
        Employee emp = new Employee();

        emp.name = "Aditya";
        emp.id = 101;
        emp.salary = 45000;

        // Displaying employee details
        emp.DisplayDetails();
    }
}
