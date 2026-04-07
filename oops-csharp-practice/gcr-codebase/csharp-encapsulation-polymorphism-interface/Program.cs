using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    // Interface
    interface IDepartment
    {
        void AssignDepartment(string departmentName);
        string GetDepartmentDetails();
    }

    // Abstract Class
    abstract class Employee : IDepartment
    {
        // Encapsulated fields
        private int employeeId;
        private string name;
        protected double baseSalary;
        private string department;

        // Properties
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Constructor
        public Employee(int id, string name, double baseSalary)
        {
            employeeId = id;
            this.name = name;
            this.baseSalary = baseSalary;
        }

        // Abstract method
        public abstract double CalculateSalary();

        // Concrete method
        public void DisplayDetails()
        {
            Console.WriteLine("Employee ID   : " + EmployeeId);
            Console.WriteLine("Name          : " + Name);
            Console.WriteLine("Department    : " + department);
            Console.WriteLine("Salary        : " + CalculateSalary());
            Console.WriteLine("--------------------------------");
        }

        // Interface methods
        public void AssignDepartment(string departmentName)
        {
            department = departmentName;
        }

        public string GetDepartmentDetails()
        {
            return department;
        }
    }

    // Full-Time Employee
    class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(int id, string name, double salary)
            : base(id, name, salary)
        {
        }

        public override double CalculateSalary()
        {
            return baseSalary; // Fixed salary
        }
    }

    // Part-Time Employee
    class PartTimeEmployee : Employee
    {
        private int workHours;
        private double hourlyRate;

        public PartTimeEmployee(int id, string name, int hours, double rate)
            : base(id, name, 0)
        {
            workHours = hours;
            hourlyRate = rate;
        }

        public override double CalculateSalary()
        {
            return workHours * hourlyRate;
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Employee emp1 = new FullTimeEmployee(101, "Rahul", 50000);
            emp1.AssignDepartment("HR");

            Employee emp2 = new PartTimeEmployee(102, "Anita", 80, 300);
            emp2.AssignDepartment("IT");

            employees.Add(emp1);
            employees.Add(emp2);

            // Polymorphism
            foreach (Employee emp in employees)
            {
                emp.DisplayDetails();
            }

            Console.ReadLine();
        }
    }
}
