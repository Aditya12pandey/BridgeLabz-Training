using System;

class Employee
{
    // Access modifiers
    public int employeeID;        // Public
    protected string department;  // Protected
    private double salary;        // Private

    // Constructor
    public Employee(int employeeID, string department, double salary)
    {
        this.employeeID = employeeID;
        this.department = department;
        this.salary = salary;
    }

    // Public method to get salary
    public double GetSalary()
    {
        return salary;
    }

    // Public method to modify salary
    public void SetSalary(double newSalary)
    {
        if (newSalary > 0)
        {
            salary = newSalary;
        }
        else
        {
            Console.WriteLine("Invalid salary amount");
        }
    }
}

// Subclass
class Manager : Employee
{
    public string role;

    public Manager(int employeeID, string department, double salary, string role)
        : base(employeeID, department, salary)
    {
        this.role = role;
    }

    // Demonstrating access to public and protected members
    public void DisplayManagerDetails()
    {
        Console.WriteLine("Manager Details:");
        Console.WriteLine("Employee ID : " + employeeID);   // public
        Console.WriteLine("Department  : " + department);   // protected
        Console.WriteLine("Salary      : " + GetSalary());  // private via getter
        Console.WriteLine("Role        : " + role);
    }
}

class Program
{
    public static void Main()
    {
        Employee e1 = new Employee(101, "IT", 45000);
        e1.SetSalary(50000);

        Console.WriteLine("Updated Salary: " + e1.GetSalary());
        Console.WriteLine();

        Manager m1 = new Manager(201, "HR", 75000, "Team Lead");
        m1.DisplayManagerDetails();
    }
}
