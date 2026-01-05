using System;
using System.Collections.Generic;

// Employee class (cannot exist without Department)
class Employee
{
    public string EmployeeName;

    public Employee(string employeeName)
    {
        EmployeeName = employeeName;
    }

    public void ShowEmployee()
    {
        Console.WriteLine("    Employee: " + EmployeeName);
    }
}

// Department class (cannot exist without Company)
class Department
{
    public string DepartmentName;
    private List<Employee> employees;

    public Department(string departmentName)
    {
        DepartmentName = departmentName;
        employees = new List<Employee>();
    }

    // Composition: Department creates and owns Employees
    public void AddEmployee(string employeeName)
    {
        employees.Add(new Employee(employeeName));
    }

    public void ShowDepartment()
    {
        Console.WriteLine("  Department: " + DepartmentName);
        foreach (Employee emp in employees)
        {
            emp.ShowEmployee();
        }
    }
}

// Company class (owns Departments)
class Company
{
    public string CompanyName;
    private List<Department> departments;

    public Company(string companyName)
    {
        CompanyName = companyName;
        departments = new List<Department>();
    }

    // Composition: Company creates and owns Departments
    public void AddDepartment(Department department)
    {
        departments.Add(department);
    }

    public void ShowCompanyStructure()
    {
        Console.WriteLine("Company: " + CompanyName);
        foreach (Department dept in departments)
        {
            dept.ShowDepartment();
        }
    }
}

// Concept-focused main class
class CompositionDemo
{
    static void Main()
    {
        // Company created
        Company company = new Company("Tech Solutions Pvt Ltd");

        // Departments created and added to company
        Department itDept = new Department("IT");
        itDept.AddEmployee("Rahul");
        itDept.AddEmployee("Anita");

        Department hrDept = new Department("HR");
        hrDept.AddEmployee("Priya");

        company.AddDepartment(itDept);
        company.AddDepartment(hrDept);

        // Display company structure
        company.ShowCompanyStructure();

        // Composition behavior:
        // When 'company' object goes out of scope,
        // all departments and employees are destroyed automatically
    }
}
