using System;

class Employee
{
    public static string CompanyName = "Tech Solutions Pvt Ltd";
    private static int totalEmployees = 0;

    public readonly int Id;

    public string Name;
    public string Designation;

    public Employee(int id, string name, string designation)
    {
        this.Id = id;               // readonly assigned once
        this.Name = name;           // using this to resolve ambiguity
        this.Designation = designation;
        totalEmployees++;
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Company Name : " + CompanyName);
        Console.WriteLine("Employee ID  : " + Id);
        Console.WriteLine("Name         : " + Name);
        Console.WriteLine("Designation  : " + Designation);
        Console.WriteLine();
    }

    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
        Console.WriteLine();
    }
}

class Program
{
    public static void Main()
    {
        Employee e1 = new Employee(101, "Aditya", "Software Engineer");
        Employee e2 = new Employee(102, "Rahul", "Senior Developer");

        if (e1 is Employee)
        {
            e1.DisplayEmployeeDetails();
        }

        if (e2 is Employee)
        {
            e2.DisplayEmployeeDetails();
        }

        // Calling static method
        Employee.DisplayTotalEmployees();
    }
}
