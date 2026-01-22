using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class EmployeeSerializationApp
{
    static string filePath = "employees.json";

    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        while (true)
        {
            Console.WriteLine("\n Employee Serialization Menu ");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Save Employees to File");
            Console.WriteLine("3. Load Employees from File");
            Console.WriteLine("4. Display Employees");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee(employees);
                    break;

                case "2":
                    SaveEmployees(employees);
                    break;

                case "3":
                    employees = LoadEmployees();
                    break;

                case "4":
                    DisplayEmployees(employees);
                    break;

                case "5":
                    Console.WriteLine(" Exiting program...");
                    return;

                default:
                    Console.WriteLine(" Invalid choice, try again!");
                    break;
            }
        }
    }

    static void AddEmployee(List<Employee> employees)
    {
        try
        {
            Employee emp = new Employee();

            Console.Write("Enter Employee ID: ");
            emp.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            employees.Add(emp);

            Console.WriteLine(" Employee added successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine(" Invalid input format! Please enter correct values.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Error: " + ex.Message);
        }
    }

    static void SaveEmployees(List<Employee> employees)
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(employees, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, jsonData);

            Console.WriteLine(" Employees saved successfully into: " + filePath);
        }
        catch (IOException ex)
        {
            Console.WriteLine(" File Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Error: " + ex.Message);
        }
    }

    static List<Employee> LoadEmployees()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine(" File not found! Save employees first.");
                return new List<Employee>();
            }

            string jsonData = File.ReadAllText(filePath);

            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(jsonData);

            Console.WriteLine(" Employees loaded successfully from: " + filePath);
            return employees;
        }
        catch (IOException ex)
        {
            Console.WriteLine(" File Error: " + ex.Message);
            return new List<Employee>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Error: " + ex.Message);
            return new List<Employee>();
        }
    }

    static void DisplayEmployees(List<Employee> employees)
    {
        if (employees.Count == 0)
        {
            Console.WriteLine(" No employees available to display!");
            return;
        }

        Console.WriteLine("\n Employee List ");
        foreach (Employee emp in employees)
        {
            Console.WriteLine("ID         : " + emp.Id);
            Console.WriteLine("Name       : " + emp.Name);
            Console.WriteLine("Department : " + emp.Department);
            Console.WriteLine("Salary     : " + emp.Salary);
        }
    }
}
