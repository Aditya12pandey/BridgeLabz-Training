using System;

class StudentRecord
{
    public int RollNo { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public void DisplayRecord()
    {
        Console.WriteLine($"Roll No: {RollNo}, Name: {Name}, Age: {Age}, Grade: {Grade}");
    }
}

class StudentNode
{
    public StudentRecord Data;
    public StudentNode Next;

    public StudentNode(StudentRecord student)
    {
        Data = student;
        Next = null;
    }
}

class StudentRecordList
{
    private StudentNode head;

    // Add at Beginning
    public void AddAtBeginning(StudentRecord student)
    {
        StudentNode newNode = new StudentNode(student);
        newNode.Next = head;
        head = newNode;
        Console.WriteLine("Student record added at beginning.");
    }

    // Add at End
    public void AddAtEnd(StudentRecord student)
    {
        StudentNode newNode = new StudentNode(student);

        if (head == null)
        {
            head = newNode;
            Console.WriteLine("Student record added as first record.");
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
        Console.WriteLine("Student record added at end.");
    }

    // Add at Specific Position
    public void AddAtPosition(StudentRecord student, int position)
    {
        if (position <= 1)
        {
            AddAtBeginning(student);
            return;
        }

        StudentNode newNode = new StudentNode(student);
        StudentNode temp = head;

        for (int i = 1; i < position - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Invalid position.");
            return;
        }

        newNode.Next = temp.Next;
        temp.Next = newNode;
        Console.WriteLine("Student record added at position.");
    }

    // Delete by Roll Number
    public void DeleteByRollNo(int rollNo)
    {
        if (head == null)
        {
            Console.WriteLine("No records to delete.");
            return;
        }

        if (head.Data.RollNo == rollNo)
        {
            head = head.Next;
            Console.WriteLine("Student record deleted.");
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null && temp.Next.Data.RollNo != rollNo)
            temp = temp.Next;

        if (temp.Next == null)
        {
            Console.WriteLine("Student record not found.");
        }
        else
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Student record deleted.");
        }
    }

    // Search by Roll Number
    public void SearchByRollNo(int rollNo)
    {
        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.Data.RollNo == rollNo)
            {
                Console.WriteLine("Student record found:");
                temp.Data.DisplayRecord();
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Student record not found.");
    }

    // Update Grade
    public void UpdateGrade(int rollNo, string newGrade)
    {
        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.Data.RollNo == rollNo)
            {
                temp.Data.Grade = newGrade;
                Console.WriteLine("Student grade updated successfully.");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Student record not found.");
    }

    // Display All Records
    public void DisplayAllRecords()
    {
        if (head == null)
        {
            Console.WriteLine("No student records available.");
            return;
        }

        StudentNode temp = head;
        while (temp != null)
        {
            temp.Data.DisplayRecord();
            temp = temp.Next;
        }
    }
}

class StudentRecordApp
{
    static void Main()
    {
        StudentRecordList recordList = new StudentRecordList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Record Management System ---");
            Console.WriteLine("1. Add Student at Beginning");
            Console.WriteLine("2. Add Student at End");
            Console.WriteLine("3. Add Student at Position");
            Console.WriteLine("4. Delete Student by Roll Number");
            Console.WriteLine("5. Search Student by Roll Number");
            Console.WriteLine("6. Update Student Grade");
            Console.WriteLine("7. Display All Student Records");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                    StudentRecord student = new StudentRecord();

                    Console.Write("Enter Roll Number: ");
                    student.RollNo = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    student.Name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    student.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Grade: ");
                    student.Grade = Console.ReadLine();

                    if (choice == 1)
                        recordList.AddAtBeginning(student);
                    else if (choice == 2)
                        recordList.AddAtEnd(student);
                    else
                    {
                        Console.Write("Enter Position: ");
                        int pos = int.Parse(Console.ReadLine());
                        recordList.AddAtPosition(student, pos);
                    }
                    break;

                case 4:
                    Console.Write("Enter Roll Number to delete: ");
                    recordList.DeleteByRollNo(int.Parse(Console.ReadLine()));
                    break;

                case 5:
                    Console.Write("Enter Roll Number to search: ");
                    recordList.SearchByRollNo(int.Parse(Console.ReadLine()));
                    break;

                case 6:
                    Console.Write("Enter Roll Number: ");
                    int roll = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Grade: ");
                    string grade = Console.ReadLine();
                    recordList.UpdateGrade(roll, grade);
                    break;

                case 7:
                    recordList.DisplayAllRecords();
                    break;

                case 0:
                    Console.WriteLine("Thank you! Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
