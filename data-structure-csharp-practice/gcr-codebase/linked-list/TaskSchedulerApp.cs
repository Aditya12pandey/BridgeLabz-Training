using System;

class TaskRecord
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }

    public void Display()
    {
        Console.WriteLine($"ID: {TaskId}, Name: {TaskName}, Priority: {Priority}, Due: {DueDate.ToShortDateString()}");
    }
}

class TaskNode
{
    public TaskRecord Data;
    public TaskNode Next;

    public TaskNode(TaskRecord task)
    {
        Data = task;
        Next = null;
    }
}

class TaskCircularList
{
    private TaskNode head;
    private TaskNode current;

    // Add at Beginning
    public void AddAtBeginning(TaskRecord task)
    {
        TaskNode newNode = new TaskNode(task);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            current = head;
        }
        else
        {
            TaskNode temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            newNode.Next = head;
            temp.Next = newNode;
            head = newNode;
        }

        Console.WriteLine("Task added at beginning.");
    }

    // Add at End
    public void AddAtEnd(TaskRecord task)
    {
        TaskNode newNode = new TaskNode(task);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            current = head;
            Console.WriteLine("Task added as first task.");
            return;
        }

        TaskNode temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        temp.Next = newNode;
        newNode.Next = head;

        Console.WriteLine("Task added at end.");
    }

    // Add at Specific Position
    public void AddAtPosition(TaskRecord task, int position)
    {
        if (position <= 1)
        {
            AddAtBeginning(task);
            return;
        }

        TaskNode temp = head;
        for (int i = 1; i < position - 1 && temp.Next != head; i++)
            temp = temp.Next;

        TaskNode newNode = new TaskNode(task);
        newNode.Next = temp.Next;
        temp.Next = newNode;

        Console.WriteLine("Task added at position.");
    }

    // Remove by Task ID
    public void RemoveByTaskId(int taskId)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        TaskNode prev = null;

        do
        {
            if (temp.Data.TaskId == taskId)
            {
                if (prev != null)
                    prev.Next = temp.Next;
                else
                {
                    TaskNode last = head;
                    while (last.Next != head)
                        last = last.Next;

                    head = head.Next;
                    last.Next = head;
                }

                Console.WriteLine("Task removed successfully.");
                return;
            }

            prev = temp;
            temp = temp.Next;

        } while (temp != head);

        Console.WriteLine("Task not found.");
    }

    // View Current Task & Move to Next
    public void ViewCurrentTask()
    {
        if (current == null)
        {
            Console.WriteLine("No tasks scheduled.");
            return;
        }

        Console.WriteLine("Current Task:");
        current.Data.Display();
        current = current.Next;
    }

    // Display All Tasks
    public void DisplayAllTasks()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        do
        {
            temp.Data.Display();
            temp = temp.Next;
        } while (temp != head);
    }

    // Search by Priority
    public void SearchByPriority(int priority)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        bool found = false;

        do
        {
            if (temp.Data.Priority == priority)
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No tasks found with given priority.");
    }
}

class TaskSchedulerApp
{
    static void Main()
    {
        TaskCircularList taskList = new TaskCircularList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Task Scheduler (Circular Linked List) ---");
            Console.WriteLine("1. Add Task at Beginning");
            Console.WriteLine("2. Add Task at End");
            Console.WriteLine("3. Add Task at Position");
            Console.WriteLine("4. Remove Task by ID");
            Console.WriteLine("5. View Current Task & Move Next");
            Console.WriteLine("6. Display All Tasks");
            Console.WriteLine("7. Search Task by Priority");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                    TaskRecord task = new TaskRecord();

                    Console.Write("Task ID: ");
                    task.TaskId = int.Parse(Console.ReadLine());
                    Console.Write("Task Name: ");
                    task.TaskName = Console.ReadLine();
                    Console.Write("Priority: ");
                    task.Priority = int.Parse(Console.ReadLine());
                    Console.Write("Due Date (yyyy-mm-dd): ");
                    task.DueDate = DateTime.Parse(Console.ReadLine());

                    if (choice == 1)
                        taskList.AddAtBeginning(task);
                    else if (choice == 2)
                        taskList.AddAtEnd(task);
                    else
                    {
                        Console.Write("Position: ");
                        int pos = int.Parse(Console.ReadLine());
                        taskList.AddAtPosition(task, pos);
                    }
                    break;

                case 4:
                    Console.Write("Enter Task ID to remove: ");
                    taskList.RemoveByTaskId(int.Parse(Console.ReadLine()));
                    break;

                case 5:
                    taskList.ViewCurrentTask();
                    break;

                case 6:
                    taskList.DisplayAllTasks();
                    break;

                case 7:
                    Console.Write("Enter Priority: ");
                    taskList.SearchByPriority(int.Parse(Console.ReadLine()));
                    break;

                case 0:
                    Console.WriteLine("Exiting Task Scheduler...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
